using System.Collections.Generic;
using System.Linq;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;

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

        public void Delete(User entity)
        {
            dataContext.Users.Remove(entity);
        }

        public User Insert(User entity)
        {
            return dataContext.Users.Add(entity);
        }
    }
}