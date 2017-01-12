using System.Data.Entity;
using DataBankProj.DAL.Models;
using System;

namespace DataBankProj.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext123")
        {
            Users.Add(new User
            {
                Id = 1,
                Password = "qwe",
                Login = "login"
            });
            Users.Add(new User
            {
                Id = 2,
                Password = "qasdwe",
                Login = "logiasdn"
            });
            Users.Add(new User
            {
                Id = 3,
                Password = "qweasd",
                Login = "logisadn"
            });

            Books.Add(new Book {
                Id = 1,
                Description = "qweqwe",
                PublishDate = DateTime.Now,
                Title = "title1",
                Size = 123
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "Descr",
                PublishDate = DateTime.Now,
                Title = "title132",
                Size = 3
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "Kek",
                PublishDate = DateTime.Now,
                Title = "titE",
                Size = 1233
            });
            Books.Add(new Book
            {
                Id = 1,
                Description = "sdfsdfsdf",
                PublishDate = DateTime.Now,
                Title = "lesadasd1",
                Size = 43
            });

            SaveChanges();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}