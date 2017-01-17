using DataBankProj.DAL.Models;
using DataBankProj.Extensibility.DAL;
using DataBankProj.Extensibility.Service;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using DataBankProj.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using Assert = NUnit.Framework.Assert;

namespace DataBankProj.Tests.Service
{
    [TestFixture]
    public class DataServiceTest : TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            MockKernel.GetMock<IRepository<Book>>().ResetCalls();
            MockKernel.GetMock<IRepository<User>>().ResetCalls();
        }

        [TestCase]
        public void GetListOfTypesTest()
        {
           var actual= MockKernel.Get<DataService>().GetListOfTypes();
           var expected = new  List<string>{
            "User",
            "Book"};

            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void GetDataByTypeTest()
        {
           var testBooks = new List<Book>
           {
               new Book {Id = 123, Description = "Desr"}
           };
            MockKernel.GetMock<IRepository<Book>>().Setup(br => br.GetAll()).Returns(testBooks);
            var actual = MockKernel.Get<DataService>().GetDataByType("Book");
            Assert.AreEqual(testBooks, actual);
        }

        [TestCase]
        public void GetByIdAndTypeTest()
        {
            var expected = new User {Id = 123, Login = "login"};
            MockKernel.GetMock<IRepository<User>>().Setup(ur => ur.GetById(5)).Returns(expected);

            var actual = MockKernel.Get<DataService>().GetByIdAndType(5, "User");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetTypeByNameTest()
        {
            var actual = MockKernel.Get<DataService>().GetTypeByName("Book");
            var expected = typeof(Book);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DeleteDataByTypeAndId()
        {
            MockKernel.Get<DataService>().DeleteDataByTypeAndId("Book", 8);

            MockKernel.GetMock<IRepository<Book>>().Verify(br => br.Delete(8));
        }
    }
}
