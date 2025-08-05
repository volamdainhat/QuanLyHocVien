using QuanLyHocVien.Domain.Entities;
using QuanLyHocVien.Infrastructure.Repositories;

namespace QuanLyHocVien.Infrastructure.Configurations
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        private Repository<Trainee> traineeRepository;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Repository<Trainee> TraineeRepository
        {
            get
            {
                this.traineeRepository ??= new Repository<Trainee>(context);
                return traineeRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
