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
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 12F);
            btnReset.Location = new Point(247, 238);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(131, 31);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset Password";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // txtResConfirm
            // 
            txtResConfirm.Location = new Point(358, 176);
            txtResConfirm.Name = "txtResConfirm";
            txtResConfirm.Size = new Size(205, 23);
            txtResConfirm.TabIndex = 12;
            // 
            // txtResNewPass
            // 
            txtResNewPass.Font = new Font("Segoe UI", 12F);
            txtResNewPass.Location = new Point(358, 111);
            txtResNewPass.Name = "txtResNewPass";
            txtResNewPass.Size = new Size(205, 29);
            txtResNewPass.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(222, 176);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 10;
            label3.Text = "Confirm Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(247, 114);
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
            label1.Size = new Size(329, 32);
            label1.TabIndex = 8;
            label1.Text = "Multiplex Inventory System";
            // 
            // ResetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(txtResConfirm);
            Controls.Add(txtResNewPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ResetForm";
            Text = "ResetPassword";
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
    }
}