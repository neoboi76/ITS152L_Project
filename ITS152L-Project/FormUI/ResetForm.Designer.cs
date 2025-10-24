
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
            btnReset = new Button();
            txtResConfirm = new TextBox();
            txtResNewPass = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtResUser = new TextBox();
            lblResUser = new Label();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 12F);
            btnReset.Location = new Point(393, 261);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(131, 31);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset Password";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtResConfirm
            // 
            txtResConfirm.Font = new Font("Segoe UI", 12F);
            txtResConfirm.Location = new Point(358, 211);
            txtResConfirm.Name = "txtResConfirm";
            txtResConfirm.Size = new Size(205, 29);
            txtResConfirm.TabIndex = 12;
            txtResConfirm.UseSystemPasswordChar = true;
            // 
            // txtResNewPass
            // 
            txtResNewPass.Font = new Font("Segoe UI", 12F);
            txtResNewPass.Location = new Point(358, 154);
            txtResNewPass.Name = "txtResNewPass";
            txtResNewPass.Size = new Size(205, 29);
            txtResNewPass.TabIndex = 11;
            txtResNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(222, 219);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 10;
            label3.Text = "Confirm Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(247, 157);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 9;
            label2.Text = "New Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(234, 29);
            label1.Name = "label1";
            label1.Size = new Size(328, 32);
            label1.TabIndex = 8;
            label1.Text = "Teleoplex Inventory System";
            // 
            // txtResUser
            // 
            txtResUser.Font = new Font("Segoe UI", 12F);
            txtResUser.Location = new Point(358, 102);
            txtResUser.Name = "txtResUser";
            txtResUser.Size = new Size(205, 29);
            txtResUser.TabIndex = 15;
            // 
            // lblResUser
            // 
            lblResUser.AutoSize = true;
            lblResUser.Font = new Font("Segoe UI", 12F);
            lblResUser.Location = new Point(271, 110);
            lblResUser.Name = "lblResUser";
            lblResUser.Size = new Size(81, 21);
            lblResUser.TabIndex = 14;
            lblResUser.Text = "Username";
            // 
            // ResetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtResUser);
            Controls.Add(lblResUser);
            Controls.Add(btnReset);
            Controls.Add(txtResConfirm);
            Controls.Add(txtResNewPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ResetForm";
            Text = "Reset Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReset;
        private TextBox txtResConfirm;
        private TextBox txtResNewPass;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtResUser;
        private Label lblResUser;
    }
}