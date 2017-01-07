using System.Collections.Generic;

namespace DataBankProj.Extensibility
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        T Insert(T entity);
    }
}