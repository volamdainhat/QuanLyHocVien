using QuanLyHocVien.Infrastructure.Configurations;

namespace QuanLyHocVien.UI.Base
{
    public partial class BaseCrudForm : Form
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseCrudForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            InitializeComponent();
        }
    }
}
