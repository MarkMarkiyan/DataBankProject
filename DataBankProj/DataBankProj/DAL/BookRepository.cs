using System.Collections.Generic;
using System.Linq;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;

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

        public void Delete(Book entity)
        {
            dataContext.Books.Remove(entity);
        }

        public Book Insert(Book entity)
        {
            return dataContext.Books.Add(entity);
        }
    }
}