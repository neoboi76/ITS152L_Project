using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsUI
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUserCount;
        private Label lblAdminCount;
        private TextBox txtSearch;
        private ComboBox cmbRoleFilter;
        private Button btnRefresh;
        private DataGridView dgvUsers;
        private Button btnDeleteUser;
        private Button btnToggleAdmin;
        private Button btnViewAuditLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Name = "UserManagementForm";
            this.Text = "User Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += UserManagementForm_Load;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 20)
            };

            Label lblTitle = new Label
            {
                Text = "User Management",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(30, 20)
            };

            lblUserCount = new Label
            {
                Text = "Total Users: 0",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(30, 65)
            };

            lblAdminCount = new Label
            {
                Text = "Admins: 0",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(180, 65)
            };

            headerPanel.Controls.AddRange(new Control[] { lblTitle, lblUserCount, lblAdminCount });

            Panel filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label lblSearch = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(85, 17),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            Label lblRoleFilter = new Label
            {
                Text = "Role:",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(360, 20),
                AutoSize = true
            };

            cmbRoleFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(410, 17),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRoleFilter.Items.AddRange(new object[] { "All", "User", "Admin" });
            cmbRoleFilter.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndexChanged += CmbRoleFilter_SelectedIndexChanged;

            btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Font = new Font("Segoe UI", 10),
                Location = new Point(550, 15),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;

            filterPanel.Controls.AddRange(new Control[] {
                lblSearch, txtSearch, lblRoleFilter, cmbRoleFilter, btnRefresh
            });

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            dgvUsers = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false
            };

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            contentPanel.Controls.Add(dgvUsers);

            Panel actionPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20, 5, 20, 20)
            };

            btnDeleteUser = new Button
            {
                Text = "Delete User",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 10),
                Size = new Size(120, 50),
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.Click += BtnDeleteUser_Click;

            btnToggleAdmin = new Button
            {
                Text = "Toggle Admin",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(150, 10),
                Size = new Size(130, 50),
                BackColor = Color.FromArgb(234, 179, 8),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnToggleAdmin.FlatAppearance.BorderSize = 0;
            btnToggleAdmin.Click += BtnToggleAdmin_Click;

            btnViewAuditLog = new Button
            {
                Text = "View Audit Log",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(290, 10),
                Size = new Size(140, 50),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnViewAuditLog.FlatAppearance.BorderSize = 0;
            btnViewAuditLog.Click += BtnViewAuditLog_Click;

            actionPanel.Controls.AddRange(new Control[] {
                btnDeleteUser, btnToggleAdmin, btnViewAuditLog
            });

            this.Controls.AddRange(new Control[] {
                contentPanel, actionPanel, filterPanel, headerPanel
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
