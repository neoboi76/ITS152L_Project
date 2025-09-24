namespace FormsUI
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            itemModelBindingSource = new BindingSource(components);
            itemModelBindingSource1 = new BindingSource(components);
            label1 = new Label();
            lblItemName = new Label();
            lblItemCode = new Label();
            lblItemBrand = new Label();
            lblItemPrice = new Label();
            lblItemQuantity = new Label();
            txtItemName = new TextBox();
            txtItemCode = new TextBox();
            txtItemBrand = new TextBox();
            txtItemPrice = new TextBox();
            txtItemQuantity = new TextBox();
            btnItemNew = new Button();
            btnItemDelete = new Button();
            btnItemUpdate = new Button();
            groupBox1 = new GroupBox();
            btnItemCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnItemSave = new Button();
            itemErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemModelBindingSource1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, brandDataGridViewTextBoxColumn, unitPriceDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn });
            dataGridView1.DataSource = itemModelBindingSource;
            dataGridView1.Dock = DockStyle.Right;
            dataGridView1.Location = new Point(370, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(525, 450);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            codeDataGridViewTextBoxColumn.HeaderText = "Code";
            codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            codeDataGridViewTextBoxColumn.ReadOnly = true;
            codeDataGridViewTextBoxColumn.Width = 75;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            brandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            unitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemModelBindingSource
            // 
            itemModelBindingSource.DataSource = typeof(ItemDataLibrary.Models.ItemModel);
            // 
            // itemModelBindingSource1
            // 
            itemModelBindingSource1.DataSource = typeof(ItemDataLibrary.Models.ItemModel);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(91, 19);
            label1.Name = "label1";
            label1.Size = new Size(168, 30);
            label1.TabIndex = 1;
            label1.Text = "Item Dashboard";
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI", 12F);
            lblItemName.Location = new Point(12, 64);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(87, 21);
            lblItemName.TabIndex = 2;
            lblItemName.Text = "Item Name";
            // 
            // lblItemCode
            // 
            lblItemCode.AutoSize = true;
            lblItemCode.Font = new Font("Segoe UI", 12F);
            lblItemCode.Location = new Point(12, 111);
            lblItemCode.Name = "lblItemCode";
            lblItemCode.Size = new Size(81, 21);
            lblItemCode.TabIndex = 3;
            lblItemCode.Text = "Item Code";
            // 
            // lblItemBrand
            // 
            lblItemBrand.AutoSize = true;
            lblItemBrand.Font = new Font("Segoe UI", 12F);
            lblItemBrand.Location = new Point(12, 157);
            lblItemBrand.Name = "lblItemBrand";
            lblItemBrand.Size = new Size(86, 21);
            lblItemBrand.TabIndex = 4;
            lblItemBrand.Text = "Item Brand";
            // 
            // lblItemPrice
            // 
            lblItemPrice.AutoSize = true;
            lblItemPrice.Font = new Font("Segoe UI", 12F);
            lblItemPrice.Location = new Point(12, 207);
            lblItemPrice.Name = "lblItemPrice";
            lblItemPrice.Size = new Size(77, 21);
            lblItemPrice.TabIndex = 5;
            lblItemPrice.Text = "Unit Price";
            // 
            // lblItemQuantity
            // 
            lblItemQuantity.AutoSize = true;
            lblItemQuantity.Font = new Font("Segoe UI", 12F);
            lblItemQuantity.Location = new Point(13, 256);
            lblItemQuantity.Name = "lblItemQuantity";
            lblItemQuantity.Size = new Size(70, 21);
            lblItemQuantity.TabIndex = 6;
            lblItemQuantity.Text = "Quantity";
            // 
            // txtItemName
            // 
            txtItemName.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Name", true));
            txtItemName.Font = new Font("Segoe UI", 12F);
            txtItemName.Location = new Point(92, 81);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(229, 29);
            txtItemName.TabIndex = 7;
            // 
            // txtItemCode
            // 
            txtItemCode.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Code", true));
            txtItemCode.Font = new Font("Segoe UI", 12F);
            txtItemCode.Location = new Point(92, 128);
            txtItemCode.Name = "txtItemCode";
            txtItemCode.Size = new Size(229, 29);
            txtItemCode.TabIndex = 8;
            // 
            // txtItemBrand
            // 
            txtItemBrand.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Brand", true));
            txtItemBrand.Font = new Font("Segoe UI", 12F);
            txtItemBrand.Location = new Point(91, 174);
            txtItemBrand.Name = "txtItemBrand";
            txtItemBrand.Size = new Size(229, 29);
            txtItemBrand.TabIndex = 9;
            // 
            // txtItemPrice
            // 
            txtItemPrice.DataBindings.Add(new Binding("Text", itemModelBindingSource, "UnitPrice", true));
            txtItemPrice.Font = new Font("Segoe UI", 12F);
            txtItemPrice.Location = new Point(92, 224);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(229, 29);
            txtItemPrice.TabIndex = 10;
            // 
            // txtItemQuantity
            // 
            txtItemQuantity.DataBindings.Add(new Binding("Text", itemModelBindingSource, "Quantity", true));
            txtItemQuantity.Font = new Font("Segoe UI", 12F);
            txtItemQuantity.Location = new Point(91, 273);
            txtItemQuantity.Name = "txtItemQuantity";
            txtItemQuantity.Size = new Size(229, 29);
            txtItemQuantity.TabIndex = 11;
            // 
            // btnItemNew
            // 
            btnItemNew.Location = new Point(12, 348);
            btnItemNew.Name = "btnItemNew";
            btnItemNew.Size = new Size(98, 33);
            btnItemNew.TabIndex = 12;
            btnItemNew.Text = "New Item";
            btnItemNew.UseVisualStyleBackColor = true;
            btnItemNew.Click += btnItemNew_Click;
            // 
            // btnItemDelete
            // 
            btnItemDelete.Location = new Point(220, 348);
            btnItemDelete.Name = "btnItemDelete";
            btnItemDelete.Size = new Size(98, 33);
            btnItemDelete.TabIndex = 13;
            btnItemDelete.Text = "Delete Item";
            btnItemDelete.UseVisualStyleBackColor = true;
            btnItemDelete.Click += btnItemDelete_Click;
            // 
            // btnItemUpdate
            // 
            btnItemUpdate.Location = new Point(116, 348);
            btnItemUpdate.Name = "btnItemUpdate";
            btnItemUpdate.Size = new Size(98, 33);
            btnItemUpdate.TabIndex = 14;
            btnItemUpdate.Text = "Update Item";
            btnItemUpdate.UseVisualStyleBackColor = true;
            btnItemUpdate.Click += btnItemUpdate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtItemName);
            groupBox1.Controls.Add(txtItemCode);
            groupBox1.Controls.Add(txtItemBrand);
            groupBox1.Controls.Add(txtItemPrice);
            groupBox1.Controls.Add(txtItemQuantity);
            groupBox1.Location = new Point(13, -20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(337, 336);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnItemCancel
            // 
            btnItemCancel.Location = new Point(117, 387);
            btnItemCancel.Name = "btnItemCancel";
            btnItemCancel.Size = new Size(98, 33);
            btnItemCancel.TabIndex = 16;
            btnItemCancel.Text = "Cancel";
            btnItemCancel.UseVisualStyleBackColor = true;
            btnItemCancel.Click += btnItemCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnItemSave
            // 
            btnItemSave.Location = new Point(12, 387);
            btnItemSave.Name = "btnItemSave";
            btnItemSave.Size = new Size(98, 33);
            btnItemSave.TabIndex = 17;
            btnItemSave.Text = "Save";
            btnItemSave.UseVisualStyleBackColor = true;
            btnItemSave.Click += btnItemSave_Click;
            // 
            // itemErrorProvider
            // 
            itemErrorProvider.ContainerControl = this;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 450);
            Controls.Add(btnItemSave);
            Controls.Add(btnItemCancel);
            Controls.Add(btnItemUpdate);
            Controls.Add(btnItemDelete);
            Controls.Add(btnItemNew);
            Controls.Add(lblItemQuantity);
            Controls.Add(lblItemPrice);
            Controls.Add(lblItemBrand);
            Controls.Add(lblItemCode);
            Controls.Add(lblItemName);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "InventoryForm";
            Text = "Multiplex Inventory System";
            Load += InventoryForm_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemModelBindingSource1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource itemModelBindingSource1;
        private BindingSource itemModelBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private Label label1;
        private Label lblItemName;
        private Label lblItemCode;
        private Label lblItemBrand;
        private Label lblItemPrice;
        private Label lblItemQuantity;
        private TextBox txtItemName;
        private TextBox txtItemCode;
        private TextBox txtItemBrand;
        private TextBox txtItemPrice;
        private TextBox txtItemQuantity;
        private Button btnItemNew;
        private Button btnItemDelete;
        private Button btnItemUpdate;
        private GroupBox groupBox1;
        private Button btnItemCancel;
        private ErrorProvider errorProvider1;
        private Button btnItemSave;
        private ErrorProvider itemErrorProvider;
    }
}