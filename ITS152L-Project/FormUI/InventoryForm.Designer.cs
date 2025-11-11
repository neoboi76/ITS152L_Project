using ItemDataLibrary.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FormsUI
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SessionManager.SessionExpired -= OnSessionExpired;
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();

            itemModelBindingSource = new BindingSource(components);
            itemModelBindingSource.DataSource = typeof(ItemModel);

            errorProvider1 = new ErrorProvider(components);
            itemErrorProvider = new ErrorProvider(components);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Name = "InventoryForm";
            this.Text = "Teleoplex Inventory System";
            this.StartPosition = FormStartPosition.CenterScreen;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(20, 15, 20, 0),
                BackColor = Color.White
            };

            Label lblTitle = new Label
            {
                Text = "Item Dashboard",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Label lblUserInfo = new Label
            {
                Text = $"Logged in as: {_currentUserName} ({_currentUserRole})",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(20, 50)
            };

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblUserInfo);

            pnlLeftSide = new Panel
            {
                BackColor = Color.White,
                Location = new Point(20, 120),
                Size = new Size(440, 640),
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

            lblItemName = CreateLabel("Item Name", 20, 70);
            txtItemName = CreateTextBox(20, 95, 400);
            SetTextBoxPadding(txtItemName, 8, 0);
            txtItemName.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Name", true));

            lblItemCode = CreateLabel("Item Code", 20, 140);
            txtItemCode = CreateTextBox(20, 165, 400);
            txtItemCode.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Code", true));
            SetTextBoxPadding(txtItemCode, 8, 0);

            lblItemBrand = CreateLabel("Brand", 20, 210);
            txtItemBrand = CreateTextBox(20, 235, 400);
            txtItemBrand.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Brand", true));
            SetTextBoxPadding(txtItemBrand, 8, 0);

            lblItemPrice = CreateLabel("Unit Price", 20, 280);
            txtItemPrice = CreateTextBox(20, 305, 190);
            txtItemPrice.DataBindings.Add(new Binding("Text", itemModelBindingSource, "UnitPrice", true));
            SetTextBoxPadding(txtItemPrice, 8, 0);

            lblItemQuantity = CreateLabel("Quantity", 230, 280);
            txtItemQuantity = CreateTextBox(230, 305, 190);
            txtItemQuantity.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Quantity", true));
            SetTextBoxPadding(txtItemQuantity, 8, 0);

            label2 = new Label
            {
                Text = "*All fields are required.\n*Code, Price, and Quantity must be numbers.",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(20, 360),
                AutoSize = true
            };

            btnItemNew = CreateButton("New Item", 20, 410, Color.FromArgb(37, 99, 235));
            btnItemNew.Click += btnItemNew_Click;

            btnItemUpdate = CreateButton("Update", 145, 410, Color.FromArgb(59, 130, 246));
            btnItemUpdate.Click += btnItemUpdate_Click;

            btnItemDelete = CreateButton("Delete", 270, 410, Color.FromArgb(239, 68, 68));
            btnItemDelete.Click += btnItemDelete_Click;

            btnItemSave = CreateButton("Save", 20, 465, Color.FromArgb(34, 197, 94));
            btnItemSave.Click += btnItemSave_Click;

            btnItemCancel = CreateButton("Cancel", 145, 465, Color.FromArgb(148, 163, 184));
            btnItemCancel.Click += btnItemCancel_Click;

            btnQuickPrint = CreateButton("🖨 Print", 270, 465, Color.FromArgb(168, 85, 247));
            btnQuickPrint.Click += (s, e) => PrintPreviewToolStripMenuItem_Click(s, e);

            pnlLeftSide.Controls.AddRange(new Control[] {
                lblFormTitle, lblItemName, txtItemName, lblItemCode, txtItemCode,
                lblItemBrand, txtItemBrand, lblItemPrice, txtItemPrice,
                lblItemQuantity, txtItemQuantity, label2,
                btnItemNew, btnItemUpdate, btnItemDelete, btnItemSave, btnItemCancel, btnQuickPrint
            });

            Panel rightPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(480, 120),
                Size = new Size(900, 640),
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

            Panel searchPanel = new Panel
            {
                Location = new Point(20, 55),
                Size = new Size(860, 40),
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(10, 8, 10, 8)
            };

            lblSearch = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(10, 10),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(75, 8),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            lblSortBy = new Label
            {
                Text = "Sort By:",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(345, 10),
                AutoSize = true
            };

            cmbSortBy = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(410, 8),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbSortBy.Items.AddRange(new object[] {
                "Name (A-Z)",
                "Name (Z-A)",
                "ID (Low-High)",
                "ID (High-Low)",
                "Code (Low-High)",
                "Code (High-Low)",
                "Brand (A-Z)",
                "Brand (Z-A)",
                "Price (Low-High)",
                "Price (High-Low)",
                "Quantity (Low-High)",
                "Quantity (High-Low)"
            });
            cmbSortBy.SelectedIndexChanged += CmbSortBy_SelectedIndexChanged;

            btnRefresh = new Button
            {
                Text = "🔄",
                Font = new Font("Segoe UI", 12),
                Location = new Point(630, 6),
                Size = new Size(40, 30),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;

            btnExportCsv = new Button
            {
                Text = "📄 Export",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(685, 6),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.Click += BtnExportCsv_Click;

            searchPanel.Controls.AddRange(new Control[] {
                lblSearch, txtSearch, lblSortBy, cmbSortBy, btnRefresh, btnExportCsv
            });

            dataGridView1 = new DataGridView
            {
                Location = new Point(20, 105),
                Size = new Size(860, 510),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false
            };

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridView1.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView1.RowTemplate.Height = 36;

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                CreateColumn("Id", "ID", 60),
                CreateColumn("Name", "Name", 200),
                CreateColumn("Code", "Code", 100),
                CreateColumn("Brand", "Brand", 150),
                CreateColumn("UnitPrice", "Unit Price", 120),
                CreateColumn("Quantity", "Quantity", 100)
            });

            dataGridView1.DataSource = itemModelBindingSource;

            rightPanel.Controls.Add(lblGridTitle);
            rightPanel.Controls.Add(searchPanel);
            rightPanel.Controls.Add(dataGridView1);

            this.Controls.Add(headerPanel);
            this.Controls.Add(pnlLeftSide);
            this.Controls.Add(rightPanel);

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
                Size = new Size(115, 40),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

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

        #region Menu initializers

        private void InitializeMenuStrip()
        {
            if (menuStrip1 != null) return;

            menuStrip1 = new MenuStrip();

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

            userManagementToolStripMenuItem = new ToolStripMenuItem
            {
                Text = "User Management",
                Visible = string.Equals(_currentUserRole, "Admin", StringComparison.OrdinalIgnoreCase)
            };
            userManagementToolStripMenuItem.Click += UserManagementToolStripMenuItem_Click;

            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                dashboardToolStripMenuItem,
                auditLogToolStripMenuItem,
                userManagementToolStripMenuItem
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


        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x1;
        private const int EC_RIGHTMARGIN = 0x2;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private void SetTextBoxPadding(TextBox textBox, int left, int right)
        {
            SendMessage(textBox.Handle, EM_SETMARGINS, EC_LEFTMARGIN | EC_RIGHTMARGIN, (right << 16) + left);
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
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem printToPdfToolStripMenuItem;
        private Button btnQuickPrint;
        private Panel pnlLeftSide;

        #endregion
    }
}