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
using ItemDataLibrary.Models;

namespace FormsUI
{
    public partial class LoginForm : Form
    {

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            RegisterForm registerForm = new RegisterForm();

            registerForm.ShowDialog();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetForm resetForm = new ResetForm();


            resetForm.ShowDialog();
        }

        private async void btnLogSub_ClickAsync(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLogName.Text) ||
               string.IsNullOrWhiteSpace(txtLogPass.Text))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            var loginDto = new UserLogin
            {
                UserName = txtLogName.Text,
                Password = txtLogPass.Text
            };

            var response = await _httpClient.PostAsJsonAsync("api/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                MessageBox.Show($"Welcome {user.UserName}!");
            }
            else
            {
                MessageBox.Show("Invalid login.");
            }
        }
    }

}
