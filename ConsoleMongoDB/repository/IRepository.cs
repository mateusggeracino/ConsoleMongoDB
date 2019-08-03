using System.Collections.Generic;

namespace ConsoleMongoDB.repository
{
    public interface IRepository<T>
    {
        T Insert(T obj);
        bool Delete(T obj);
        T Update(T obj);
        T GetById(int id);
        List<T> GetAll();
    }
}