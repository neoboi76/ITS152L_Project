/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * LoginForm Designer class. Contains the design parameters for
 * the aforementioned form
 **/

using System.Runtime.InteropServices;

namespace FormsUI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(950, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Name = "LoginForm";
            this.Text = "Teleoplex Inventory System - Login";

            Panel leftPanel = new Panel();
            leftPanel.BackColor = Color.FromArgb(37, 99, 235);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Width = 380;

            Panel gradientOverlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            Label brandLabel = new Label();
            brandLabel.Text = "TELEOPLEX";
            brandLabel.Font = new Font("Segoe UI", 36, FontStyle.Bold);
            brandLabel.ForeColor = Color.White;
            brandLabel.AutoSize = false;
            brandLabel.Size = new Size(340, 70);
            brandLabel.Location = new Point(20, 140);
            brandLabel.TextAlign = ContentAlignment.MiddleCenter;

            Label taglineLabel = new Label();
            taglineLabel.Text = "Inventory Management System";
            taglineLabel.Font = new Font("Segoe UI", 13);
            taglineLabel.ForeColor = Color.FromArgb(191, 219, 254);
            taglineLabel.AutoSize = false;
            taglineLabel.Size = new Size(340, 35);
            taglineLabel.Location = new Point(20, 220);
            taglineLabel.TextAlign = ContentAlignment.MiddleCenter;

            Label versionLabel = new Label();
            versionLabel.Text = "Bringing the future into the present, for itself, by itself";
            versionLabel.Font = new Font("Segoe UI", 10);
            versionLabel.ForeColor = Color.FromArgb(147, 197, 253);
            versionLabel.AutoSize = false;
            versionLabel.Size = new Size(340, 30);
            versionLabel.Location = new Point(20, 270);
            versionLabel.TextAlign = ContentAlignment.MiddleCenter;

            leftPanel.Controls.Add(brandLabel);
            leftPanel.Controls.Add(taglineLabel);
            leftPanel.Controls.Add(versionLabel);

            Panel rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = Color.White;
            rightPanel.Padding = new Padding(60, 90, 60, 90);

            Label lblTitle = new Label();
            lblTitle.Text = "Welcome Back";
            lblTitle.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(90, 100);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Please sign in to continue";
            lblSubtitle.Font = new Font("Segoe UI", 11);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(90, 145);

            Label lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(90, 210);

            txtLogName = new TextBox();
            txtLogName.Font = new Font("Segoe UI", 12);
            txtLogName.Location = new Point(90, 235);
            txtLogName.Size = new Size(360, 34);
            txtLogName.BorderStyle = BorderStyle.FixedSingle;
            SetTextBoxPadding(txtLogName, 8, 0);

            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(90, 295);

            txtLogPass = new TextBox();
            txtLogPass.Font = new Font("Segoe UI", 12);
            txtLogPass.Location = new Point(90, 320);
            txtLogPass.Size = new Size(360, 34);
            txtLogPass.UseSystemPasswordChar = true;
            txtLogPass.BorderStyle = BorderStyle.FixedSingle;
            SetTextBoxPadding(txtLogPass, 8, 0);

            forgotPass = new LinkLabel();
            forgotPass.Text = "Forgot password?";
            forgotPass.Font = new Font("Segoe UI", 9);
            forgotPass.LinkColor = Color.FromArgb(37, 99, 235);
            forgotPass.AutoSize = true;
            forgotPass.Location = new Point(350, 370);
            forgotPass.LinkClicked += linkLabel1_LinkClicked;

            createAccount = new LinkLabel();
            createAccount.Text = "Create new account";
            createAccount.Font = new Font("Segoe UI", 9);
            createAccount.LinkColor = Color.FromArgb(37, 99, 235);
            createAccount.AutoSize = true;
            createAccount.Location = new Point(90, 370);
            createAccount.LinkClicked += linkLabel2_LinkClicked;

            btnLogSub = new Button();
            btnLogSub.Text = "Sign In";
            btnLogSub.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogSub.Location = new Point(90, 410);
            btnLogSub.Size = new Size(360, 48);
            btnLogSub.BackColor = Color.FromArgb(37, 99, 235);
            btnLogSub.ForeColor = Color.White;
            btnLogSub.FlatStyle = FlatStyle.Flat;
            btnLogSub.FlatAppearance.BorderSize = 0;
            btnLogSub.Cursor = Cursors.Hand;
            btnLogSub.Click += btnLogSub_ClickAsync;

            btnLogSub.MouseEnter += (s, e) => {
                btnLogSub.BackColor = Color.FromArgb(29, 78, 216);
            };
            btnLogSub.MouseLeave += (s, e) => {
                btnLogSub.BackColor = Color.FromArgb(37, 99, 235);
            };

            rightPanel.Controls.AddRange(new Control[] {
                lblTitle, lblSubtitle, lblUsername, txtLogName,
                lblPassword, txtLogPass, forgotPass, createAccount, btnLogSub
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

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtLogName;
        private TextBox txtLogPass;
        private Button btnLogSub;
        private LinkLabel forgotPass;
        private LinkLabel createAccount;
    }
}