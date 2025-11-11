using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsUI
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTotalItemsValue;
        private Label lblTotalValueValue;
        private Label lblLowStockValue;
        private Label lblTopItemValue;
        private DataGridView dgvAuditLog;
        private Button btnRefresh;
        private Button btnBackToInventory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(1200, 800);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Inventory Dashboard";
            this.Load += DashboardForm_Load;

            Panel headerPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 90),
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 15)
            };

            Label lblTitle = new Label
            {
                Text = "Inventory Dashboard",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 25),
                AutoSize = true
            };

            headerPanel.Controls.Add(lblTitle);

            Panel statsContainer = new Panel
            {
                Location = new Point(30, 110),
                Size = new Size(1140, 130),
                BackColor = Color.Transparent
            };

            Panel cardTotal = CreateStatCard("Total Items", "0", Color.FromArgb(59, 130, 246), 0);
            Panel cardValue = CreateStatCard("Total Inventory Value", "$0.00", Color.FromArgb(34, 197, 94), 285);
            Panel cardLowStock = CreateStatCard("Low Stock Items", "0", Color.FromArgb(234, 179, 8), 570);
            Panel cardTopItem = CreateStatCard("Top Item", "N/A", Color.FromArgb(168, 85, 247), 855);

            lblTotalItemsValue = (Label)cardTotal.Controls[2];
            lblTotalValueValue = (Label)cardValue.Controls[2];
            lblLowStockValue = (Label)cardLowStock.Controls[2];
            lblTopItemValue = (Label)cardTopItem.Controls[2];

            statsContainer.Controls.AddRange(new Control[] { cardTotal, cardValue, cardLowStock, cardTopItem });

            Label lblAuditTitle = new Label
            {
                Text = "Recent Activity",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 260),
                AutoSize = true
            };

            Panel auditPanel = new Panel
            {
                Location = new Point(30, 300),
                Size = new Size(1140, 390),
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            dgvAuditLog = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false
            };
            dgvAuditLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvAuditLog.ColumnHeadersHeight = 40;
            dgvAuditLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvAuditLog.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dgvAuditLog.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgvAuditLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvAuditLog.RowTemplate.Height = 36;

            auditPanel.Controls.Add(dgvAuditLog);

            Panel buttonPanel = new Panel
            {
                Location = new Point(30, 710),
                Size = new Size(1140, 65),
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 12),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = Color.FromArgb(59, 130, 246);

            btnBackToInventory = new Button
            {
                Text = "← Back to Inventory",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(160, 12),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBackToInventory.FlatAppearance.BorderSize = 0;
            btnBackToInventory.Click += BtnBackToInventory_Click;
            btnBackToInventory.MouseEnter += (s, e) => btnBackToInventory.BackColor = Color.FromArgb(71, 85, 105);
            btnBackToInventory.MouseLeave += (s, e) => btnBackToInventory.BackColor = Color.FromArgb(100, 116, 139);

            buttonPanel.Controls.AddRange(new Control[] { btnRefresh, btnBackToInventory });

            this.Controls.AddRange(new Control[] {
                headerPanel, statsContainer, lblAuditTitle, auditPanel, buttonPanel
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel CreateStatCard(string title, string value, Color accentColor, int xOffset)
        {
            Panel card = new Panel
            {
                Location = new Point(xOffset, 0),
                Size = new Size(270, 120),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            Panel accent = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(card.Width, 4),
                BackColor = accentColor
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(15, 20),
                Size = new Size(240, 25),
                AutoSize = false
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(15, 50),
                AutoSize = true,
                MaximumSize = new Size(240, 0)
            };

            card.Controls.AddRange(new Control[] { accent, lblTitle, lblValue });
            return card;
        }


    }

}