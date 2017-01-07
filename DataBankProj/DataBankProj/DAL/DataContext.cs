using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataBankProj.DAL.Models;

namespace DataBankProj.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
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
            SaveChanges();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}