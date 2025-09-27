using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ProductForm : BaseCrudForm
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IValidationService _validationService;
        private Product _product;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtStock;
        private TextBox txtCategory;

        public ProductForm(
            IRepository<Product> productRepository,
            IValidationService validationService,
            Product? product = null)
        {
            _productRepository = productRepository;
            _validationService = validationService;
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

            // Thêm sự kiện validating
            txtName.Validating += TxtName_Validating;
            txtPrice.Validating += TxtPrice_Validating;
            //txtStock.Validating += TxtStock_Validating;
            //txtCategory.Validating += TxtCategory_Validating;
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
                try
                {
                    _product.Name = txtName.Text;
                    _product.Description = txtDescription.Text;
                    _product.Price = decimal.Parse(txtPrice.Text);
                    _product.StockQuantity = int.Parse(txtStock.Text);
                    _product.Category = txtCategory.Text;
                    _product.ModifiedDate = DateTime.Now;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_product);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_product.Id == 0)
                    {
                        await _productRepository.AddAsync(_product);
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        await _productRepository.UpdateAsync(_product);
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Hiển thị thông báo khi form validation không thành công
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào. Có lỗi trong biểu mẫu.",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
            errorProvider.Clear();

            bool isValid = true;

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên sản phẩm là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 100)
            {
                errorProvider.SetError(txtName, "Tên sản phẩm không được vượt quá 100 ký tự");
                isValid = false;
            }

            // Validate Price
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtPrice, "Giá phải là số dương");
                isValid = false;
            }

            // Validate Stock
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                errorProvider.SetError(txtStock, "Số lượng tồn kho phải là số không âm");
                isValid = false;
            }

            // Validate Category
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                errorProvider.SetError(txtCategory, "Danh mục là bắt buộc");
                isValid = false;
            }
            else if (txtCategory.Text.Length > 50)
            {
                errorProvider.SetError(txtCategory, "Danh mục không được vượt quá 50 ký tự");
                isValid = false;
            }

            return isValid;
        }

        private void TxtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên sản phẩm là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }

        private void TxtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtPrice, "Giá phải là số dương");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrice, "");
            }
        }

        private void TxtStock_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                errorProvider.SetError(txtStock, "Số lượng tồn kho phải là số không âm");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }

        private void TxtCategory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                errorProvider.SetError(txtCategory, "Danh mục là bắt buộc");
                e.Cancel = true;
            }
            else if (txtCategory.Text.Length > 50)
            {
                errorProvider.SetError(txtCategory, "Danh mục không được vượt quá 50 ký tự");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrice, "");
            }
        }
    }
}
