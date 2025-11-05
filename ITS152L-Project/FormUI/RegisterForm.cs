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
            if (string.IsNullOrWhiteSpace(txtRegFirst.Text) ||
                string.IsNullOrWhiteSpace(txtRegLast.Text) ||
                string.IsNullOrWhiteSpace(txtRegUser.Text) ||
                string.IsNullOrWhiteSpace(txtRegNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtRegConfirm.Text))
            {
                MessageBox.Show("All fields are required.", "Registration failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtRegUser.Text.ToLower() == "admin")
            {
                MessageBox.Show("This username is reserved. Please choose a different username.",
                    "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtRegUser.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Passwords do not match.", "Registration failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newUser = new UserModel
            {
                UserName = txtRegUser.Text,
                FirstName = txtRegFirst.Text,
                LastName = txtRegLast.Text,
                Password = txtRegNewPass.Text,
                Role = "User"
            };

            var response = await _httpClient.PostAsJsonAsync("api/user", newUser);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                MessageBox.Show($"Account created for {user.UserName}!", "Registration Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Registration failed: {error}", "Registration failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
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
            }
            else if (strength < 80)
            {
                pbPasswordStrength.ForeColor = Color.Orange;
                lblPasswordStrength.Text = "Password Strength: Medium";
            }
            else
            {
                pbPasswordStrength.ForeColor = Color.Green;
                lblPasswordStrength.Text = "Password Strength: Strong";
            }
        }
    }
}