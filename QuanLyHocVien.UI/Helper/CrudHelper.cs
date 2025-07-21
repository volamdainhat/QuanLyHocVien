using QuanLyHocVien.Infrastructure.Repositories;

namespace QuanLyHocVien.UI.Helper
{
    public static class CrudHelper
    {
        public static void AttachCrudEvents<T>(
            Form form,
            DataGridView dgv,
            Button btnAdd,
            Button btnSave,
            Button btnRemove,
            Button btnRefresh,
            Button btnPrev,
            Button btnNext,
            TextBox txtPageNumber,
            Label lblTotalPages,
            IRepository<T> repository,
            Func<T> readFromForm,
            Action<T> bindToForm,
            Func<Guid> getSelectedId,
            Action clearForm,
            int pageSize = 10
        ) where T : class
        {
            int currentPage = 1;
            int totalPages = 1;

            async Task LoadData()
            {
                var all = await repository.GetAllAsync();
                totalPages = (int)Math.Ceiling(all.Count() / (double)pageSize);
                var data = all.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                dgv.DataSource = data;
                txtPageNumber.Text = currentPage.ToString();
                lblTotalPages.Text = $"/ {totalPages}";
            }

            dgv.SelectionChanged += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    var entity = (T)dgv.SelectedRows[0].DataBoundItem!;
                    bindToForm(entity);
                }
            };

            btnAdd.Click += (s, e) => clearForm();

            btnSave.Click += async (s, e) =>
            {
                var entity = readFromForm();
                await repository.InsertAsync(entity);
                await LoadData();
            };

            btnRemove.Click += async (s, e) =>
            {
                var id = getSelectedId();
                if (id != Guid.Empty)
                {
                    await repository.DeleteAsync(id);
                    await LoadData();
                }
            };

            btnRefresh.Click += async (s, e) => await LoadData();

            btnPrev.Click += async (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    await LoadData();
                }
            };

            btnNext.Click += async (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    await LoadData();
                }
            };

            txtPageNumber.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && int.TryParse(txtPageNumber.Text, out int p) && p >= 1 && p <= totalPages)
                {
                    currentPage = p;
                    await LoadData();
                }
            };

            form.Load += async (s, e) => await LoadData();
        }
    }

}
