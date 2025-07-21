using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.UI.Base;

namespace QuanLyHocVien.UI
{
    public partial class Form1 : BaseCrudForm

    {
        public Form1() : base()
        {
            InitializeComponent();
        }

        protected override void BindToForm(object entity)
        {
            throw new NotImplementedException();
        }

        protected override void ClearForm()
        {
            throw new NotImplementedException();
        }

        protected override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<(object[] Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
        {
            var items = new object[]
            {
                new() {},
                new() {},
                new() {}
            };

            return Task.FromResult((items, items.Length));
        }

        protected override int GetSelectedId()
        {
            throw new NotImplementedException();
        }

        protected override object ReadFromForm()
        {
            throw new NotImplementedException();
        }

        protected override Task SaveAsync(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
