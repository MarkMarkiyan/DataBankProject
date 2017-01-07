using System.Collections.Generic;
using System.Web.Http;
using DataBankProj.DAL;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;

namespace DataBankProj.Controllers
{
    public class DataApiController : ApiController
    {
        private IDataService dataService;

        //public DataApiController(DataService dataService)
        //{
        //    this.dataService = dataService;
        //}
        [HttpGet]
        public IEnumerable<object> Get()
        {
            dataService = new DataService(new UserRepository(), new BookRepository());
            return dataService.GetDataByType(typeof(User));
        }
    }
}
