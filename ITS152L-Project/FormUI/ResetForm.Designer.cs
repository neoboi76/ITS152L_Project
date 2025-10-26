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

            // ===== FORM PROPERTIES =====
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Name = "ResetForm";
            this.Text = "Teleoplex Inventory System - Reset Password";

            // ===== LEFT PANEL =====
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

            // ===== RIGHT PANEL =====
            Panel rightPanel = new Panel();
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = Color.White;
            rightPanel.Padding = new Padding(60, 80, 60, 80);

            // ===== TITLES =====
            Label lblTitle = new Label();
            lblTitle.Text = "Reset Password";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(90, 100);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Please enter your username and new password";
            lblSubtitle.Font = new Font("Segoe UI", 11);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(90, 140);

            // ===== USERNAME =====
            Label lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(90, 200);

            txtResUser = new TextBox();
            txtResUser.Font = new Font("Segoe UI", 12);
            txtResUser.Location = new Point(90, 225);
            txtResUser.Size = new Size(350, 32);
            txtResUser.BorderStyle = BorderStyle.FixedSingle;

            // ===== NEW PASSWORD =====
            Label lblNewPass = new Label();
            lblNewPass.Text = "New Password";
            lblNewPass.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNewPass.ForeColor = Color.FromArgb(51, 65, 85);
            lblNewPass.AutoSize = true;
            lblNewPass.Location = new Point(90, 280);

            txtResNewPass = new TextBox();
            txtResNewPass.Font = new Font("Segoe UI", 12);
            txtResNewPass.Location = new Point(90, 305);
            txtResNewPass.Size = new Size(350, 32);
            txtResNewPass.UseSystemPasswordChar = true;
            txtResNewPass.BorderStyle = BorderStyle.FixedSingle;

            // ===== CONFIRM PASSWORD =====
            Label lblConfirmPass = new Label();
            lblConfirmPass.Text = "Confirm Password";
            lblConfirmPass.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConfirmPass.ForeColor = Color.FromArgb(51, 65, 85);
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Location = new Point(90, 360);

            txtResConfirm = new TextBox();
            txtResConfirm.Font = new Font("Segoe UI", 12);
            txtResConfirm.Location = new Point(90, 385);
            txtResConfirm.Size = new Size(350, 32);
            txtResConfirm.UseSystemPasswordChar = true;
            txtResConfirm.BorderStyle = BorderStyle.FixedSingle;

            // ===== SUBMIT BUTTON =====
            btnReset = new Button();
            btnReset.Text = "Reset Password";
            btnReset.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnReset.Location = new Point(90, 440);
            btnReset.Size = new Size(350, 45);
            btnReset.BackColor = Color.FromArgb(37, 99, 235);
            btnReset.ForeColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += btnReset_Click;

            // Hover effect
            btnReset.MouseEnter += (s, e) => btnReset.BackColor = Color.FromArgb(29, 78, 216);
            btnReset.MouseLeave += (s, e) => btnReset.BackColor = Color.FromArgb(37, 99, 235);

            // ===== ADD CONTROLS =====
            rightPanel.Controls.AddRange(new Control[] {
                lblTitle, lblSubtitle, lblUsername, txtResUser,
                lblNewPass, txtResNewPass, lblConfirmPass, txtResConfirm, btnReset
            });

            this.Controls.Add(rightPanel);
            this.Controls.Add(leftPanel);

            this.ResumeLayout(false);
        }

        #endregion

        private TextBox txtResUser;
        private TextBox txtResNewPass;
        private TextBox txtResConfirm;
        private Button btnReset;
    }
}
