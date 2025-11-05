using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Developed by: 
    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol
*/

// Inventory form code-behind
namespace FormsUI
{
    public partial class InventoryForm : Form
    {
        // Facilitates http requests from front-end to back-end
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        private string _currentUserRole;
        private string _currentUserName;

        private List<ItemModel> _allItems = new List<ItemModel>();

        public InventoryForm(string userName, string userRole)
        {
            // assign user info BEFORE InitializeComponent so labels/data-binding that use them are safe
            _currentUserName = userName ?? string.Empty;
            _currentUserRole = userRole ?? string.Empty;

            InitializeComponent();

            // Wire events that the designer might not have wired
            this.Load += InventoryForm_LoadAsync; // async void handler already present in your code
            this.FormClosed += InventoryForm_FormClosed;

            var activityTracker = new ActivityTracker(this);

            // Subscribe to session expired
            SessionManager.SessionExpired += OnSessionExpired;

            InitializeMenuStrip();
        }

        private void InventoryForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Unsubscribe from static events to avoid handlers running after disposal
            SessionManager.SessionExpired -= OnSessionExpired;
        }

        private void OnSessionExpired(object? sender, EventArgs e)
        {
            // Protect against disposed form
            if (this.IsDisposed || this.Disposing) return;

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => OnSessionExpired(sender, e)));
                }
                catch (ObjectDisposedException)
                {
                    // form is being disposed, ignore
                }
                return;
            }

            MessageBox.Show("Your session has expired due to inactivity. Please login again.",
                "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Close other forms safely and show login form
            try
            {
                foreach (Form open in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (open is not LoginForm)
                        open.Close();
                }
            }
            catch
            {
                // swallow exceptions from closing forms to avoid crashing in session expiration path
            }

            var loginForm = new LoginForm();
            loginForm.Show();
            try
            {
                this.Close();
            }
            catch
            {
                // ignore closing exceptions
            }
        }

        // Update logout
        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.EndSession();

                var loginForm = new LoginForm();
                loginForm.Show();

                // Unsubscribe before closing
                SessionManager.SessionExpired -= OnSessionExpired;

                this.Close();
            }
        }

        // Creates new item
        private void btnItemNew_Click(object sender, EventArgs e)
        {
            // Ensure binding source exists
            if (itemModelBindingSource == null)
            {
                itemModelBindingSource = new BindingSource(components);
            }

            itemModelBindingSource.AddNew();
            ReadOnlyFields(false);
        }

        private void ReadOnlyFields(bool readOnly)
        {
            if (txtItemName != null) txtItemName.ReadOnly = readOnly;
            if (txtItemBrand != null) txtItemBrand.ReadOnly = readOnly;
            if (txtItemCode != null) txtItemCode.ReadOnly = readOnly;
            if (txtItemPrice != null) txtItemPrice.ReadOnly = readOnly;
            if (txtItemQuantity != null) txtItemQuantity.ReadOnly = readOnly;

            if (btnItemNew != null) btnItemNew.Enabled = readOnly;
            if (btnItemUpdate != null) btnItemUpdate.Enabled = readOnly;
            if (btnItemDelete != null) btnItemDelete.Enabled = readOnly;
            if (btnItemCancel != null) btnItemCancel.Enabled = !readOnly;
            if (btnItemSave != null) btnItemSave.Enabled = !readOnly;
        }

        // Saves new item in the database
        private async void btnItemSave_Click(object sender, EventArgs e)
        {
            ValidateFields();

            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
              string.IsNullOrWhiteSpace(txtItemBrand.Text) ||
              string.IsNullOrWhiteSpace(txtItemCode.Text) ||
              string.IsNullOrWhiteSpace(txtItemPrice.Text) ||
              string.IsNullOrWhiteSpace(txtItemQuantity.Text))
            {
                MessageBox.Show("All fields are required.", "Process failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var entity = itemModelBindingSource?.Current as ItemModel;
            if (entity == null)
            {
                MessageBox.Show("No item selected or binding source not initialized.", "Process failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtItemPrice.Text, out double price) ||
                !int.TryParse(txtItemCode.Text, out int code) ||
                !int.TryParse(txtItemQuantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid input! Please check your numbers.",
                    "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update entity
            entity.Name = txtItemName.Text;
            entity.Brand = txtItemBrand.Text;
            entity.Code = code;
            entity.UnitPrice = price;
            entity.Quantity = quantity;

            // Pass username as query parameter for audit trail
            var userQuery = Uri.EscapeDataString(_currentUserName ?? string.Empty);
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    $"api/item/add?userName={userQuery}", entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to call API: {ex.Message}", "Network Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<ItemModel>();
                if (item != null)
                {
                    MessageBox.Show($"Item {item.Code} registered!", "Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReadOnlyFields(true);

                    // Refresh list
                    await LoadItemsAsync();
                }
            }
            else
            {
                MessageBox.Show("Invalid Entry or server returned an error.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateFields()
        {
            // ensure itemErrorProvider is instantiated
            if (itemErrorProvider == null)
            {
                itemErrorProvider = new ErrorProvider(components);
            }

            itemErrorProvider.SetError(txtItemName, string.IsNullOrWhiteSpace(txtItemName.Text) ? "Required" : "");
            itemErrorProvider.SetError(txtItemBrand, string.IsNullOrWhiteSpace(txtItemBrand.Text) ? "Required" : "");
            itemErrorProvider.SetError(txtItemCode, string.IsNullOrWhiteSpace(txtItemCode.Text) ? "Required" : "");
            itemErrorProvider.SetError(txtItemPrice, string.IsNullOrWhiteSpace(txtItemPrice.Text) ? "Required" : "");
            itemErrorProvider.SetError(txtItemQuantity, string.IsNullOrWhiteSpace(txtItemQuantity.Text) ? "Required" : "");
        }

        private void ApplyRolePermissions()
        {
            bool isAdmin = string.Equals(_currentUserRole, "ADMIN", StringComparison.OrdinalIgnoreCase);

            // Show/hide buttons based on role
            if (btnItemNew != null) btnItemNew.Visible = isAdmin;
            if (btnItemUpdate != null) btnItemUpdate.Visible = isAdmin;
            if (btnItemDelete != null) btnItemDelete.Visible = isAdmin;
            if (btnItemSave != null) btnItemSave.Visible = isAdmin;
            if (btnItemCancel != null) btnItemCancel.Visible = isAdmin;

            // Always readonly for users
            if (!isAdmin)
            {
                if (txtItemName != null) txtItemName.ReadOnly = true;
                if (txtItemCode != null) txtItemCode.ReadOnly = true;
                if (txtItemBrand != null) txtItemBrand.ReadOnly = true;
                if (txtItemPrice != null) txtItemPrice.ReadOnly = true;
                if (txtItemQuantity != null) txtItemQuantity.ReadOnly = true;
            }

            // Update title to show role
            this.Text = $"Teleoplex Inventory System - {_currentUserName} ({_currentUserRole})";
        }

        private async void InventoryForm_LoadAsync(object? sender, EventArgs e)
        {
            ReadOnlyFields(true);

            try
            {
                await LoadItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load items: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyRolePermissions();

            // initialize search/sort UI elements (only if not already added)
            try
            {
                InitializeSearchAndSort();
            }
            catch
            {
                // ignore if already initialized
            }
        }

        private async Task LoadItemsAsync()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/item/getAll");
                _allItems = items ?? new List<ItemModel>();
                if (itemModelBindingSource != null)
                    itemModelBindingSource.DataSource = _allItems;
            }
            catch (Exception ex)
            {
                // bubble up so caller can show message
                throw new InvalidOperationException("Error fetching items from API", ex);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearchAndSort();
        }

        private void CmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearchAndSort();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadItemsAsync();
                txtSearch?.Clear();
                if (cmbSortBy != null) cmbSortBy.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Refresh failed: {ex.Message}", "Refresh Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userManagementForm = new UserManagementForm(_currentUserName);
            userManagementForm.ShowDialog();
        }

        private void ApplySearchAndSort()
        {
            var filteredItems = _allItems.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtSearch?.Text))
            {
                string searchTerm = txtSearch.Text.ToLowerInvariant();
                filteredItems = filteredItems.Where(item =>
                    (item.Name ?? string.Empty).ToLowerInvariant().Contains(searchTerm) ||
                    (item.Brand ?? string.Empty).ToLowerInvariant().Contains(searchTerm) ||
                    item.Code.ToString().Contains(searchTerm) ||
                    item.Id.ToString().Contains(searchTerm)
                );
            }

            if (cmbSortBy != null && cmbSortBy.SelectedIndex >= 0)
            {
                var sel = cmbSortBy.SelectedItem?.ToString() ?? string.Empty;
                filteredItems = sel switch
                {
                    "Name (A-Z)" => filteredItems.OrderBy(i => i.Name),
                    "Name (Z-A)" => filteredItems.OrderByDescending(i => i.Name),
                    "ID (Low-High)" => filteredItems.OrderBy(i => i.Id),
                    "ID (High-Low)" => filteredItems.OrderByDescending(i => i.Id),
                    "Code (Low-High)" => filteredItems.OrderBy(i => i.Code),
                    "Code (High-Low)" => filteredItems.OrderByDescending(i => i.Code),
                    "Brand (A-Z)" => filteredItems.OrderBy(i => i.Brand),
                    "Brand (Z-A)" => filteredItems.OrderByDescending(i => i.Brand),
                    "Price (Low-High)" => filteredItems.OrderBy(i => i.UnitPrice),
                    "Price (High-Low)" => filteredItems.OrderByDescending(i => i.UnitPrice),
                    "Quantity (Low-High)" => filteredItems.OrderBy(i => i.Quantity),
                    "Quantity (High-Low)" => filteredItems.OrderByDescending(i => i.Quantity),
                    _ => filteredItems
                };
            }

            if (itemModelBindingSource != null)
                itemModelBindingSource.DataSource = filteredItems.ToList();
        }


        // Deletes an item from the database
        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            var entity = itemModelBindingSource?.Current as ItemModel;

            if (entity != null && MessageBox.Show($"Delete {entity.Name}", "Delete Record",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var userQuery = Uri.EscapeDataString(_currentUserName ?? string.Empty);

                HttpResponseMessage response;
                try
                {
                    response = await _httpClient.DeleteAsync($"api/item/{entity.Id}?userName={userQuery}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to call API: {ex.Message}", "Network Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        itemModelBindingSource.RemoveCurrent();
                    }
                    catch { /* ignore */ }

                    MessageBox.Show("Item deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete failed on server.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Updates item in the database (makes fields editable)
        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            ReadOnlyFields(false);
        }

        // Cancels update operations
        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            ReadOnlyFields(true);

            // If new item was being added, cancel the add
            try
            {
                itemModelBindingSource?.CancelEdit();
            }
            catch
            {
                // ignore
            }
        }

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = $"Inventory_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToCSV(saveFileDialog.FileName);
                        MessageBox.Show("Export successful!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show("Do you want to open the exported file?",
                            "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting file: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToCSV(string filePath)
        {
            var sb = new StringBuilder();

            // Add headers
            sb.AppendLine("Id,Name,Code,Brand,Unit Price,Quantity");

            // Get current filtered/sorted items from DataGridView
            var items = itemModelBindingSource?.DataSource as List<ItemModel>;

            if (items != null)
            {
                foreach (var item in items)
                {
                    sb.AppendLine($"{item.Id}," +
                                 $"\"{item.Name}\"," +
                                 $"{item.Code}," +
                                 $"\"{item.Brand}\"," +
                                 $"{item.UnitPrice}," +
                                 $"{item.Quantity}");
                }
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private void DashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm(_currentUserName, _currentUserRole);
            dashboardForm.Show();
            this.Hide();
        }

        private void AuditLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var auditForm = new AuditLogForm(_currentUserName);
            auditForm.ShowDialog();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var items = GetCurrentItems();
                if (items.Count == 0)
                {
                    MessageBox.Show("No items to print.", "Print",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var printer = new InventoryPrinter(items, "Inventory Report", _currentUserName);
                printer.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var items = GetCurrentItems();
                if (items.Count == 0)
                {
                    MessageBox.Show("No items to preview.", "Print Preview",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var printer = new InventoryPrinter(items, "Inventory Report", _currentUserName);
                printer.PrintPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing preview: {ex.Message}", "Preview Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var items = GetCurrentItems();
                if (items.Count == 0)
                {
                    MessageBox.Show("No items to save.", "Save PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.FileName = $"Inventory_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    saveFileDialog.Title = "Save Inventory Report as PDF";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var printer = new InventoryPrinter(items, "Inventory Report", _currentUserName);
                        printer.SaveAsPDF(saveFileDialog.FileName);

                        if (MessageBox.Show("PDF saved successfully!\n\nDo you want to open it?",
                            "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving PDF: {ex.Message}", "PDF Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to get current filtered/sorted items
        private List<ItemModel> GetCurrentItems()
        {
            var dataSource = itemModelBindingSource?.DataSource as List<ItemModel>;
            return dataSource ?? new List<ItemModel>();
        }



    }
}
