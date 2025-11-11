/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * (admin) UserManagementForm  class. Contains logic related to
 admin user management
 **/

using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class UserManagementForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7173/") };
        private string _currentUserName;
        private List<UserModel> _allUsers = new List<UserModel>();

        public UserManagementForm(string adminUserName)
        {
            InitializeComponent();
            _currentUserName = adminUserName;
            Text = "User Management - Teleoplex Inventory System";
            Size = new Size(1200, 700);
        }

        private async void UserManagementForm_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                _allUsers = await _httpClient.GetFromJsonAsync<List<UserModel>>("api/user") ?? new List<UserModel>();
                dgvUsers.DataSource = _allUsers.Select(u => new
                {
                    u.Id,
                    u.UserName,
                    u.FirstName,
                    u.LastName,
                    u.Role
                }).ToList();

                if (dgvUsers.Columns.Contains("Id")) dgvUsers.Columns["Id"].Visible = false;
                if (dgvUsers.Columns.Contains("UserName"))
                {
                    dgvUsers.Columns["UserName"].HeaderText = "Email";
                    dgvUsers.Columns["UserName"].Width = 250;
                }
                if (dgvUsers.Columns.Contains("FirstName"))
                {
                    dgvUsers.Columns["FirstName"].HeaderText = "First Name";
                    dgvUsers.Columns["FirstName"].Width = 150;
                }
                if (dgvUsers.Columns.Contains("LastName"))
                {
                    dgvUsers.Columns["LastName"].HeaderText = "Last Name";
                    dgvUsers.Columns["LastName"].Width = 150;
                }
                if (dgvUsers.Columns.Contains("Role")) dgvUsers.Columns["Role"].Width = 100;

                lblUserCount.Text = $"Total Users: {_allUsers.Count}";
                lblAdminCount.Text = $"Admins: {_allUsers.Count(u => u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = (int)selectedRow.Cells["Id"].Value;
            var userName = selectedRow.Cells["UserName"].Value.ToString();

            if (userName.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cannot delete the admin account.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user: {userName}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"api/user/{userId}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUsersAsync();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnViewAuditLog_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to view audit log.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userName = dgvUsers.SelectedRows[0].Cells["UserName"].Value.ToString();
            var auditForm = new AuditLogForm(userName);
            auditForm.ShowDialog();
        }

        private async void BtnToggleAdmin_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = (int)selectedRow.Cells["Id"].Value;
            var userName = selectedRow.Cells["UserName"].Value.ToString();
            var currentRole = selectedRow.Cells["Role"].Value.ToString();

            if (userName.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cannot modify the admin account role.", "Cannot Modify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newRole = currentRole.Equals("Admin", StringComparison.OrdinalIgnoreCase) ? "User" : "Admin";
            var action = newRole == "Admin" ? "grant admin privileges to" : "revoke admin privileges from";

            if (MessageBox.Show($"Are you sure you want to {action} {userName}?", "Confirm Role Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var user = _allUsers.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        user.Role = newRole;
                        var response = await _httpClient.PutAsJsonAsync($"api/user/{userId}/role", user);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"User role updated to {newRole}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsersAsync();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void CmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var filtered = _allUsers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string search = txtSearch.Text.ToLowerInvariant();
                filtered = filtered.Where(u =>
                    (u.UserName ?? "").ToLowerInvariant().Contains(search) ||
                    (u.FirstName ?? "").ToLowerInvariant().Contains(search) ||
                    (u.LastName ?? "").ToLowerInvariant().Contains(search)
                );
            }

            if (cmbRoleFilter.SelectedIndex > 0)
            {
                string roleFilter = cmbRoleFilter.SelectedItem.ToString();
                filtered = filtered.Where(u => u.Role.Equals(roleFilter, StringComparison.OrdinalIgnoreCase));
            }

            dgvUsers.DataSource = filtered.Select(u => new
            {
                u.Id,
                u.UserName,
                u.FirstName,
                u.LastName,
                u.Role
            }).ToList();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadUsersAsync();
            txtSearch.Clear();
            cmbRoleFilter.SelectedIndex = 0;
        }
    }
}
