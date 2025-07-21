using QuanLyHocVien.Infrastructure.Configurations;

namespace QuanLyHocVien.UI.Base
{
    public abstract partial class BaseCrudForm : Form
    {
        protected int CurrentPage = 1;
        protected int PageSize = 10;
        protected int TotalPages = 1;

        protected BaseCrudForm()
        {
            InitializeComponent();
        }

        private void AttachEvents()
        {
            this.Load += async (s, e) => await LoadDataAsync();
            btnSave.Click += async (s, e) => await SaveOrUpdate();
            btnDelete.Click += async (s, e) => await Delete();
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            dgvRead.SelectionChanged += (s, e) => BindSelectedRowToForm();
            btnAdd.Click += (s, e) => ClearForm();

            var btnPrev = tsBehavior.Items.Find("btnPrev", false).ElementAt(0);
            var btnNext = tsBehavior.Items.Find("btnNext", true).ElementAt(0);
            var txtPageNumber = tsBehavior.Items.Find("txtPageNumber", true).ElementAt(0) as ToolStripTextBox;

            btnPrev.Click += async (s, e) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage--;
                    await LoadDataAsync();
                }
            };

            btnNext.Click += async (s, e) =>
            {
                if (CurrentPage < TotalPages)
                {
                    CurrentPage++;
                    await LoadDataAsync();
                }
            };

            txtPageNumber.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (int.TryParse(txtPageNumber.Text, out int page) && page >= 1 && page <= TotalPages)
                    {
                        CurrentPage = page;
                        await LoadDataAsync();
                    }
                }
            };
        }

        private async Task LoadDataAsync()
        {
            var (Items, TotalCount) = await GetPagedAsync(CurrentPage, PageSize);
            dgvRead.DataSource = Items;

            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            txtPageNumber.Text = CurrentPage.ToString();
            lblTotalPages.Text = $"/ {TotalPages}";
        }

        private async Task SaveOrUpdate()
        {
            var item = ReadFromForm();
            await SaveAsync(item);
            await Reload();
        }

        private async Task Delete()
        {
            var id = GetSelectedId();
            if (id == 0) return;
            await DeleteAsync(id);
            await Reload();
        }

        private async Task Reload()
        {
            var (Items, TotalCount) = await GetPagedAsync(CurrentPage, PageSize);
            dgvRead.DataSource = Items;

            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            txtPageNumber.Text = CurrentPage.ToString();
            lblTotalPages.Text = $"/ {TotalPages}";
        }

        private void BindSelectedRowToForm()
        {
            if (dgvRead.SelectedRows.Count == 0) return;
            var item = dgvRead.SelectedRows[0].DataBoundItem!;
            BindToForm(item);
        }

        // Các hàm form con cần override
        protected abstract Task<(object[] Items, int TotalCount)> GetPagedAsync(int page, int pageSize);
        protected abstract Task SaveAsync(object entity);
        protected abstract Task DeleteAsync(int id);
        protected abstract object ReadFromForm();
        protected abstract void BindToForm(object entity);
        protected abstract int GetSelectedId();
        protected abstract void ClearForm();

        private void BaseCrudForm_Load(object sender, EventArgs e)
        {
            AttachEvents();
        }
    }
}
