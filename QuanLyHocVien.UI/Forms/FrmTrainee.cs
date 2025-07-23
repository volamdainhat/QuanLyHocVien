using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.Infrastructure.Repositories;
using QuanLyHocVien.UI.Base;
using System.Collections;
using System.Linq;

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
            return null;

            //return new Trainee
            //{
            //    Id = int.TryParse(txtId.Text, out var id) ? id : 0,
            //    FullName = txtFullName.Text,
            //    ClassId = int.TryParse(txtClassId.Text, out var classId) ? classId : 0,
            //    PhoneNumber = txtPhone.Text,
            //    DayOfBirth = dtpBirth.Value,
            //    EnlistmentDate = dtpEnlistment.Value,
            //    Ranking = txtRanking.Text,
            //    Role = txtRole.Text,
            //    FatherFullName = txtFather.Text,
            //    FatherPhoneNumber = txtFatherPhone.Text,
            //    MotherFullName = txtMother.Text,
            //    MotherPhoneNumber = txtMotherPhone.Text,
            //    AverageScore = float.TryParse(txtAvg.Text, out var score) ? score : null
            //};
        }

        protected override void BindToForm(object entity)
        {
            //var t = (Trainee)entity;
            //txtId.Text = t.Id.ToString();
            //txtFullName.Text = t.FullName;
            //txtClassId.Text = t.ClassId.ToString();
            //txtPhone.Text = t.PhoneNumber;
            //dtpBirth.Value = t.DayOfBirth ?? DateTime.Now;
            //dtpEnlistment.Value = t.EnlistmentDate;
            //txtRanking.Text = t.Ranking;
            //txtRole.Text = t.Role;
            //txtFather.Text = t.FatherFullName;
            //txtFatherPhone.Text = t.FatherPhoneNumber;
            //txtMother.Text = t.MotherFullName;
            //txtMotherPhone.Text = t.MotherPhoneNumber;
            //txtAvg.Text = t.AverageScore?.ToString();
        }

        protected override async Task SaveAsync(object entity)
        {
            //var t = (Trainee)entity;
            //if (t.Id == 0)
            //    await _uow.Trainees.AddAsync(t);
            //else
            //    await _uow.Trainees.UpdateAsync(t);
            //await _uow.SaveChangesAsync();
        }

        protected override async Task DeleteAsync(int id)
        {
            //await _uow.Trainees.DeleteAsync(id);
            //await _uow.SaveChangesAsync();
        }

        protected override int GetSelectedId()
        {
            return 0;

            //if (dgvRead.SelectedRows.Count == 0) return 0;
            //var t = dgvRead.SelectedRows[0].DataBoundItem as Trainee;
            //return t?.Id ?? 0;
        }

        protected override void ClearForm()
        {
            //txtId.Clear();
            //txtFullName.Clear();
            //txtClassId.Clear();
            //txtPhone.Clear();
            //dtpBirth.Value = DateTime.Now;
            //dtpEnlistment.Value = DateTime.Now;
            //txtRanking.Clear();
            //txtRole.Text = "Học viên";
            //txtFather.Clear();
            //txtFatherPhone.Clear();
            //txtMother.Clear();
            //txtMotherPhone.Clear();
            //txtAvg.Clear();
        }
    }
}
