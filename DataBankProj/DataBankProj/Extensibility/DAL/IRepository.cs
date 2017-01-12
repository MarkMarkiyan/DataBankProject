using DataBankProj.DAL.Models;
using DataBankProj.Extensibility.DAL;
using System.Collections.Generic;

namespace DataBankProj.Extensibility
{
    public interface IRepository<T>/* where T : BaseEntity*/
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        T Insert(T entity);
    }
}