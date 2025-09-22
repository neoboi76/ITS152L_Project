using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using ItemDataLibrary.Models; 

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
                MessageBox.Show("All fields are required.");
                return;
            }

            if (txtRegNewPass.Text != txtRegConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            var newUser = new UserModel
            {
                UserName = txtRegUser.Text,
                FirstName = txtRegFirst.Text,
                LastName = txtRegLast.Text,
                Password = txtRegNewPass.Text
            };

            var response = await _httpClient.PostAsJsonAsync("api/user", newUser);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                MessageBox.Show($"Account created for {user.UserName}!");

                // optionally close register form & show login form
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Registration failed: {error}");
            }
        }
    }
}
