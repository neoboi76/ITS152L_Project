/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * (admin) UserManagementForm Designer class. Contains the design parameters for
 * the aforementioned form
 **/

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
            this.ClientSize = new Size(1300, 750);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Name = "UserManagementForm";
            this.Text = "User Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += UserManagementForm_Load;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 15)
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
                Height = 75,
                BackColor = Color.White,
                Padding = new Padding(20, 12, 20, 12)
            };

            Label lblSearch = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(90, 17),
                Size = new Size(280, 25),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            Label lblRoleFilter = new Label
            {
                Text = "Role:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(390, 20),
                AutoSize = true
            };

            cmbRoleFilter = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(440, 17),
                Size = new Size(130, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRoleFilter.Items.AddRange(new object[] { "All", "User", "Admin" });
            cmbRoleFilter.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndexChanged += CmbRoleFilter_SelectedIndexChanged;

            btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(590, 15),
                Size = new Size(120, 32),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = Color.FromArgb(59, 130, 246);

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
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false
            };

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvUsers.ColumnHeadersHeight = 40;
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dgvUsers.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvUsers.RowTemplate.Height = 36;

            contentPanel.Controls.Add(dgvUsers);

            Panel actionPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 75,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            btnDeleteUser = new Button
            {
                Text = "Delete User",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnDeleteUser.MouseEnter += (s, e) => btnDeleteUser.BackColor = Color.FromArgb(220, 38, 38);
            btnDeleteUser.MouseLeave += (s, e) => btnDeleteUser.BackColor = Color.FromArgb(239, 68, 68);

            btnToggleAdmin = new Button
            {
                Text = "Toggle Admin",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(165, 15),
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(234, 179, 8),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnToggleAdmin.FlatAppearance.BorderSize = 0;
            btnToggleAdmin.Click += BtnToggleAdmin_Click;
            btnToggleAdmin.MouseEnter += (s, e) => btnToggleAdmin.BackColor = Color.FromArgb(202, 138, 4);
            btnToggleAdmin.MouseLeave += (s, e) => btnToggleAdmin.BackColor = Color.FromArgb(234, 179, 8);

            btnViewAuditLog = new Button
            {
                Text = "View Audit Log",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(320, 15),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnViewAuditLog.FlatAppearance.BorderSize = 0;
            btnViewAuditLog.Click += BtnViewAuditLog_Click;
            btnViewAuditLog.MouseEnter += (s, e) => btnViewAuditLog.BackColor = Color.FromArgb(37, 99, 235);
            btnViewAuditLog.MouseLeave += (s, e) => btnViewAuditLog.BackColor = Color.FromArgb(59, 130, 246);

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