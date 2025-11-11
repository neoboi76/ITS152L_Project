/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * RegisterForm class. Main class for dealing with
 * RegisterForm related operations
 **/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using ItemDataLibrary.Models;
using ItemDataLibrary.Security;

namespace FormsUI
{
    public partial class RegisterForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegSub_ClickAsync(object sender, EventArgs e)
        {
            btnRegSub.Enabled = false;
            btnRegSub.Text = "Creating Account...";

            try
            {
                if (string.IsNullOrWhiteSpace(txtRegFirst.Text) ||
                    string.IsNullOrWhiteSpace(txtRegLast.Text) ||
                    string.IsNullOrWhiteSpace(txtRegUser.Text) ||
                    string.IsNullOrWhiteSpace(txtRegNewPass.Text) ||
                    string.IsNullOrWhiteSpace(txtRegConfirm.Text))
                {
                    MessageBox.Show("All fields are required.", "Registration Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = txtRegUser.Text.Trim().ToLowerInvariant();

                if (email == "admin" || email == "administrator" || email == "root")
                {
                    MessageBox.Show("This username is reserved. Please choose a different username.",
                        "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool emailExists = await CheckEmailExists(email);
                if (emailExists)
                {
                    MessageBox.Show(
                        $"An account with the email '{email}' already exists.\n\n" +
                        "Please use a different email address or try logging in.",
                        "Email Already Registered",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!PasswordHasher.IsPasswordValid(txtRegNewPass.Text, out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Invalid Password",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtRegNewPass.Text != txtRegConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Registration Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newUser = new UserModel
                {
                    UserName = email,
                    FirstName = txtRegFirst.Text.Trim(),
                    LastName = txtRegLast.Text.Trim(),
                    Password = txtRegNewPass.Text,
                    Role = "User"
                };

                var response = await _httpClient.PostAsJsonAsync("api/user", newUser);

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<UserModel>();
                    MessageBox.Show(
                        $"✓ Account created successfully for {user.UserName}!\n\n" +
                        "You can now log in with your credentials.",
                        "Registration Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    if (error.Contains("duplicate") || error.Contains("already exists"))
                    {
                        MessageBox.Show(
                            "This email address is already registered.\n\n" +
                            "Please use a different email or try logging in.",
                            "Email Already Exists",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Registration failed: {error}\n\n" +
                            "Please try again or contact support if the problem persists.",
                            "Registration Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(
                    "Unable to connect to the server.\n\n" +
                    "Please check your internet connection and try again.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An unexpected error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegSub.Enabled = true;
                btnRegSub.Text = "Sign Up";
            }
        }

        private async Task<bool> CheckEmailExists(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/user/check-email/{Uri.EscapeDataString(email)}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
                    RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void UpdatePasswordStrength()
        {
            string password = txtRegNewPass.Text;
            int strength = 0;

            if (password.Length >= 8) strength += 20;
            if (password.Length >= 12) strength += 20;
            if (password.Any(char.IsUpper)) strength += 20;
            if (password.Any(char.IsLower)) strength += 20;
            if (password.Any(char.IsDigit)) strength += 10;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) strength += 10;

            pbPasswordStrength.Value = Math.Min(strength, 100);

            if (strength < 50)
            {
                pbPasswordStrength.ForeColor = Color.Red;
                lblPasswordStrength.Text = "Password Strength: Weak";
                lblPasswordStrength.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (strength < 80)
            {
                pbPasswordStrength.ForeColor = Color.Orange;
                lblPasswordStrength.Text = "Password Strength: Medium";
                lblPasswordStrength.ForeColor = Color.FromArgb(234, 179, 8);
            }
            else
            {
                pbPasswordStrength.ForeColor = Color.Green;
                lblPasswordStrength.Text = "Password Strength: Strong";
                lblPasswordStrength.ForeColor = Color.FromArgb(34, 197, 94);
            }
        }
    }
}
