using System;
using System.Collections.Generic;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility.DAL;
using DataBankProj.Extensibility.Service;
using Newtonsoft.Json;

namespace DataBankProj.Service
{
    public class DataService : IDataService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Book> bookRepository;

        private readonly string exceptionMessage = "No suitable type find in data base";

        private List<string> dataTypesList = new List<string> {
            "User",
            "Book"
        };

        public DataService(IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }

        public List<string> GetListOfTypes()
        {
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
            throw new InvalidOperationException(exceptionMessage);
        }

        public object GetByIdAndType(int id, string typeName)
        {
            if (typeof(Book).Name == typeName)
            {
                return bookRepository.GetById(id);
            }
            if (typeof(User).Name == typeName)
            {
                return userRepository.GetById(id);
            }
            throw new InvalidOperationException(exceptionMessage);
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
            throw new InvalidOperationException(exceptionMessage);
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
    }
}