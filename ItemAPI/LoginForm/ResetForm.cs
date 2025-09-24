using ItemDataLibrary.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class ResetForm : Form
    {

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public ResetForm()
        {
            InitializeComponent();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResUser.Text) ||
               string.IsNullOrWhiteSpace(txtResNewPass.Text) || string.IsNullOrWhiteSpace(txtResConfirm.Text))
            {
                MessageBox.Show("Username and Passwords are required.", "Reset Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (txtResNewPass.Text != txtResConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.", "Reset Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            var loginDto = new UserLogin
            {
                UserName = txtResUser.Text,
                Password = txtResConfirm.Text

            };

            var response = await _httpClient.PostAsJsonAsync("api/login/reset", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                MessageBox.Show("Your password has been reset", "Reset Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show($"{txtResUser.Text} does not exist in the database", "Reset Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
