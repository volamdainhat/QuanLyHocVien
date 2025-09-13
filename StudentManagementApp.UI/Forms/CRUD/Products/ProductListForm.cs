using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ProductListForm : Form
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public ProductListForm(IRepository<Product> productRepository, IValidationService validationService)
        {
            _productRepository = productRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeProductList();
            LoadProducts();
        }

        private void InitializeProductList()
        {
            this.Text = "Product Management";
            this.Size = new System.Drawing.Size(800, 600);

            // Toolbar
            var toolStrip = new ToolStrip();
            var btnAdd = new ToolStripButton("Add");
            var btnEdit = new ToolStripButton("Edit");
            var btnRefresh = new ToolStripButton("Refresh");

            toolStrip.Items.AddRange(new ToolStripItem[] { btnAdd, btnEdit, btnRefresh });
            toolStrip.Dock = DockStyle.Top;

            // DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => AddProduct();
            btnEdit.Click += (s, e) => EditProduct();
            btnRefresh.Click += (s, e) => LoadProducts();
        }

        private async void LoadProducts()
        {
            var products = await _productRepository.GetAllAsync();
            dataGridView.DataSource = products.ToList();
        }

        private void AddProduct()
        {
            var form = new ProductForm(_productRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void EditProduct()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                var form = new ProductForm(_productRepository, _validationService, selectedProduct);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }
    }
}
