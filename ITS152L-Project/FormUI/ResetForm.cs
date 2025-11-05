using ItemDataLibrary.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class ResetForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        private string _verifiedEmail = null;
        private bool _emailVerified = false;

        public ResetForm()
        {
            InitializeComponent();
        }

        private async void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Email Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var response = await _httpClient.GetAsync($"api/user/check-email/{Uri.EscapeDataString(email)}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("This email is not registered in our system.", "Email Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnSendCode.Enabled = false;
            btnSendCode.Text = "Sending...";

            bool sent = EmailService.SendVerificationCode(email);

            if (sent)
            {
                pnlVerification.Visible = true;
                MessageBox.Show("A verification code has been sent to your email.", "Code Sent",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSendCode.Text = "Resend Code";
            }
            else
            {
                MessageBox.Show("Failed to send verification code. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Text = "Send Code";
            }

            btnSendCode.Enabled = true;
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string code = txtVerificationCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter the verification code.", "Code Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (EmailService.VerifyCode(email, code))
            {
                _verifiedEmail = email;
                _emailVerified = true;
                pnlEmailEntry.Visible = false;
                pnlVerification.Visible = false;
                pnlPasswordReset.Visible = true;
                MessageBox.Show("Email verified! You can now reset your password.", "Verification Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid or expired verification code.", "Verification Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!_emailVerified)
            {
                MessageBox.Show("Please verify your email first.", "Verification Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please enter and confirm your new password.", "Password Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Password Mismatch",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginDto = new UserLogin
            {
                UserName = _verifiedEmail,
                Password = txtNewPassword.Text
            };

            var response = await _httpClient.PostAsJsonAsync("api/login/reset", loginDto);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Your password has been reset successfully!", "Reset Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to reset password. Please try again.", "Reset Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}