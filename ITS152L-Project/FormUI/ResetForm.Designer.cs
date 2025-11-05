namespace FormsUI
{
    partial class ResetForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.ClientSize = new Size(900, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Name = "ResetForm";
            this.Text = "Teleoplex Inventory System - Reset Password";

            Panel leftPanel = new Panel();
            leftPanel.BackColor = Color.FromArgb(37, 99, 235);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Width = 350;

            Label brandLabel = new Label();
            brandLabel.Text = "TELEOPLEX";
            brandLabel.Font = new Font("Segoe UI", 32, FontStyle.Bold);
            brandLabel.ForeColor = Color.White;
            brandLabel.AutoSize = false;
            brandLabel.Size = new Size(300, 60);
            brandLabel.Location = new Point(25, 150);
            brandLabel.TextAlign = ContentAlignment.MiddleCenter;

            Label taglineLabel = new Label();
            taglineLabel.Text = "Inventory Management System";
            taglineLabel.Font = new Font("Segoe UI", 12);
            taglineLabel.ForeColor = Color.FromArgb(191, 219, 254);
            taglineLabel.AutoSize = false;
            taglineLabel.Size = new Size(300, 30);
            taglineLabel.Location = new Point(25, 220);
            taglineLabel.TextAlign = ContentAlignment.MiddleCenter;

            leftPanel.Controls.Add(brandLabel);
            leftPanel.Controls.Add(taglineLabel);

            Panel rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = Color.White;
            rightPanel.Padding = new Padding(60, 80, 60, 80);

            Label lblTitle = new Label();
            lblTitle.Text = "Reset Password";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(90, 80);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Enter your email to receive a verification code";
            lblSubtitle.Font = new Font("Segoe UI", 11);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(90, 120);

            pnlEmailEntry = new Panel();
            pnlEmailEntry.Location = new Point(90, 170);
            pnlEmailEntry.Size = new Size(400, 100);
            pnlEmailEntry.BackColor = Color.White;

            Label lblEmail = new Label();
            lblEmail.Text = "Email Address";
            lblEmail.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(0, 0);

            txtEmail = new TextBox();
            txtEmail.Font = new Font("Segoe UI", 12);
            txtEmail.Location = new Point(0, 25);
            txtEmail.Size = new Size(350, 32);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.PlaceholderText = "example@email.com";

            btnSendCode = new Button();
            btnSendCode.Text = "Send Code";
            btnSendCode.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSendCode.Location = new Point(0, 65);
            btnSendCode.Size = new Size(350, 40);
            btnSendCode.BackColor = Color.FromArgb(37, 99, 235);
            btnSendCode.ForeColor = Color.White;
            btnSendCode.FlatStyle = FlatStyle.Flat;
            btnSendCode.FlatAppearance.BorderSize = 0;
            btnSendCode.Cursor = Cursors.Hand;
            btnSendCode.Click += btnSendCode_Click;
            btnSendCode.MouseEnter += (s, e) => btnSendCode.BackColor = Color.FromArgb(29, 78, 216);
            btnSendCode.MouseLeave += (s, e) => btnSendCode.BackColor = Color.FromArgb(37, 99, 235);

            pnlEmailEntry.Controls.AddRange(new Control[] { lblEmail, txtEmail, btnSendCode });

            pnlVerification = new Panel();
            pnlVerification.Location = new Point(90, 280);
            pnlVerification.Size = new Size(400, 100);
            pnlVerification.BackColor = Color.White;
            pnlVerification.Visible = false;

            Label lblCode = new Label();
            lblCode.Text = "Verification Code";
            lblCode.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCode.ForeColor = Color.FromArgb(51, 65, 85);
            lblCode.AutoSize = true;
            lblCode.Location = new Point(0, 0);

            txtVerificationCode = new TextBox();
            txtVerificationCode.Font = new Font("Segoe UI", 12);
            txtVerificationCode.Location = new Point(0, 25);
            txtVerificationCode.Size = new Size(350, 32);
            txtVerificationCode.BorderStyle = BorderStyle.FixedSingle;
            txtVerificationCode.PlaceholderText = "Enter 6-digit code";
            txtVerificationCode.MaxLength = 6;

            btnVerifyCode = new Button();
            btnVerifyCode.Text = "Verify Code";
            btnVerifyCode.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnVerifyCode.Location = new Point(0, 65);
            btnVerifyCode.Size = new Size(350, 40);
            btnVerifyCode.BackColor = Color.FromArgb(34, 197, 94);
            btnVerifyCode.ForeColor = Color.White;
            btnVerifyCode.FlatStyle = FlatStyle.Flat;
            btnVerifyCode.FlatAppearance.BorderSize = 0;
            btnVerifyCode.Cursor = Cursors.Hand;
            btnVerifyCode.Click += btnVerifyCode_Click;
            btnVerifyCode.MouseEnter += (s, e) => btnVerifyCode.BackColor = Color.FromArgb(22, 163, 74);
            btnVerifyCode.MouseLeave += (s, e) => btnVerifyCode.BackColor = Color.FromArgb(34, 197, 94);

            pnlVerification.Controls.AddRange(new Control[] { lblCode, txtVerificationCode, btnVerifyCode });

            pnlPasswordReset = new Panel();
            pnlPasswordReset.Location = new Point(90, 170);
            pnlPasswordReset.Size = new Size(400, 200);
            pnlPasswordReset.BackColor = Color.White;
            pnlPasswordReset.Visible = false;

            Label lblNewPass = new Label();
            lblNewPass.Text = "New Password";
            lblNewPass.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(51, 65, 85);
            lblNewPass.AutoSize = true;
            lblNewPass.Location = new Point(0, 0);

            txtNewPassword = new TextBox();
            txtNewPassword.Font = new Font("Segoe UI", 12);
            txtNewPassword.Location = new Point(0, 25);
            txtNewPassword.Size = new Size(350, 32);
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.UseSystemPasswordChar = true;

            Label lblConfirmPass = new Label();
            lblConfirmPass.Text = "Confirm Password";
            lblConfirmPass.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(51, 65, 85);
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Location = new Point(0, 70);

            txtConfirmPassword = new TextBox();
            txtConfirmPassword.Font = new Font("Segoe UI", 12);
            txtConfirmPassword.Location = new Point(0, 95);
            txtConfirmPassword.Size = new Size(350, 32);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.UseSystemPasswordChar = true;

            btnResetPassword = new Button();
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnResetPassword.Location = new Point(0, 140);
            btnResetPassword.Size = new Size(350, 45);
            btnResetPassword.BackColor = Color.FromArgb(37, 99, 235);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.Click += btnResetPassword_Click;
            btnResetPassword.MouseEnter += (s, e) => btnResetPassword.BackColor = Color.FromArgb(29, 78, 216);
            btnResetPassword.MouseLeave += (s, e) => btnResetPassword.BackColor = Color.FromArgb(37, 99, 235);

            pnlPasswordReset.Controls.AddRange(new Control[] {
                lblNewPass, txtNewPassword, lblConfirmPass, txtConfirmPassword, btnResetPassword
            });

            rightPanel.Controls.AddRange(new Control[] {
                lblTitle, lblSubtitle, pnlEmailEntry, pnlVerification, pnlPasswordReset
            });

            this.Controls.Add(rightPanel);
            this.Controls.Add(leftPanel);

            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlEmailEntry;
        private Panel pnlVerification;
        private Panel pnlPasswordReset;
        private TextBox txtEmail;
        private TextBox txtVerificationCode;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnSendCode;
        private Button btnVerifyCode;
        private Button btnResetPassword;
    }
}