using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility.DAL;

namespace DataBankProj.DAL
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext dataContext = new DataContext();

        public IEnumerable<User> GetAll()
        {
            return dataContext.Users;
        }

        public User GetById(int id)
        {
            return dataContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(int id)
        {
            dataContext.Users.Remove(GetById(id));
            dataContext.SaveChanges();
        }

        public User Insert(User entity)
        {
            dataContext.Users.AddOrUpdate(entity);
            dataContext.SaveChanges();
            return entity;
        }
    }
}