using System.Threading.Tasks;

namespace RehearsalRoom.Service
{
    public interface IUnitOfWork<T> where T : class
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}