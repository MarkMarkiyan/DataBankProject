using System.Data.Entity;
using DataBankProj.DAL.Models;

namespace DataBankProj.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataBaseContext")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public void InitData()
        {
            Users.Add(new User
            {
                Id = 1,
                Password = "Pass1",
                Login = "Login"
            });
            Users.Add(new User
            {
                Id = 2,
                Password = "qasdwe",
                Login = "Markiyan"
            });
            Users.Add(new User
            {
                Id = 3,
                Password = "qweasd",
                Login = "Worker"
            });

            Books.Add(new Book
            {
                Id = 1,
                Description = "Description qwe 123",
                Author = "no author",
                Title = "Title",
                Size = 123
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "Descr",
                Author = "Aut",
                Title = "title132",
                Size = 3
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "Description Description 342",
                Author = "Author 1",
                Title = "titE",
                Size = 1233
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "DDDDDDD DDDDD DDDDD DDDDD",
                Author = "Author 2",
                Title = "BOOK",
                Size = 43
            });

            SaveChanges();
        }
    }
}