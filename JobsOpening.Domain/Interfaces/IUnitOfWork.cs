using System.Threading.Tasks;

namespace JobsOpening.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IJobRepository JobRepository { get; }
        ILocationRepository LocationRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }

        Task CompleteAsync();
        void Dispose();
    }
}
