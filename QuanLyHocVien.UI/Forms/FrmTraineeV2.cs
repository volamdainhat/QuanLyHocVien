using AutoMapper;
using QuanLyHocVien.Applications.DTOs;
using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.Infrastructure.Repositories;
using QuanLyHocVien.Infrastructure.Repositories.TraineeRepo;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace QuanLyHocVien.UI.Base
{
    public partial class FrmTraineeV2 : Form
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITraineeRepository _traineeRepository;

        private int CurrentPage = 1;
        private int PageSize = 10;
        private int TotalPages = 1;

        protected FrmTraineeV2(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            InitializeComponent();
        }

        private async void FrmTraineeV2_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Refer to the model's properties to automatically configure DataGridView columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void ConfigureGridColumnsFromModel()
        {
            dgvRead.AutoGenerateColumns = false;
            dgvRead.Columns.Clear();

            var props = typeof(TraineeDto.ViewModel).GetProperties();
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
        private Task<(IList Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
        {
            var all = await _traineeRepository.GetAllAsync();
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize)
                .Select(t => _mapper.Map<TraineeDto.ViewModel>(t))
                .ToList();
            return (paged, all.Count());
        }

        protected virtual Task SaveAsync(object entity) => Task.CompletedTask;

        protected virtual Task DeleteAsync(List<int> ids) => Task.CompletedTask;

        protected virtual object ReadFromForm() => null;

        protected virtual void BindToForm(object entity) { }

        protected virtual List<int> GetSelectedIds() => new List<int>();

        protected virtual void ClearForm() { }
    }
}
