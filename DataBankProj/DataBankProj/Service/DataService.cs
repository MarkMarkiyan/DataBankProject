using System;
using System.Collections.Generic;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;
using DataBankProj.Extensibility.DAL;
using DataBankProj.Extensibility.Service;
using Newtonsoft.Json;

namespace DataBankProj.Service
{
    public class DataService : IDataService
    {
        private IRepository<User> userRepository;
        private IRepository<Book> bookRepository;

        private Dictionary<string, object> repositoryOfType;

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

        public void InsertData(object obj, string typeName)
        {
            if (typeof(Book).Name == typeName)
            {
                  bookRepository.Insert(JsonConvert.DeserializeObject<Book>(obj.ToString()));
            }
            if (typeof(User).Name == typeName)
            {
                 userRepository.Insert(JsonConvert.DeserializeObject<User>(obj.ToString()));
            }
        }

        public IEnumerable<object> GetDataByType(string typeName)
        {
            if (typeof(Book).Name == typeName)
            {
                return bookRepository.GetAll();
            }
            if (typeof(User).Name == typeName)
            {
                return userRepository.GetAll();
            }
            throw new InvalidOperationException("No suitable type find in data base");
        }

        public object GetByIdAndType(int id, string typeName) {
            if (typeof(Book).Name == typeName)
            {
                return bookRepository.GetById(id);
            }
            if (typeof(User).Name == typeName)
            {
                return userRepository.GetById(id);
            }
            throw new InvalidOperationException("No suitable type find in data base");
        }

        public Type GetTypeByName(string typeName)
        {
            if (typeof(Book).Name == typeName)
            {
                return typeof(Book);
            }
            if (typeof(User).Name == typeName)
            {
                return typeof(User);
            }
            throw new InvalidOperationException("No suitable type find in data base");
        }

        public void DeleteDataByTypeAndId(string typeName, int id)
        {
            if (typeof(Book).Name == typeName)
            {
                bookRepository.Delete(id);
            }
            if (typeName == typeof(User).Name)
            {
                userRepository.Delete(id);
            }
        }

        private void InitRepository()
        {
            if (repositoryOfType == null)
            {
                repositoryOfType = new Dictionary<string, object>();
            }
            repositoryOfType.Add("User", userRepository);
            repositoryOfType.Add("Book", bookRepository);
        }

    }
}