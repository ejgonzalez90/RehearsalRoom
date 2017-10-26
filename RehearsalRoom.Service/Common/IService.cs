using System.Collections.Generic;

namespace RehearsalRoom.Service
{
    public interface IService<T> where T : class
    {
        T FindById(params object[] keys);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(params object[] keys);

    }
}
