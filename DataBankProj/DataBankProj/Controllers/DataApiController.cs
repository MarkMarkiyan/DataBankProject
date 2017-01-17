using System.Collections.Generic;
using System.Web.Http;
using DataBankProj.DAL;
using DataBankProj.Extensibility.Service;
using DataBankProj.Models;
using DataBankProj.Service;
using Newtonsoft.Json.Linq;

namespace DataBankProj.Controllers
{
    public class DataApiController : ApiController
    {
        private readonly IDataService dataService;

        public DataApiController()
        {
            dataService = new DataService(new UserRepository(), new BookRepository());
        }

        [HttpGet]
        public IEnumerable<object> GetDataByType(string type)
        {
            return dataService.GetDataByType(type);
        }

        [HttpPost]
        public void SaveData([FromBody] DataInfo dataInfo)
        {
            dataService.InsertData(((JObject)dataInfo.Data).ToObject<object>(), dataInfo.Type);
        }

        [HttpPost]
        public void DeleteData(int id, string type)
        {
            dataService.DeleteDataByTypeAndId(type, id);
        }
    }
}