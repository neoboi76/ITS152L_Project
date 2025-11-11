/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * (admin) AuditLogForm Designer class. Contains the design parameters for
 * the aforementioned form
 **/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ItemDataLibrary.Models;


namespace FormsUI
{
    partial class AuditLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private string _currentUserName;
        private DataGridView dgvAuditLog;
        private ComboBox cmbFilterType;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnFilter;
        private Button btnClear;
        private Button btnExport;
        private Label lblTitle;
        private Label lblFrom;
        private Label lblTo;
        private Label lblFilter;
        private List<AuditLog> _allLogs = new List<AuditLog>();

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
            this.Name = "AuditLogForm";
            this.Text = "Audit Trail";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += AuditLogForm_Load;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 15)
            };

            lblTitle = new Label
            {
                Text = "Audit Trail",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(30, 20)
            };

            headerPanel.Controls.Add(lblTitle);

            Panel filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 75,
                BackColor = Color.White,
                Padding = new Padding(20, 12, 20, 12)
            };

            lblFilter = new Label
            {
                Text = "Filter:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(20, 20),
                AutoSize = true
            };

            cmbFilterType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(75, 17),
                Size = new Size(160, 25)
            };
            cmbFilterType.Items.AddRange(new object[] { "All Actions", "Added Only", "Updated Only", "Deleted Only" });
            cmbFilterType.SelectedIndex = 0;

            lblFrom = new Label
            {
                Text = "From:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(255, 20),
                AutoSize = true
            };

            dtpFrom = new DateTimePicker
            {
                Location = new Point(310, 17),
                Size = new Size(140, 25),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "MM/dd/yyyy"
            };

            lblTo = new Label
            {
                Text = "To:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(470, 20),
                AutoSize = true
            };

            dtpTo = new DateTimePicker
            {
                Location = new Point(505, 17),
                Size = new Size(140, 25),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "MM/dd/yyyy"
            };

            btnFilter = new Button
            {
                Text = "Apply Filter",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(665, 15),
                Size = new Size(120, 32),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += BtnFilter_Click;
            btnFilter.MouseEnter += (s, e) => btnFilter.BackColor = Color.FromArgb(37, 99, 235);
            btnFilter.MouseLeave += (s, e) => btnFilter.BackColor = Color.FromArgb(59, 130, 246);

            btnClear = new Button
            {
                Text = "Clear",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(800, 15),
                Size = new Size(100, 32),
                BackColor = Color.FromArgb(148, 163, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;
            btnClear.MouseEnter += (s, e) => btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.MouseLeave += (s, e) => btnClear.BackColor = Color.FromArgb(148, 163, 184);

            filterPanel.Controls.AddRange(new Control[] {
                lblFilter, cmbFilterType, lblFrom, dtpFrom, lblTo, dtpTo, btnFilter, btnClear
            });

            Panel gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
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

            gridPanel.Controls.Add(dgvAuditLog);

            Panel actionPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 75,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            btnExport = new Button
            {
                Text = "📄 Export to CSV",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(170, 40),
                BackColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Click += BtnExport_Click;
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = Color.FromArgb(22, 163, 74);
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = Color.FromArgb(34, 197, 94);

            actionPanel.Controls.Add(btnExport);

            this.Controls.AddRange(new Control[] {
                gridPanel, actionPanel, filterPanel, headerPanel
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}