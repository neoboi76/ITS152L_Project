using System.Runtime.InteropServices;

namespace FormsUI
{
    partial class RegisterForm
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
            this.ClientSize = new Size(900, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Name = "RegisterForm";
            this.Text = "Teleoplex Inventory System - Register";

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
            rightPanel.Padding = new Padding(60, 60, 60, 60);

            int startX = 90;
            int startY = 40;
            int fieldWidth = 350;
            int spacing = 65;

            Label lblTitle = new Label();
            lblTitle.Text = "Create Account";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(startX, startY);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Fill in your details to register";
            lblSubtitle.Font = new Font("Segoe UI", 11);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(startX, startY + 45);

            int y = startY + 100;

            Label lblEmail = new Label();
            lblEmail.Text = "Email Address";
            lblEmail.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(startX, y);

            txtRegUser = new TextBox();
            txtRegUser.Font = new Font("Segoe UI", 12);
            txtRegUser.Location = new Point(startX, y + 25);
            txtRegUser.Size = new Size(fieldWidth, 32);
            txtRegUser.BorderStyle = BorderStyle.FixedSingle;
            txtRegUser.PlaceholderText = "example@email.com";
            SetTextBoxPadding(txtRegUser, 8, 0);

            y += spacing;

            Label lblFirst = new Label();
            lblFirst.Text = "First Name";
            lblFirst.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFirst.ForeColor = Color.FromArgb(51, 65, 85);
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(startX, y);

            txtRegFirst = new TextBox();
            txtRegFirst.Font = new Font("Segoe UI", 12);
            txtRegFirst.Location = new Point(startX, y + 25);
            txtRegFirst.Size = new Size(fieldWidth, 32);
            txtRegFirst.BorderStyle = BorderStyle.FixedSingle;
            SetTextBoxPadding(txtRegFirst, 8, 0);

            y += spacing;

            Label lblLast = new Label();
            lblLast.Text = "Last Name";
            lblLast.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLast.ForeColor = Color.FromArgb(51, 65, 85);
            lblLast.AutoSize = true;
            lblLast.Location = new Point(startX, y);

            txtRegLast = new TextBox();
            txtRegLast.Font = new Font("Segoe UI", 12);
            txtRegLast.Location = new Point(startX, y + 25);
            txtRegLast.Size = new Size(fieldWidth, 32);
            txtRegLast.BorderStyle = BorderStyle.FixedSingle;
            SetTextBoxPadding(txtRegLast, 8, 0);

            y += spacing;

            Label lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(51, 65, 85);
            lblPass.AutoSize = true;
            lblPass.Location = new Point(startX, y);

            txtRegNewPass = new TextBox();
            txtRegNewPass.Font = new Font("Segoe UI", 12);
            txtRegNewPass.Location = new Point(startX, y + 25);
            txtRegNewPass.Size = new Size(fieldWidth, 32);
            txtRegNewPass.BorderStyle = BorderStyle.FixedSingle;
            txtRegNewPass.UseSystemPasswordChar = true;
            txtRegNewPass.TextChanged += (s, e) => UpdatePasswordStrength();
            SetTextBoxPadding(txtRegNewPass, 8, 0);

            lblPasswordStrength = new Label();
            lblPasswordStrength.Text = "Password Strength:";
            lblPasswordStrength.Font = new Font("Segoe UI", 9);
            lblPasswordStrength.Location = new Point(startX, y + 65);
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.ForeColor = Color.FromArgb(100, 116, 139);

            pbPasswordStrength = new ProgressBar();
            pbPasswordStrength.Location = new Point(startX + 150, y + 70);
            pbPasswordStrength.Size = new Size(200, 10);
            pbPasswordStrength.Style = ProgressBarStyle.Continuous;

            y += spacing + 40;

            Label lblConfirm = new Label();
            lblConfirm.Text = "Confirm Password";
            lblConfirm.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConfirm.ForeColor = Color.FromArgb(51, 65, 85);
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(startX, y);

            txtRegConfirm = new TextBox();
            txtRegConfirm.Font = new Font("Segoe UI", 12);
            txtRegConfirm.Location = new Point(startX, y + 25);
            txtRegConfirm.Size = new Size(fieldWidth, 32);
            txtRegConfirm.BorderStyle = BorderStyle.FixedSingle;
            txtRegConfirm.UseSystemPasswordChar = true;
            SetTextBoxPadding(txtRegConfirm, 8, 0);

            y += spacing + 20;

            btnRegSub = new Button();
            btnRegSub.Text = "Sign Up";
            btnRegSub.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegSub.Location = new Point(startX, y - 10);
            btnRegSub.Size = new Size(fieldWidth, 45);
            btnRegSub.BackColor = Color.FromArgb(37, 99, 235);
            btnRegSub.ForeColor = Color.White;
            btnRegSub.FlatStyle = FlatStyle.Flat;
            btnRegSub.FlatAppearance.BorderSize = 0;
            btnRegSub.Cursor = Cursors.Hand;
            btnRegSub.Click += btnRegSub_ClickAsync;

            btnRegSub.MouseEnter += (s, e) => btnRegSub.BackColor = Color.FromArgb(29, 78, 216);
            btnRegSub.MouseLeave += (s, e) => btnRegSub.BackColor = Color.FromArgb(37, 99, 235);

            LinkLabel backToLogin = new LinkLabel();
            backToLogin.Text = "Already have an account? Sign in";
            backToLogin.Font = new Font("Segoe UI", 9);
            backToLogin.LinkColor = Color.FromArgb(37, 99, 235);
            backToLogin.AutoSize = true;
            backToLogin.Location = new Point(startX, y + 55);
            backToLogin.LinkClicked += (s, e) => { this.Hide(); new LoginForm().Show(); };

            rightPanel.Controls.AddRange(new Control[] {
                lblTitle, lblSubtitle,
                lblEmail, txtRegUser,
                lblFirst, txtRegFirst,
                lblLast, txtRegLast,
                lblPass, txtRegNewPass,
                lblPasswordStrength, pbPasswordStrength,
                lblConfirm, txtRegConfirm,
                btnRegSub, backToLogin
            });

            this.Controls.Add(rightPanel);
            this.Controls.Add(leftPanel);

            this.ResumeLayout(false);
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

        private TextBox txtRegUser;
        private TextBox txtRegFirst;
        private TextBox txtRegLast;
        private TextBox txtRegNewPass;
        private TextBox txtRegConfirm;
        private Button btnRegSub;
        private Label lblPasswordStrength;
        private ProgressBar pbPasswordStrength;
    }
}