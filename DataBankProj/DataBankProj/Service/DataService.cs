using System;
using System.Collections.Generic;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;

namespace DataBankProj.DAL
{
    public class DataService : IDataService
    {
        private IRepository<User> userRepository;
        private IRepository<Book> bookRepository;

        private Dictionary<string, IRepository<BaseEntity>> repositoryOfType;

        private List<string> dataTypesList = new List<string> {
            "User",
            "Book"
        };

        public DataService(IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
            InitRepository();
        }

        public List<string> GetListOfTypes() {
            return dataTypesList;
        }

        public void InsertData(object obj, string type)
        {
            (repositoryOfType[type]).Insert(obj);
        }

        public IEnumerable<object> GetDataByType(string type)
        {
            return (repositoryOfType[type]).GetAll();
        }

        public object GetByIdAndType(int id, string type) {
            return (repositoryOfType[type] as IRepository<object>).GetById(id); 
        }

        public Type GetTypeByName(string typeName)
        {
            if (typeof(Book).Name == typeName)
            {
                return typeof(Book);
            }
            if (typeName == typeof(User).Name)
            {
                return typeof(User);
            }
            throw new InvalidOperationException("No suitable type find in data base");
        }

        private void InitRepository()
        {
            if (repositoryOfType == null)
            {
                repositoryOfType = new Dictionary<string, IRepository<BaseEntity>>();
            }
            repositoryOfType.Add("Book", userRepository);
            repositoryOfType.Add("User", bookRepository);
        }
    }
}