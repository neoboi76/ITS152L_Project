using ItemDataLibrary.Models;
using ITS152L_Project.Services.Implementations;
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

        private int _verifiedUserId = 0;
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

            try
            {
                btnSendCode.Enabled = false;
                btnSendCode.Text = "Sending...";

                // Check if user exists and get user object
                var response = await _httpClient.GetAsync($"api/passwordreset/check-email/{Uri.EscapeDataString(email)}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("This email is not registered in our system.", "Email Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                if (user == null)
                {
                    MessageBox.Show("Unable to retrieve user information.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Request token generation and email sending
                var sendResponse = await _httpClient.PostAsync(
                    $"api/passwordreset/send-code/{user.Id}", null);

                if (sendResponse.IsSuccessStatusCode)
                {
                    _verifiedUserId = user.Id;
                    pnlVerification.Visible = true;
                    MessageBox.Show(
                        "A verification code has been sent to your email.\n\n" +
                        "⚠️ Security Notice:\n" +
                        "• The code will expire in 10 minutes\n" +
                        "• The code can only be used once\n" +
                        "• Never share this code with anyone",
                        "Code Sent",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnSendCode.Text = "Resend Code";
                }
                else
                {
                    var error = await sendResponse.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to send verification code: {error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSendCode.Text = "Send Code";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Text = "Send Code";
            }
            finally
            {
                btnSendCode.Enabled = true;
            }
        }

        private async void btnVerifyCode_Click(object sender, EventArgs e)
        {
            string code = txtVerificationCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter the verification code.", "Code Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code.Length != 6 || !code.All(char.IsDigit))
            {
                MessageBox.Show("Verification code must be exactly 6 digits.", "Invalid Format",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_verifiedUserId == 0)
            {
                MessageBox.Show("Please request a verification code first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnVerifyCode.Enabled = false;
                btnVerifyCode.Text = "Verifying...";

                var verifyRequest = new
                {
                    UserId = _verifiedUserId,
                    Token = code
                };

                var response = await _httpClient.PostAsJsonAsync("api/passwordreset/verify-code", verifyRequest);

                if (response.IsSuccessStatusCode)
                {
                    _emailVerified = true;
                    pnlEmailEntry.Visible = false;
                    pnlVerification.Visible = false;
                    pnlPasswordReset.Visible = true;
                    MessageBox.Show(
                        "✓ Email verified successfully!\n\n" +
                        "You can now reset your password.\n" +
                        "Note: The verification code has been marked as used.",
                        "Verification Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        "Verification failed. The code may be:\n\n" +
                        "• Invalid or incorrect\n" +
                        "• Already used\n" +
                        "• Expired (older than 10 minutes)\n\n" +
                        "Please request a new code if needed.",
                        "Verification Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during verification: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnVerifyCode.Enabled = true;
                btnVerifyCode.Text = "Verify Code";
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

            try
            {
                btnResetPassword.Enabled = false;
                btnResetPassword.Text = "Resetting...";

                var resetRequest = new
                {
                    UserId = _verifiedUserId,
                    NewPassword = txtNewPassword.Text
                };

                var response = await _httpClient.PostAsJsonAsync("api/passwordreset/reset-password", resetRequest);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "✓ Your password has been reset successfully!\n\n" +
                        "You can now login with your new password.",
                        "Reset Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to reset password: {error}", "Reset Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnResetPassword.Enabled = true;
                btnResetPassword.Text = "Reset Password";
            }
        }
    }
}