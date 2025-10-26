/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

namespace FormsUI
{
    partial class LoginForm
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
            this.SuspendLayout();

            // Form properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Name = "LoginForm";
            this.Text = "Teleoplex Inventory System - Login";

            // Left Panel (Branding/Image)
            Panel leftPanel = new Panel();
            leftPanel.BackColor = Color.FromArgb(37, 99, 235); // Blue
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

            // Right Panel (Login Form)
            Panel rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = Color.White;
            rightPanel.Padding = new Padding(60, 80, 60, 80);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Welcome Back";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(90, 100);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Please sign in to continue";
            lblSubtitle.Font = new Font("Segoe UI", 11);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(90, 140);

            // Username
            Label lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(90, 200);

            txtLogName = new TextBox();
            txtLogName.Font = new Font("Segoe UI", 12);
            txtLogName.Location = new Point(90, 225);
            txtLogName.Size = new Size(350, 32);
            txtLogName.BorderStyle = BorderStyle.FixedSingle;

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(90, 280);

            txtLogPass = new TextBox();
            txtLogPass.Font = new Font("Segoe UI", 12);
            txtLogPass.Location = new Point(90, 305);
            txtLogPass.Size = new Size(350, 32);
            txtLogPass.UseSystemPasswordChar = true;
            txtLogPass.BorderStyle = BorderStyle.FixedSingle;

            // Links
            forgotPass = new LinkLabel();
            forgotPass.Text = "Forgot password?";
            forgotPass.Font = new Font("Segoe UI", 9);
            forgotPass.LinkColor = Color.FromArgb(37, 99, 235);
            forgotPass.AutoSize = true;
            forgotPass.Location = new Point(350, 350);
            forgotPass.LinkClicked += linkLabel1_LinkClicked;

            createAccount = new LinkLabel();
            createAccount.Text = "Create new account";
            createAccount.Font = new Font("Segoe UI", 9);
            createAccount.LinkColor = Color.FromArgb(37, 99, 235);
            createAccount.AutoSize = true;
            createAccount.Location = new Point(90, 350);
            createAccount.LinkClicked += linkLabel2_LinkClicked;

            // Submit Button
            btnLogSub = new Button();
            btnLogSub.Text = "Sign In";
            btnLogSub.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogSub.Location = new Point(90, 390);
            btnLogSub.Size = new Size(350, 45);
            btnLogSub.BackColor = Color.FromArgb(37, 99, 235);
            btnLogSub.ForeColor = Color.White;
            btnLogSub.FlatStyle = FlatStyle.Flat;
            btnLogSub.FlatAppearance.BorderSize = 0;
            btnLogSub.Cursor = Cursors.Hand;
            btnLogSub.Click += btnLogSub_ClickAsync;

            // Add hover effect
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