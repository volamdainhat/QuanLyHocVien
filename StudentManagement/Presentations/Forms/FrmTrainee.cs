using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace QuanLyHocVien.UI.Base
{
    public partial class FrmTrainee : Form
    {
        protected int CurrentPage = 1;
        protected int PageSize = 10;
        protected int TotalPages = 1;

        protected FrmTrainee()
        {
            InitializeComponent();
        }

        private async void BaseCrudForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                await LoadDataAsync();
            }
        }

        private async void txtPageNumber_Enter(object sender, EventArgs e)
        {
            if (int.TryParse(txtPageNumber.Text, out int page) && page >= 1 && page <= TotalPages)
            {
                CurrentPage = page;
                await LoadDataAsync();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                await LoadDataAsync();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveOrUpdate();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await Delete();
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            BindSelectedRowToForm();
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
            var ids = GetSelectedIds();
            if (ids == null || ids.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {ids.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            await DeleteAsync(ids);
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

        protected void ConfigureGridColumnsFromModel<T>()
        {
            dgvRead.AutoGenerateColumns = false;
            dgvRead.Columns.Clear();

            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var displayAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
                if (displayAttr == null) continue;

                dgvRead.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = prop.Name,
                    HeaderText = displayAttr.DisplayName
                });
            }
        }

        // Các hàm form con cần override
        protected virtual Task<(IList Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
            => Task.FromResult(((IList)new List<object>(), 0));

        protected virtual Task SaveAsync(object entity) => Task.CompletedTask;

        protected virtual Task DeleteAsync(List<int> ids) => Task.CompletedTask;

        protected virtual object ReadFromForm() => null;

        protected virtual void BindToForm(object entity) { }

        protected virtual List<int> GetSelectedIds() => new List<int>();

        protected virtual void ClearForm() { }
    }
}
