using ItemDataLibrary.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

/*
Developed by: 
    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol
*/

// Designer partial class
namespace FormsUI
{
    partial class InventoryForm
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
            if (disposing)
            {
                // unsubscribe static events defensively
                SessionManager.SessionExpired -= OnSessionExpired;

                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ensure components container exists
            components = new Container();

            // Instantiate BindingSource and ErrorProviders early to avoid null references
            itemModelBindingSource = new BindingSource(components);
            itemModelBindingSource.DataSource = typeof(ItemModel);

            errorProvider1 = new ErrorProvider(components);
            itemErrorProvider = new ErrorProvider(components);

            // Form properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Name = "InventoryForm";
            this.Text = "Teleoplex Inventory System";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Header Panel
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(20, 40, 20, 0),
                BackColor = Color.White
            };

            Label lblTitle = new Label
            {
                Text = "Item Dashboard",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label lblUserInfo = new Label
            {
                Text = $"Logged in as: {_currentUserName} ({_currentUserRole})",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(30, 60)
            };

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblUserInfo);

            // Left Panel (Item Details Form)
            Panel leftPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(20, 100),
                Size = new Size(420, 550),
                Padding = new Padding(20)
            };

            Label lblFormTitle = new Label
            {
                Text = "Item Details",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Item Name
            lblItemName = CreateLabel("Item Name", 20, 70);
            txtItemName = CreateTextBox(20, 95, 380);
            txtItemName.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Name", true));

            // Item Code
            lblItemCode = CreateLabel("Item Code", 20, 140);
            txtItemCode = CreateTextBox(20, 165, 380);
            txtItemCode.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Code", true));

            // Item Brand
            lblItemBrand = CreateLabel("Brand", 20, 210);
            txtItemBrand = CreateTextBox(20, 235, 380);
            txtItemBrand.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Brand", true));

            // Unit Price
            lblItemPrice = CreateLabel("Unit Price", 20, 280);
            txtItemPrice = CreateTextBox(20, 305, 180);
            txtItemPrice.DataBindings.Add(new Binding("Text", itemModelBindingSource, "UnitPrice", true));

            // Quantity
            lblItemQuantity = CreateLabel("Quantity", 220, 280);
            txtItemQuantity = CreateTextBox(220, 305, 180);
            txtItemQuantity.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Quantity", true));

            // Note
            label2 = new Label
            {
                Text = "*All fields are required.\n*Code, Price, and Quantity must be numbers.",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(20, 350),
                AutoSize = true
            };

            // Buttons
            btnItemNew = CreateButton("New Item", 20, 400, Color.FromArgb(37, 99, 235));
            btnItemNew.Click += btnItemNew_Click;

            btnItemUpdate = CreateButton("Update", 140, 400, Color.FromArgb(59, 130, 246));
            btnItemUpdate.Click += btnItemUpdate_Click;

            btnItemDelete = CreateButton("Delete", 260, 400, Color.FromArgb(239, 68, 68));
            btnItemDelete.Click += btnItemDelete_Click;

            btnItemSave = CreateButton("Save", 20, 450, Color.FromArgb(34, 197, 94));
            btnItemSave.Click += btnItemSave_Click;

            btnItemCancel = CreateButton("Cancel", 140, 450, Color.FromArgb(148, 163, 184));
            btnItemCancel.Click += btnItemCancel_Click;

            leftPanel.Controls.AddRange(new Control[] {
                lblFormTitle, lblItemName, txtItemName, lblItemCode, txtItemCode,
                lblItemBrand, txtItemBrand, lblItemPrice, txtItemPrice,
                lblItemQuantity, txtItemQuantity, label2,
                btnItemNew, btnItemUpdate, btnItemDelete, btnItemSave, btnItemCancel
            });

            // Right Panel (DataGridView)
            Panel rightPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(460, 100),
                Size = new Size(720, 550),
                Padding = new Padding(20)
            };

            Label lblGridTitle = new Label
            {
                Text = "Inventory List",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // DataGridView
            dataGridView1 = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(680, 470),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false
            };

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // Columns
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                CreateColumn("Id", "Id", 50),
                CreateColumn("Name", "Name", 150),
                CreateColumn("Code", "Code", 80),
                CreateColumn("Brand", "Brand", 120),
                CreateColumn("UnitPrice", "Unit Price", 100),
                CreateColumn("Quantity", "Quantity", 100)
            });

            // attach DataSource after binding source was created above
            dataGridView1.DataSource = itemModelBindingSource;

            rightPanel.Controls.Add(lblGridTitle);
            rightPanel.Controls.Add(dataGridView1);

            // Add panels to form
            this.Controls.Add(headerPanel);
            this.Controls.Add(leftPanel);
            this.Controls.Add(rightPanel);

            // Note: itemModelBindingSource and error providers already created at top of this method

            this.ResumeLayout(false);
        }

        #endregion

        #region Helper factory methods

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int x, int y, int width)
        {
            return new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = new Point(x, y),
                Size = new Size(width, 30),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Button CreateButton(string text, int x, int y, Color color)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(x, y),
                Size = new Size(110, 38),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            // Hover effects
            Color hoverColor = ControlPaint.Light(color, 0.2f);
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = color;

            return btn;
        }

        private DataGridViewTextBoxColumn CreateColumn(string propertyName, string headerText, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Name = propertyName + "Column",
                ReadOnly = true,
                Width = width
            };
        }

        #endregion

        #region Search / Menu initializers (designer adds these controls at runtime)

        private void InitializeSearchAndSort()
        {
            // Prevent duplicate initialization
            if (txtSearch != null && cmbSortBy != null) return;

            // Search TextBox
            lblSearch = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(380, 12),
                Text = "Search:"
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(440, 10),
                Size = new Size(200, 25)
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            // Sort ComboBox
            lblSortBy = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(650, 12),
                Text = "Sort By:"
            };

            cmbSortBy = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(710, 10),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbSortBy.Items.AddRange(new object[] {
                "Name (A-Z)",
                "Name (Z-A)",
                "Price (Low-High)",
                "Price (High-Low)",
                "Quantity (Low-High)",
                "Quantity (High-Low)",
                "Brand (A-Z)",
                "Code"
            });
            cmbSortBy.SelectedIndexChanged += CmbSortBy_SelectedIndexChanged;

            // Refresh button
            btnRefresh = new Button
            {
                Location = new Point(870, 10),
                Size = new Size(25, 25),
                Text = "🔄"
            };
            btnRefresh.Click += BtnRefresh_Click;

            btnQuickPrint = new Button
            {
                Text = "🖨 Print",
                Location = new Point(324, 387),
                Size = new Size(98, 33)
            };
            UITheme.StyleSecondaryButton(btnQuickPrint);
            btnQuickPrint.Click += (s, e) => PrintPreviewToolStripMenuItem_Click(s, e);
            this.Controls.Add(btnQuickPrint);

            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            this.Controls.Add(lblSortBy);
            this.Controls.Add(cmbSortBy);
            this.Controls.Add(btnRefresh);
        }

        private void InitializeMenuStrip()
        {
            // Prevent double-init
            if (menuStrip1 != null) return;

            menuStrip1 = new MenuStrip();

            // File menu
            fileToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "&File"
            };

            ToolStripMenuItem exportMenuItem = new ToolStripMenuItem
            {
                Text = "Export to CSV"
            };
            exportMenuItem.Click += BtnExportCsv_Click;

            logoutToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Logout"
            };
            logoutToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;

            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                exportMenuItem,
                new ToolStripSeparator(),
                logoutToolStripMenuItem
            });

            // View menu
            viewToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "&View"
            };

            dashboardToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Dashboard"
            };
            dashboardToolStripMenuItem.Click += DashboardToolStripMenuItem_Click;

            auditLogToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Audit Log",
                Visible = string.Equals(_currentUserRole, "Admin", StringComparison.OrdinalIgnoreCase)
            };
            auditLogToolStripMenuItem.Click += AuditLogToolStripMenuItem_Click;

            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                dashboardToolStripMenuItem,
                auditLogToolStripMenuItem
            });

            menuStrip1.Items.AddRange(new ToolStripItem[] {
                fileToolStripMenuItem,
                viewToolStripMenuItem
            });

            ToolStripMenuItem printMenuItem = new ToolStripMenuItem
            {
                Text = "&Print"
            };

            printToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Print Inventory List",
                ShortcutKeys = Keys.Control | Keys.P
            };
            printToolStripMenuItem.Click += PrintToolStripMenuItem_Click;

            printPreviewToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Print Preview"
            };
            printPreviewToolStripMenuItem.Click += PrintPreviewToolStripMenuItem_Click;

            printToPdfToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "Save as PDF"
            };
            printToPdfToolStripMenuItem.Click += PrintToPdfToolStripMenuItem_Click;

            printMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                printToolStripMenuItem,
                printPreviewToolStripMenuItem,
                new ToolStripSeparator(),
                printToPdfToolStripMenuItem
            });

            menuStrip1.Items.Add(printMenuItem);

            this.MainMenuStrip = menuStrip1;
            this.Controls.Add(menuStrip1);
        }

        #endregion

        #region Designer fields

        private DataGridView dataGridView1;
        private BindingSource itemModelBindingSource;
        private Label lblItemName;
        private Label lblItemCode;
        private Label lblItemBrand;
        private Label lblItemPrice;
        private Label lblItemQuantity;
        private TextBox txtItemName;
        private TextBox txtItemCode;
        private TextBox txtItemBrand;
        private TextBox txtItemPrice;
        private TextBox txtItemQuantity;
        private Button btnItemNew;
        private Button btnItemDelete;
        private Button btnItemUpdate;
        private Button btnItemCancel;
        private Button btnItemSave;
        private Label label2;
        private ErrorProvider errorProvider1;
        private ErrorProvider itemErrorProvider;
        private TextBox txtSearch;
        private ComboBox cmbSortBy;
        private Label lblSearch;
        private Label lblSortBy;
        private Button btnRefresh;
        private Button btnExportCsv;
        private Button btnDashboard;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem auditLogToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem printToPdfToolStripMenuItem;
        private Button btnQuickPrint;

        #endregion
    }
}
