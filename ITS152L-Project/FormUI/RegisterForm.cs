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

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Register form UI

namespace FormsUI
{
    public partial class RegisterForm : Form
    {
        //Facilitates http requests from front-ebd to back-end
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };
        public RegisterForm()
        {
            InitializeComponent();
        }

        //Facilitates register mechanism
        private async void btnRegSub_ClickAsync(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtRegFirst.Text) ||
                string.IsNullOrWhiteSpace(txtRegLast.Text) ||
                string.IsNullOrWhiteSpace(txtRegUser.Text) ||
                string.IsNullOrWhiteSpace(txtRegNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtRegConfirm.Text))
            {
                MessageBox.Show("All fields are required.", "Registration failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (txtRegNewPass.Text != txtRegConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.", "Registration failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
                MessageBox.Show($"Account created for {user.UserName}!", "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                // optionally close register form & show login form
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Registration failed: {error}", "Registration failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }


    }
}
