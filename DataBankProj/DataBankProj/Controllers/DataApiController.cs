using System.Collections.Generic;
using System.Web.Http;
using DataBankProj.DAL;
using DataBankProj.DAL.Models;
using DataBankProj.Extensibility;
using DataBankProj.Extensibility.Service;
using DataBankProj.Models;
using DataBankProj.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataBankProj.Controllers
{
    public class DataApiController : ApiController
    {
        private IDataService dataService;

        //public DataApiController(IDataService dataService)
        //{
        //    this.dataService = dataService;
        //}

        [HttpGet]
        public IEnumerable<object> GetDataByType(string type)
        {
            dataService = new DataService(new UserRepository(), new BookRepository());
            return dataService.GetDataByType(type);
        }

        [HttpPost]
        public void SaveData([FromBody] DataInfo dataInfo)
        {
            dataService = new DataService(new UserRepository(), new BookRepository());
            dataService.InsertData(((JObject)dataInfo.Data).ToObject<object>(), dataInfo.Type);
        }

        [HttpPost]
        public void DeleteData(int id, string type)
        {
            dataService = new DataService(new UserRepository(), new BookRepository());

            dataService.DeleteDataByTypeAndId(type, id);
        }
    }
}