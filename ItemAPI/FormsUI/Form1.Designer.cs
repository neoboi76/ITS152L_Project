using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using M1.WinForms.Models;

namespace M1.WinForms
{
    public class MainForm : Form
    {
        private readonly HttpClient _http = new() { BaseAddress = new Uri("http://localhost:5000/") };
        private DataGridView dgv;
        private Button btnRefresh, btnAdd, btnEdit, btnDelete;
        private TextBox txtName, txtCode, txtBrand, txtPrice;
        private Label lblName, lblCode, lblBrand, lblPrice;

        public MainForm()
        {
            Text = "Merkado PH - Inventory (WinForms)";
            Width = 900; Height = 600;
            InitializeComponents();
            Load += async (_, __) => await LoadItemsAsync();
        }

        private void InitializeComponents()
        {
            dgv = new DataGridView { ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, Dock = DockStyle.Top, Height = 300, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            Controls.Add(dgv);

            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            lblName = new Label { Text = "Name", Left = 10, Top = 10, Width = 80 };
            txtName = new TextBox { Left = 100, Top = 8, Width = 300 };

            lblCode = new Label { Text = "Code", Left = 10, Top = 40, Width = 80 };
            txtCode = new TextBox { Left = 100, Top = 38, Width = 150 };

            lblBrand = new Label { Text = "Brand", Left = 10, Top = 70, Width = 80 };
            txtBrand = new TextBox { Left = 100, Top = 68, Width = 200 };

            lblPrice = new Label { Text = "Unit Price", Left = 10, Top = 100, Width = 80 };
            txtPrice = new TextBox { Left = 100, Top = 98, Width = 100 };

            btnRefresh = new Button { Text = "Refresh", Left = 420, Top = 8, Width = 100 };
            btnAdd = new Button { Text = "Add", Left = 420, Top = 40, Width = 100 };
            btnEdit = new Button { Text = "Edit", Left = 420, Top = 72, Width = 100 };
            btnDelete = new Button { Text = "Delete", Left = 420, Top = 104, Width = 100 };

            btnRefresh.Click += async (_, __) => await LoadItemsAsync();
            btnAdd.Click += async (_, __) => await AddItemAsync();
            btnEdit.Click += async (_, __) => await EditItemAsync();
            btnDelete.Click += async (_, __) => await DeleteItemAsync();

            panel.Controls.AddRange(new Control[] { lblName, txtName, lblCode, txtCode, lblBrand, txtBrand, lblPrice, txtPrice, btnRefresh, btnAdd, btnEdit, btnDelete });
            Controls.Add(panel);
        }

        private async Task LoadItemsAsync()
        {
            try
            {
                var list = await _http.GetFromJsonAsync<List<Item>>("api/items");
                dgv.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load items: " + ex.Message);
            }
        }

        private Item? SelectedItem()
        {
            if (dgv.CurrentRow?.DataBoundItem is Item it) return it;
            return null;
        }

        private async Task AddItemAsync()
        {
            var item = new Item
            {
                Name = txtName.Text,
                Code = txtCode.Text,
                Brand = txtBrand.Text,
            };
            if (!decimal.TryParse(txtPrice.Text, out var p))
            {
                MessageBox.Show("Invalid price");
                return;
            }
            item.UnitPrice = p;

            try
            {
                var resp = await _http.PostAsJsonAsync("api/items", item);
                if (resp.IsSuccessStatusCode)
                {
                    await LoadItemsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Add failed: " + resp.ReasonPhrase);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async Task EditItemAsync()
        {
            var selected = SelectedItem();
            if (selected == null) { MessageBox.Show("Select an item first"); return; }

            selected.Name = txtName.Text != "" ? txtName.Text : selected.Name;
            selected.Code = txtCode.Text != "" ? txtCode.Text : selected.Code;
            selected.Brand = txtBrand.Text != "" ? txtBrand.Text : selected.Brand;
            if (!string.IsNullOrWhiteSpace(txtPrice.Text) && decimal.TryParse(txtPrice.Text, out var p)) selected.UnitPrice = p;

            try
            {
                var resp = await _http.PutAsJsonAsync($"api/items/{selected.Id}", selected);
                if (resp.IsSuccessStatusCode || resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    await LoadItemsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Update failed: " + resp.ReasonPhrase);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async Task DeleteItemAsync()
        {
            var selected = SelectedItem();
            if (selected == null) { MessageBox.Show("Select an item first"); return; }
            if (MessageBox.Show($"Delete \"{selected.Name}\"?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                var resp = await _http.DeleteAsync($"api/items/{selected.Id}");
                if (resp.IsSuccessStatusCode || resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    await LoadItemsAsync();
                }
                else
                {
                    MessageBox.Show("Delete failed: " + resp.ReasonPhrase);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtBrand.Text = "";
            txtPrice.Text = "";
        }
    }
}
