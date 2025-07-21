using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVien.UI.Forms
{
    public partial class FrmTrainee : Form
    {
        private readonly IUnitOfWork _uow;

        public FrmTrainee(IUnitOfWork uow)
        {
            InitializeComponent();
            _uow = uow;

            //CrudHelper.AttachCrudEvents(
            //    form: this,
            //    dgv: dgv,
            //    btnThem: btnThem,
            //    btnLuu: btnLuu,
            //    btnXoa: btnXoa,
            //    btnLamMoi: btnLamMoi,
            //    btnPrev: btnPrev,
            //    btnNext: btnNext,
            //    txtPageNumber: txtPageNumber,
            //    lblTotalPages: lblTotalPages,
            //    repository: _uow.TraineeRepository,
            //    readFromForm: ReadFromForm,
            //    bindToForm: BindToForm,
            //    getSelectedId: GetSelectedId,
            //    clearForm: ClearForm
            //);
        }

        // Các hàm override CRUD riêng cho entity
        //private Trainee ReadFromForm() => new()
        //{
        //    FullName = txtFullName.Text,
        //    EnlistmentDate = dtpEnlistmentDate.Value
        //};

        //private void BindToForm(Trainee t)
        //{
        //    txtFullName.Text = t.FullName;
        //    dtpEnlistmentDate.Value = t.EnlistmentDate;
        //}

        //private Guid GetSelectedId()
        //    => ((Trainee)dgv.SelectedRows[0].DataBoundItem!).Id;

        //private void ClearForm()
        //{
        //    txtFullName.Clear();
        //    dtpEnlistmentDate.Value = DateTime.Now;
        //}

    }
}
