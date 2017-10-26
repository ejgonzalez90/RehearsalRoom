using RehearsalRoom.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehearsalRoom.Service
{
    public interface IPlayerService
    {
        void Add(Player entity);
        Task AddAsync(Player entity);
        void Delete(params object[] keys);
        Task DeleteAsync(params object[] keys);
        Player FindById(params object[] keys);
        Task<Player> FindByIdAsync(params object[] keys);
        IEnumerable<Player> GetAll();
        Task<IEnumerable<Player>> GetAllAsync();
        void Update(Player entity);
        Task UpdateAsync(Player entity);
    }
}
