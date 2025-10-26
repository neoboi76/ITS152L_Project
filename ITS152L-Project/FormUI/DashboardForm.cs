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

        // Controls
 
        public DashboardForm(string userName, string userRole)
        {
            InitializeComponent();
            _currentUserName = userName;
            _currentUserRole = userRole;
            this.Text = "Dashboard - Teleoplex Inventory System";
            this.Size = new Size(1000, 600);
        }

        private Label CreateStatLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 12),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async Task LoadDashboardData()
        {
            try
            {
                // Load inventory statistics
                var items = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/item/getAll");

                if (items != null && items.Any())
                {
                    lblTotalItems.Text = $"Total Items: {items.Count}";

                    double totalValue = items.Sum(i => i.UnitPrice * i.Quantity);
                    lblTotalValue.Text = $"Total Inventory Value: ${totalValue:N2}";

                    int lowStockCount = items.Count(i => i.Quantity < 10);
                    lblLowStock.Text = $"Low Stock Items (< 10 units): {lowStockCount}";

                    var topItem = items.OrderByDescending(i => i.Quantity).FirstOrDefault();
                    lblTopItem.Text = topItem != null
                        ? $"Top Item by Quantity: {topItem.Name} ({topItem.Quantity} units)"
                        : "Top Item by Quantity: N/A";
                }

                // Load recent audit logs
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

                    dgvAuditLog.Columns["Timestamp"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                    dgvAuditLog.Columns["Timestamp"].Width = 150;
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
            InventoryForm inventoryForm = new InventoryForm(_currentUserName, _currentUserRole);
            inventoryForm.Show();
            this.Close();
        }
    }
}

