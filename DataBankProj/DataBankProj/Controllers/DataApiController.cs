using System.Collections.Generic;
using System.Web.Http;
using DataBankProj.DAL;
using DataBankProj.Extensibility;
using DataBankProj.Models;

namespace DataBankProj.Controllers
{
    public class DataApiController : ApiController
    {
        private IDataService dataService;

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
        public void SaveData([FromBody]DataInfo dataInfo)
        {
            dataService.InsertData(dataInfo.Data, dataInfo.Type);
        }
    }
}