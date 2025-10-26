using FormsUI;
using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace FormsUI
{
    public class InventoryPrinter
    {
        private List<ItemModel> _items;
        private string _title;
        private string _userName;
        private int _currentPage = 0;
        private int _itemsPerPage = 25;
        private Font _titleFont = new Font("Arial", 18, FontStyle.Bold);
        private Font _headerFont = new Font("Arial", 10, FontStyle.Bold);
        private Font _bodyFont = new Font("Arial", 9);
        private Font _footerFont = new Font("Arial", 8, FontStyle.Italic);

        public InventoryPrinter(List<ItemModel> items, string title, string userName)
        {
            _items = items;
            _title = title;
            _userName = userName;
        }

        public void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        public void PrintPreview()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 900;
            previewDialog.Height = 700;
            previewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float yPos = 50;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;

            // Draw title
            SizeF titleSize = graphics.MeasureString(_title, _titleFont);
            graphics.DrawString(_title, _titleFont, Brushes.Black,
                (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += titleSize.Height + 10;

            // Draw info line
            string infoLine = $"Generated: {DateTime.Now:MM/dd/yyyy HH:mm} | By: {_userName} | Page: {_currentPage + 1}";
            graphics.DrawString(infoLine, _footerFont, Brushes.Gray, leftMargin, yPos);
            yPos += 30;

            // Draw horizontal line
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Column headers
            float col1 = leftMargin;
            float col2 = leftMargin + 60;
            float col3 = leftMargin + 300;
            float col4 = leftMargin + 450;
            float col5 = leftMargin + 550;
            float col6 = leftMargin + 650;

            graphics.DrawString("ID", _headerFont, Brushes.Black, col1, yPos);
            graphics.DrawString("Name", _headerFont, Brushes.Black, col2, yPos);
            graphics.DrawString("Brand", _headerFont, Brushes.Black, col3, yPos);
            graphics.DrawString("Code", _headerFont, Brushes.Black, col4, yPos);
            graphics.DrawString("Price", _headerFont, Brushes.Black, col5, yPos);
            graphics.DrawString("Qty", _headerFont, Brushes.Black, col6, yPos);
            yPos += 25;

            // Draw horizontal line
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Calculate items for this page
            int startIndex = _currentPage * _itemsPerPage;
            int endIndex = Math.Min(startIndex + _itemsPerPage, _items.Count);

            // Draw items
            for (int i = startIndex; i < endIndex; i++)
            {
                if (yPos > e.PageBounds.Height - 100)
                {
                    break; // Prevent overflow
                }

                var item = _items[i];

                // Alternate row background
                if (i % 2 == 0)
                {
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)),
                        leftMargin - 5, yPos - 2, rightMargin - leftMargin + 10, 20);
                }

                graphics.DrawString(item.Id.ToString(), _bodyFont, Brushes.Black, col1, yPos);

                // Truncate long names
                string name = item.Name.Length > 25 ? item.Name.Substring(0, 22) + "..." : item.Name;
                graphics.DrawString(name, _bodyFont, Brushes.Black, col2, yPos);

                string brand = item.Brand.Length > 15 ? item.Brand.Substring(0, 12) + "..." : item.Brand;
                graphics.DrawString(brand, _bodyFont, Brushes.Black, col3, yPos);

                graphics.DrawString(item.Code.ToString(), _bodyFont, Brushes.Black, col4, yPos);
                graphics.DrawString($"${item.UnitPrice:F2}", _bodyFont, Brushes.Black, col5, yPos);
                graphics.DrawString(item.Quantity.ToString(), _bodyFont, Brushes.Black, col6, yPos);

                yPos += 20;
            }

            yPos += 10;
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 20;

            // Draw summary
            if (endIndex >= _items.Count)
            {
                int totalItems = _items.Count;
                int totalQuantity = _items.Sum(i => i.Quantity);
                double totalValue = _items.Sum(i => i.UnitPrice * i.Quantity);

                string summary = $"Total Items: {totalItems} | Total Quantity: {totalQuantity} | Total Value: ${totalValue:N2}";
                graphics.DrawString(summary, _headerFont, Brushes.Black, leftMargin, yPos);
            }

            // Draw footer
            string footer = $"Teleoplex Inventory System - Confidential";
            SizeF footerSize = graphics.MeasureString(footer, _footerFont);
            graphics.DrawString(footer, _footerFont, Brushes.Gray,
                (e.PageBounds.Width - footerSize.Width) / 2,
                e.PageBounds.Height - 50);

            // Check if more pages needed
            _currentPage++;
            if (endIndex < _items.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                _currentPage = 0; // Reset for next print job
            }
        }

        // Generate PDF (requires additional package)
        public void SaveAsPDF(string filePath)
        {
            // Note: This requires iTextSharp or similar library
            // For basic functionality, use PrintDocument with PDF printer
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDoc.PrinterSettings.PrintToFile = true;
            printDoc.PrinterSettings.PrintFileName = filePath;

            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save PDF: {ex.Message}");
            }
        }
    }
}

