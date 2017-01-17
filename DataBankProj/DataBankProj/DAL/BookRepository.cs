using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility.DAL;

namespace DataBankProj.DAL
{
    public class BookRepository : IRepository<Book>
    {
        private readonly DataContext dataContext = new DataContext();

        public IEnumerable<Book> GetAll()
        {
            return dataContext.Books;
        }

        public Book GetById(int id)
        {
            return dataContext.Books.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(int  id)
        {
            dataContext.Books.Remove(GetById(id));
            dataContext.SaveChanges();
        }

        public Book Insert(Book entity)
        {
            dataContext.Books.AddOrUpdate(entity);
            dataContext.SaveChanges();
            return entity;
        }
    }
}