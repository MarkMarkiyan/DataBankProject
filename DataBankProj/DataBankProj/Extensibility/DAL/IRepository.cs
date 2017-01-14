using System.Collections.Generic;

namespace DataBankProj.Extensibility.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(int entityId);
        T Insert(T entity);
    }
}