using StudentManagementApp.Core.Entities;
using StudentManagementApp.Infrastructure.Repositories;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ProductForm : BaseCrudForm
    {
        private readonly IRepository<Product> _productRepository;
        private Product _product;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtStock;
        private TextBox txtCategory;

        public ProductForm(IRepository<Product> productRepository, Product? product = null)
        {
            _productRepository = productRepository;
            _product = product ?? new Product() { Name = string.Empty };
            InitializeComponent();
            InitializeProductForm();
            LoadProductData();
        }

        private void InitializeProductForm()
        {
            this.Text = _product.Id == 0 ? "Add New Product" : "Edit Product";

            var y = 20;
            var labelWidth = 100;
            var textBoxWidth = 300;

            // Name
            formPanel.Controls.Add(new Label { Text = "Name:", Location = new System.Drawing.Point(20, y), Width = labelWidth });
            txtName = new TextBox { Location = new System.Drawing.Point(130, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtName);
            y += 40;

            // Description
            formPanel.Controls.Add(new Label { Text = "Description:", Location = new System.Drawing.Point(20, y), Width = labelWidth });
            txtDescription = new TextBox { Location = new System.Drawing.Point(130, y), Width = textBoxWidth, Multiline = true, Height = 60 };
            formPanel.Controls.Add(txtDescription);
            y += 80;

            // Price
            formPanel.Controls.Add(new Label { Text = "Price:", Location = new System.Drawing.Point(20, y), Width = labelWidth });
            txtPrice = new TextBox { Location = new System.Drawing.Point(130, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtPrice);
            y += 40;

            // Stock
            formPanel.Controls.Add(new Label { Text = "Stock:", Location = new System.Drawing.Point(20, y), Width = labelWidth });
            txtStock = new TextBox { Location = new System.Drawing.Point(130, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtStock);
            y += 40;

            // Category
            formPanel.Controls.Add(new Label { Text = "Category:", Location = new System.Drawing.Point(20, y), Width = labelWidth });
            txtCategory = new TextBox { Location = new System.Drawing.Point(130, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtCategory);
        }

        private void LoadProductData()
        {
            if (_product.Id > 0)
            {
                txtName.Text = _product.Name;
                txtDescription.Text = _product.Description;
                txtPrice.Text = _product.Price.ToString();
                txtStock.Text = _product.StockQuantity.ToString();
                txtCategory.Text = _product.Category;
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                _product.Name = txtName.Text;
                _product.Description = txtDescription.Text;
                _product.Price = decimal.Parse(txtPrice.Text);
                _product.StockQuantity = int.Parse(txtStock.Text);
                _product.Category = txtCategory.Text;
                _product.ModifiedDate = DateTime.Now;

                if (_product.Id == 0)
                {
                    await _productRepository.AddAsync(_product);
                }
                else
                {
                    await _productRepository.UpdateAsync(_product);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override async void Delete()
        {
            if (_product.Id > 0 &&
                MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _productRepository.DeleteAsync(_product);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            // Thêm validation logic ở đây
            return true;
        }
    }
}
