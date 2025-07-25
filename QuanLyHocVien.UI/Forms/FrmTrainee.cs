using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.Infrastructure.Repositories;
using QuanLyHocVien.UI.Base;
using System.Collections;

namespace QuanLyHocVien.UI.Forms
{
    public partial class FrmTrainee : BaseCrudForm
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Trainee> _traineeRepository;

        public FrmTrainee(IUnitOfWork uow)
        {
            InitializeComponent();
            _uow = uow;
            _traineeRepository = _uow.GetRepository<Trainee>();
        }

        protected override async Task<(IList Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
        {
            var all = await _traineeRepository.GetAllAsync();
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return (paged, all.Count());
        }

        protected override object ReadFromForm()
        {
            return new Trainee
            {
                Id = int.TryParse(txtId.Text, out var id) ? id : 0,
                FullName = txtFullName.Text,
                ClassId = int.TryParse(txtClassId.Text, out var classId) ? classId : 0,
                PhoneNumber = txtPhoneNumber.Text,
                DayOfBirth = dtpDayOfBirth.Value,
                EnlistmentDate = dtpEnlistmentDate.Value,
                Ranking = txtRanking.Text,
                Role = txtRole.Text,
                FatherFullName = txtFatherFullName.Text,
                FatherPhoneNumber = txtFatherPhoneNumber.Text,
                MotherFullName = txtMotherFullName.Text,
                MotherPhoneNumber = txtMotherPhoneNumber.Text,
                AverageScore = null // float.TryParse(txtAvg.Text, out var score) ? score : null
            };
        }

        protected override void BindToForm(object entity)
        {
            var t = (Trainee)entity;
            txtId.Text = t.Id.ToString();
            txtFullName.Text = t.FullName;
            txtClassId.Text = t.ClassId.ToString();
            txtPhoneNumber.Text = t.PhoneNumber;
            dtpDayOfBirth.Value = t.DayOfBirth ?? DateTime.Now;
            dtpEnlistmentDate.Value = t.EnlistmentDate;
            txtRanking.Text = t.Ranking;
            txtRole.Text = t.Role;
            txtFatherFullName.Text = t.FatherFullName;
            txtFatherPhoneNumber.Text = t.FatherPhoneNumber;
            txtMotherFullName.Text = t.MotherFullName;
            txtMotherPhoneNumber.Text = t.MotherPhoneNumber;
            //txtAvg.Text = t.AverageScore?.ToString();
        }

        protected override async Task SaveAsync(object entity)
        {
            var t = (Trainee)entity;
            if (t.Id == 0)
                await _traineeRepository.InsertAsync(t);
            else
                _traineeRepository.Update(t);
            await _uow.SaveChangesAsync();
        }

        protected override async Task DeleteAsync(int id)
        {
            await _traineeRepository.DeleteAsync(id);
            await _uow.SaveChangesAsync();
        }

        protected override int GetSelectedId()
        {
            if (dgvRead.SelectedRows.Count == 0) return 0;
            var t = dgvRead.SelectedRows[0].DataBoundItem as Trainee;
            return t?.Id ?? 0;
        }

        protected override void ClearForm()
        {
            txtId.Clear();
            txtFullName.Clear();
            txtClassId.Clear();
            txtPhoneNumber.Clear();
            dtpDayOfBirth.Value = DateTime.Now;
            dtpEnlistmentDate.Value = DateTime.Now;
            txtRanking.Clear();
            txtRole.Text = "Học viên";
            txtFatherFullName.Clear();
            txtFatherPhoneNumber.Clear();
            txtMotherFullName.Clear();
            txtMotherPhoneNumber.Clear();
            //txtAvg.Clear();
        }
    }
}
