using ItemDataLibrary.Models;

namespace FormsUI
{
    partial class AuditLogForm
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
            lblTitle = new Label();
            lblFilter = new Label();
            cmbFilterType = new ComboBox();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnFilter = new Button();
            btnClear = new Button();
            dgvAuditLog = new DataGridView();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Audit Trail";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.Location = new Point(20, 65);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(61, 19);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Filter by:";
            // 
            // cmbFilterType
            // 
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.Items.AddRange(new object[] { "All Actions", "Added Only", "Updated Only", "Deleted Only" });
            cmbFilterType.Location = new Point(90, 63);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(150, 23);
            cmbFilterType.TabIndex = 2;

            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.Location = new Point(260, 65);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(44, 19);
            lblFrom.TabIndex = 3;
            lblFrom.Text = "From:";

            dtpFrom.Location = new Point(310, 63);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 23);
            dtpFrom.TabIndex = 4;
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "MM/dd/yyyy";  

            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.Location = new Point(450, 65);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(26, 19);
            lblTo.TabIndex = 5;
            lblTo.Text = "To:";

            dtpTo.Location = new Point(480, 63);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 23);
            dtpTo.TabIndex = 6;
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "MM/dd/yyyy";  

            // === Add Controls to Form ===
            this.Controls.Add(lblFrom);
            this.Controls.Add(dtpFrom);
            this.Controls.Add(lblTo);
            this.Controls.Add(dtpTo);


            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(780, 62);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 27);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "Apply Filter";
            btnFilter.Click += BtnFilter_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(890, 62);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 27);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            // 
            // dgvAuditLog
            // 
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.AllowUserToDeleteRows = false;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.Location = new Point(20, 110);
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLog.Size = new Size(1040, 430);
            dgvAuditLog.TabIndex = 9;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(20, 560);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 30);
            btnExport.TabIndex = 10;
            btnExport.Text = "Export to CSV";
            btnExport.Click += BtnExport_Click;
            // 
            // AuditLogForm
            // 
            ClientSize = new Size(1200, 589);
            Controls.Add(lblTitle);
            Controls.Add(lblFilter);
            Controls.Add(cmbFilterType);
            Controls.Add(lblFrom);
            Controls.Add(dtpFrom);
            Controls.Add(lblTo);
            Controls.Add(dtpTo);
            Controls.Add(btnFilter);
            Controls.Add(btnClear);
            Controls.Add(dgvAuditLog);
            Controls.Add(btnExport);
            Name = "AuditLogForm";
            Load += AuditLogForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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

        #endregion
    }
}