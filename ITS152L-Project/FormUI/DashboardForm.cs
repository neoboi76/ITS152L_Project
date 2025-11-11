/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * (admin) DashboardForm class. Main class for dealing with
 * DashboardForm related operations
 **/


using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class DashboardForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        private string _currentUserName;
        private string _currentUserRole;

        public DashboardForm(string userName, string userRole)
        {
            InitializeComponent();
            _currentUserName = userName;
            _currentUserRole = userRole;
            this.Text = "Dashboard - Teleoplex Inventory System";
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async Task LoadDashboardData()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/item/getAll");

                if (items != null && items.Any())
                {
                    lblTotalItemsValue.Text = items.Count.ToString();

                    double totalValue = items.Sum(i => i.UnitPrice * i.Quantity);
                    lblTotalValueValue.Text = $"${totalValue:N2}";

                    int lowStockCount = items.Count(i => i.Quantity < 10);
                    lblLowStockValue.Text = lowStockCount.ToString();

                    var topItem = items.OrderByDescending(i => i.Quantity).FirstOrDefault();
                    if (topItem != null)
                    {
                        string displayName = topItem.Name.Length > 20
                            ? topItem.Name.Substring(0, 20) + "..."
                            : topItem.Name;
                        lblTopItemValue.Text = displayName;
                    }
                    else
                    {
                        lblTopItemValue.Text = "N/A";
                    }
                }
                else
                {
                    lblTotalItemsValue.Text = "0";
                    lblTotalValueValue.Text = "$0.00";
                    lblLowStockValue.Text = "0";
                    lblTopItemValue.Text = "N/A";
                }

                var logs = await _httpClient.GetFromJsonAsync<List<AuditLog>>("api/auditlog/recent/20");

                if (logs != null)
                {
                    dgvAuditLog.DataSource = logs.Select(log => new
                    {
                        log.Timestamp,
                        log.UserName,
                        log.Action,
                        log.Details
                    }).ToList();

                    if (dgvAuditLog.Columns["Timestamp"] != null)
                    {
                        dgvAuditLog.Columns["Timestamp"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                        dgvAuditLog.Columns["Timestamp"].Width = 130;
                        dgvAuditLog.Columns["Timestamp"].HeaderText = "Date & Time";
                    }
                    if (dgvAuditLog.Columns["UserName"] != null)
                    {
                        dgvAuditLog.Columns["UserName"].Width = 150;
                        dgvAuditLog.Columns["UserName"].HeaderText = "User";
                    }
                    if (dgvAuditLog.Columns["Action"] != null)
                    {
                        dgvAuditLog.Columns["Action"].Width = 100;
                    }
                    if (dgvAuditLog.Columns["Details"] != null)
                    {
                        dgvAuditLog.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardData();
            MessageBox.Show("Dashboard refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnBackToInventory_Click(object sender, EventArgs e)
        {
            var inventoryForm = new InventoryForm(_currentUserName, _currentUserRole);
            inventoryForm.Show();
            this.Close();
        }
    }
}