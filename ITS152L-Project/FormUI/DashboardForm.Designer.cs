using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsUI
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTotalItems;
        private Label lblTotalValue;
        private Label lblLowStock;
        private Label lblTopItem;
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

            // === FORM SETTINGS ===
            this.ClientSize = new Size(1200, 780); // increased height so nothing is cropped
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Inventory Dashboard";
            this.Load += DashboardForm_Load;

            // === TITLE ===
            Label lblTitle = new Label
            {
                Text = "Inventory Dashboard",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // === STATS CONTAINER ===
            Panel statsContainer = new Panel
            {
                Location = new Point(30, 90),
                Size = new Size(1140, 140),
                BackColor = Color.Transparent
            };

            Panel cardTotal = CreateStatCard("Total Items", "0", Color.FromArgb(59, 130, 246), 0, 0);
            Panel cardValue = CreateStatCard("Total Inventory Value", "$0.00", Color.FromArgb(34, 197, 94), 280, 0);
            Panel cardLowStock = CreateStatCard("Low Stock Items (< 10 units)", "0", Color.FromArgb(234, 179, 8), 560, 0);
            Panel cardTopItem = CreateStatCard("Top Item by Quantity", "N/A", Color.FromArgb(168, 85, 247), 840, 0);

            lblTotalItems = (Label)cardTotal.Controls[2];
            lblTotalValue = (Label)cardValue.Controls[2];
            lblLowStock = (Label)cardLowStock.Controls[2];
            lblTopItem = (Label)cardTopItem.Controls[2];

            statsContainer.Controls.AddRange(new Control[] { cardTotal, cardValue, cardLowStock, cardTopItem });

            // === RECENT ACTIVITY TITLE ===
            Label lblAuditTitle = new Label
            {
                Text = "Recent Activity",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 260),
                AutoSize = true
            };

            // === AUDIT PANEL ===
            Panel auditPanel = new Panel
            {
                Location = new Point(30, 300),
                Size = new Size(1140, 350),
                BackColor = Color.White,
                Padding = new Padding(20)
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvAuditLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvAuditLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAuditLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvAuditLog.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dgvAuditLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            auditPanel.Controls.Add(dgvAuditLog);

            // === BUTTON PANEL (BOTTOM) ===
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80, // slightly taller to prevent cropping
                BackColor = Color.White,
                Padding = new Padding(20, 10, 20, 10)
            };

            btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(130, 45),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;

            btnBackToInventory = new Button
            {
                Text = "← Back to Inventory",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(170, 15),
                Size = new Size(190, 45),
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBackToInventory.FlatAppearance.BorderSize = 0;
            btnBackToInventory.Click += BtnBackToInventory_Click;

            buttonPanel.Controls.AddRange(new Control[] { btnRefresh, btnBackToInventory });

            // === ADD EVERYTHING ===
            this.Controls.AddRange(new Control[] {
                lblTitle, statsContainer, lblAuditTitle, auditPanel, buttonPanel
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel CreateStatCard(string title, string value, Color accentColor, int x, int y)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(260, 130),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Panel accent = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(card.Width, 5),
                BackColor = accentColor
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(15, 20),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(15, 50),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { accent, lblTitle, lblValue });
            return card;
        }
    }
}
