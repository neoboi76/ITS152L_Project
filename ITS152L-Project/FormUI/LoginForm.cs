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

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Log in form UI

namespace FormsUI
{
    public partial class LoginForm : Form
    {

        //Facilitates http requests from front-ebd to back-end
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

        //Facilitates log in mechanism
        private async void btnLogSub_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogName.Text) ||
               string.IsNullOrWhiteSpace(txtLogPass.Text))
            {
                MessageBox.Show("Username and Password are required.", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginDto = new UserLogin
            {
                UserName = txtLogName.Text,
                Password = txtLogPass.Text
            };

            var response = await _httpClient.PostAsJsonAsync("api/login/log", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                if (user != null)
                {
                    // Start session
                    SessionManager.StartSession(user.Id, user.UserName, user.Role);

                    // Subscribe to session expired event
                    SessionManager.SessionExpired += OnSessionExpired;

                    MessageBox.Show($"Welcome {user.UserName}!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InventoryForm inventoryForm = new InventoryForm(user.UserName, user.Role);
                    inventoryForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSessionExpired(object sender, EventArgs e)
        {
            // Must invoke on UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleSessionExpired()));
            }
            else
            {
                HandleSessionExpired();
            }


            MessageBox.Show("Your session has expired due to inactivity. Please login again.",
                "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Close all open forms and show login
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is not LoginForm)
                {
                    form.Close();
                }
            }

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void HandleSessionExpired()
        {
            MessageBox.Show("Your session has expired due to inactivity. Please login again.",
                "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is not LoginForm)
                    form.Close();
            }

            new LoginForm().Show();
        }

    }

}
