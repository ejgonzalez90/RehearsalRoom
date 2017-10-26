using Microsoft.EntityFrameworkCore;
using RehearsalRoom.Model;
using RehearsalRoom.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehearsalRoom.Service
{
    public class PlayerService : IPlayerService
    {
        internal DbContext _dbcontext;
        internal PlayerRepository _repository;
        internal IUnitOfWork<Player> _unitOfWork;

        public PlayerService(RehearsalRoomContext dbContext)
        {
            _dbcontext = dbContext;
            _repository = new PlayerRepository(dbContext);
            _unitOfWork = new GenericUnitOfWork<Player>(dbContext);
        }

        public Player FindById(params object[] keys)
        {
            return _repository.FindById(keys);
        }

        public IEnumerable<Player> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(Player entity)
        {
            _repository.Add(entity);

            _unitOfWork.SaveChanges();
        }

        public void Delete(params object[] keys)
        {
            _repository.Delete(keys);

            _unitOfWork.SaveChanges();
        }

        public void Update(Player entity)
        {
            _repository.Update(entity);

            _unitOfWork.SaveChanges();
        }


        public async Task<Player> FindByIdAsync(params object[] keys)
        {
            return await _repository.FindByIdAsync(keys);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Player entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(params object[] keys)
        {
            await _repository.DeleteAsync(keys);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Player entity)
        {
            await _repository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
