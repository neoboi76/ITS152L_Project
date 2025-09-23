using Azure;
using ItemDataLibrary.Models;
using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dapper.SqlMapper;

namespace FormsUI
{
    public partial class InventoryForm : Form
    {

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void btnItemNew_Click(object sender, EventArgs e)
        {
            itemModelBindingSource.AddNew();
            ReadOnlyFields(false);
        }

        private void ReadOnlyFields(bool readOnly)
        {
            txtItemName.ReadOnly = readOnly;
            txtItemBrand.ReadOnly = readOnly;
            txtItemCode.ReadOnly = readOnly;
            txtItemPrice.ReadOnly = readOnly;
            txtItemQuantity.ReadOnly = readOnly;
            btnItemNew.Enabled = readOnly;
            btnItemUpdate.Enabled = readOnly;
            btnItemDelete.Enabled = readOnly;
            btnItemCancel.Enabled = !readOnly;
            btnItemSave.Enabled = !readOnly;
        }

        private async void btnItemSave_Click(object sender, EventArgs e)
        {
            ValidateFields();

            var entity = itemModelBindingSource.Current as ItemModel;

            double price;
            int code;
            int quantity;

            if (!double.TryParse(txtItemPrice.Text, out price))
            {
                MessageBox.Show("Invalid price! Please enter a valid number.");
                return;
            }


            if (!int.TryParse(txtItemCode.Text, out code))
            {
                MessageBox.Show("Invalid code! Please enter a valid integer.");
                return;
            }

            if (!int.TryParse(txtItemQuantity.Text, out quantity))
            {
                MessageBox.Show("Invalid quantity! Please enter a valid integer.");
                return;
            }

            /*
            var itemDto = new ItemModel
            {
                Name = txtItemName.Text,
                Brand = txtItemBrand.Text,
                Code = code,
                UnitPrice = price,
                Quantity = quantity

            };*/

            entity.Name = txtItemName.Text;
            entity.Brand = txtItemBrand.Text;
            entity.Code = code;
            entity.UnitPrice = price;
            entity.Quantity = quantity;


            var response = await _httpClient.PostAsJsonAsync("api/item/add", entity);

            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<ItemModel>();
                if (entity != null)
                {
                    MessageBox.Show($"item {item.Code} registered!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReadOnlyFields(true);

                }
            }
            else
            {
                MessageBox.Show("Invalid Entry.");
            }

        }

        private void ValidateFields()
        {
            itemErrorProvider.SetError(txtItemName, string.IsNullOrWhiteSpace(txtItemName.Text) ? txtItemName.Text : "");
            itemErrorProvider.SetError(txtItemBrand, string.IsNullOrWhiteSpace(txtItemBrand.Text) ? txtItemBrand.Text : "");
            itemErrorProvider.SetError(txtItemCode, string.IsNullOrWhiteSpace(txtItemCode.Text) ? txtItemCode.Text : "");
            itemErrorProvider.SetError(txtItemPrice, string.IsNullOrWhiteSpace(txtItemPrice.Text) ? txtItemPrice.Text : "");
            itemErrorProvider.SetError(txtItemQuantity, string.IsNullOrWhiteSpace(txtItemQuantity.Text) ? txtItemQuantity.Text : "");
        }

        private async void InventoryForm_LoadAsync(object sender, EventArgs e)
        {
            ReadOnlyFields(true);
            itemModelBindingSource.DataSource = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/item/getAll");
        }

        private async void btnItemDelete_Click(object sender, EventArgs e)
        {
            var entity = itemModelBindingSource.Current as ItemModel;

            if (entity != null && MessageBox.Show($"Delete {entity.Name}", "Delete Record",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var response = await _httpClient.DeleteAsync($"api/item/{entity.Id}");

                itemModelBindingSource.RemoveCurrent();

            }
            
        }
    }
}
