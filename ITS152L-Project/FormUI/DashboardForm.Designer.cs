namespace FormsUI
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Title
            lblTitle = new Label();
            lblTitle.Text = "Inventory Dashboard";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            // Statistics Panel
            pnlStats = new Panel();
            pnlStats.Location = new Point(20, 70);
            pnlStats.Size = new Size(940, 150);
            pnlStats.BorderStyle = BorderStyle.FixedSingle;

            lblTotalItems = CreateStatLabel("Total Items: Loading...", 20, 20);
            lblTotalValue = CreateStatLabel("Total Inventory Value: Loading...", 20, 50);
            lblLowStock = CreateStatLabel("Low Stock Items: Loading...", 20, 80);
            lblTopItem = CreateStatLabel("Top Item by Quantity: Loading...", 20, 110);

            pnlStats.Controls.AddRange(new Control[] {
                lblTotalItems, lblTotalValue, lblLowStock, lblTopItem
            });

            // Audit Log Label
            Label lblAuditTitle = new Label();
            lblAuditTitle.Text = "Recent Activity";
            lblAuditTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblAuditTitle.Location = new Point(20, 240);
            lblAuditTitle.AutoSize = true;

            // Audit Log DataGridView
            dgvAuditLog = new DataGridView();
            dgvAuditLog.Location = new Point(20, 270);
            dgvAuditLog.Size = new Size(940, 220);
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.AllowUserToDeleteRows = false;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Buttons
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(20, 510);
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Click += BtnRefresh_Click;

            btnBackToInventory = new Button();
            btnBackToInventory.Text = "Back to Inventory";
            btnBackToInventory.Location = new Point(130, 510);
            btnBackToInventory.Size = new Size(150, 30);
            btnBackToInventory.Click += BtnBackToInventory_Click;

            this.Controls.AddRange(new Control[] {
                lblTitle, pnlStats, lblAuditTitle, dgvAuditLog,
                btnRefresh, btnBackToInventory
            });

            this.Load += DashboardForm_Load;
        }

        private Label lblTitle;
        private Panel pnlStats;
        private Label lblTotalItems;
        private Label lblTotalValue;
        private Label lblLowStock;
        private Label lblTopItem;
        private DataGridView dgvAuditLog;
        private Button btnRefresh;
        private Button btnBackToInventory;

        #endregion
    }
}