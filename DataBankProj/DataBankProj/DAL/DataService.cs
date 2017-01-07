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

        public DataService(IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }

        public void InsertData(object obj, Type type)
        {
            if (typeof(Book).Name == type.Name)
            {
                bookRepository.Insert(obj as Book);
            }
            else if (type.Name == typeof(User).Name)
            {
                userRepository.Insert(obj as User);
            }
        }

        public IEnumerable<object> GetDataByType(Type type)
        {
            if (typeof(Book).Name == type.Name)
            {
               return bookRepository.GetAll();
            }
            if (type.Name == typeof(User).Name)
            {
               return userRepository.GetAll();
            }
            throw new InvalidOperationException("No suitable type find in data base");
        }
    }
}