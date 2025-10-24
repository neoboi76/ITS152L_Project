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

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Inventory form UI

namespace FormsUI
{
    public partial class InventoryForm : Form
    {
        //Facilitates http requests from front-end to back-end
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public InventoryForm()
        {
            InitializeComponent();
        }

        //Creates new item
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

        //Saves new item in the database
        private async void btnItemSave_Click(object sender, EventArgs e)
        {
            ValidateFields();

            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
              string.IsNullOrWhiteSpace(txtItemBrand.Text) ||
              string.IsNullOrWhiteSpace(txtItemCode.Text) ||
              string.IsNullOrWhiteSpace(txtItemPrice.Text) ||
              string.IsNullOrWhiteSpace(txtItemQuantity.Text))
            {
                MessageBox.Show("All fields are required.", "Process failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            var entity = itemModelBindingSource.Current as ItemModel;

            double price;
            int code;
            int quantity;

            if (!double.TryParse(txtItemPrice.Text, out price))
            {
                MessageBox.Show("Invalid price! Please enter a valid number.", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!int.TryParse(txtItemCode.Text, out code))
            {
                MessageBox.Show("Invalid code! Please enter a valid integer.", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtItemQuantity.Text, out quantity))
            {
                MessageBox.Show("Invalid quantity! Please enter a valid integer.", "Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entity.Name = txtItemName.Text;
            entity.Brand = txtItemBrand.Text;
            entity.Code = code;
            entity.UnitPrice = price;
            entity.Quantity = quantity;


            var response = await _httpClient.PostAsJsonAsync("api/item/add", entity);

            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<ItemModel>();
                if (item != null)
                {
                    MessageBox.Show($"Item {item.Code} registered!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReadOnlyFields(true);
                    itemModelBindingSource.DataSource = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/item/getAll");

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

        //Deletes an item from the database
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

        //Updates item in the database
        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            ReadOnlyFields(false);
        }

        //Cancels update operations
        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            ReadOnlyFields(true);
            itemModelBindingSource.RemoveCurrent();
        }

    }
}
