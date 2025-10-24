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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtLogName = new TextBox();
            txtLogPass = new TextBox();
            btnLogSub = new Button();
            forgotPass = new LinkLabel();
            createAccount = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(231, 36);
            label1.Name = "label1";
            label1.Size = new Size(328, 32);
            label1.TabIndex = 0;
            label1.Text = "Teleoplex Inventory System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(244, 121);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(244, 183);
            label3.Name = "label3";
            label3.Size = new Size(76, 21);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // txtLogName
            // 
            txtLogName.Font = new Font("Segoe UI", 12F);
            txtLogName.Location = new Point(331, 118);
            txtLogName.Name = "txtLogName";
            txtLogName.Size = new Size(205, 29);
            txtLogName.TabIndex = 3;
            // 
            // txtLogPass
            // 
            txtLogPass.Font = new Font("Segoe UI", 12F);
            txtLogPass.Location = new Point(331, 180);
            txtLogPass.Name = "txtLogPass";
            txtLogPass.Size = new Size(205, 29);
            txtLogPass.TabIndex = 4;
            txtLogPass.UseSystemPasswordChar = true;
            // 
            // btnLogSub
            // 
            btnLogSub.Font = new Font("Segoe UI", 12F);
            btnLogSub.Location = new Point(244, 245);
            btnLogSub.Name = "btnLogSub";
            btnLogSub.Size = new Size(131, 31);
            btnLogSub.TabIndex = 5;
            btnLogSub.Text = "Submit";
            btnLogSub.UseVisualStyleBackColor = true;
            btnLogSub.Click += btnLogSub_ClickAsync;
            // 
            // forgotPass
            // 
            forgotPass.AutoSize = true;
            forgotPass.Location = new Point(436, 219);
            forgotPass.Name = "forgotPass";
            forgotPass.Size = new Size(100, 15);
            forgotPass.TabIndex = 6;
            forgotPass.TabStop = true;
            forgotPass.Text = "Forgot password?";
            forgotPass.LinkClicked += linkLabel1_LinkClicked;
            // 
            // createAccount
            // 
            createAccount.AutoSize = true;
            createAccount.Location = new Point(328, 219);
            createAccount.Name = "createAccount";
            createAccount.Size = new Size(102, 15);
            createAccount.TabIndex = 7;
            createAccount.TabStop = true;
            createAccount.Text = "New to Multiplex?";
            createAccount.LinkClicked += linkLabel2_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(createAccount);
            Controls.Add(forgotPass);
            Controls.Add(btnLogSub);
            Controls.Add(txtLogPass);
            Controls.Add(txtLogName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
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