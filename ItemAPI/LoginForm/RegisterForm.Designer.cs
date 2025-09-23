namespace FormsUI
{
    partial class RegisterForm
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtRegUser = new TextBox();
            txtRegFirst = new TextBox();
            txtRegLast = new TextBox();
            txtRegNewPass = new TextBox();
            txtRegConfirm = new TextBox();
            btnRegSub = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(242, 30);
            label1.Name = "label1";
            label1.Size = new Size(329, 32);
            label1.TabIndex = 1;
            label1.Text = "Multiplex Inventory System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(225, 104);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(225, 159);
            label3.Name = "label3";
            label3.Size = new Size(86, 21);
            label3.TabIndex = 3;
            label3.Text = "First Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(227, 210);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 4;
            label4.Text = "Last Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(181, 258);
            label5.Name = "label5";
            label5.Size = new Size(125, 21);
            label5.TabIndex = 5;
            label5.Text = "Create Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(169, 311);
            label6.Name = "label6";
            label6.Size = new Size(137, 21);
            label6.TabIndex = 6;
            label6.Text = "Confirm Password";
            // 
            // txtRegUser
            // 
            txtRegUser.Font = new Font("Segoe UI", 12F);
            txtRegUser.Location = new Point(312, 104);
            txtRegUser.Name = "txtRegUser";
            txtRegUser.Size = new Size(243, 29);
            txtRegUser.TabIndex = 7;
            // 
            // txtRegFirst
            // 
            txtRegFirst.Font = new Font("Segoe UI", 12F);
            txtRegFirst.Location = new Point(312, 159);
            txtRegFirst.Name = "txtRegFirst";
            txtRegFirst.Size = new Size(243, 29);
            txtRegFirst.TabIndex = 8;
            // 
            // txtRegLast
            // 
            txtRegLast.Font = new Font("Segoe UI", 12F);
            txtRegLast.Location = new Point(312, 207);
            txtRegLast.Name = "txtRegLast";
            txtRegLast.Size = new Size(243, 29);
            txtRegLast.TabIndex = 9;
            // 
            // txtRegNewPass
            // 
            txtRegNewPass.Font = new Font("Segoe UI", 12F);
            txtRegNewPass.Location = new Point(312, 258);
            txtRegNewPass.Name = "txtRegNewPass";
            txtRegNewPass.Size = new Size(243, 29);
            txtRegNewPass.TabIndex = 10;
            txtRegNewPass.UseSystemPasswordChar = true;
            // 
            // txtRegConfirm
            // 
            txtRegConfirm.Font = new Font("Segoe UI", 12F);
            txtRegConfirm.Location = new Point(312, 303);
            txtRegConfirm.Name = "txtRegConfirm";
            txtRegConfirm.Size = new Size(243, 29);
            txtRegConfirm.TabIndex = 11;
            txtRegConfirm.UseSystemPasswordChar = true;
            // 
            // btnRegSub
            // 
            btnRegSub.Font = new Font("Segoe UI", 12F);
            btnRegSub.Location = new Point(367, 352);
            btnRegSub.Name = "btnRegSub";
            btnRegSub.Size = new Size(131, 31);
            btnRegSub.TabIndex = 12;
            btnRegSub.Text = "Submit";
            btnRegSub.UseVisualStyleBackColor = true;
            btnRegSub.Click += btnRegSub_ClickAsync;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegSub);
            Controls.Add(txtRegConfirm);
            Controls.Add(txtRegNewPass);
            Controls.Add(txtRegLast);
            Controls.Add(txtRegFirst);
            Controls.Add(txtRegUser);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtRegUser;
        private TextBox txtRegFirst;
        private TextBox txtRegLast;
        private TextBox txtRegNewPass;
        private TextBox txtRegConfirm;
        private Button btnRegSub;
    }
}