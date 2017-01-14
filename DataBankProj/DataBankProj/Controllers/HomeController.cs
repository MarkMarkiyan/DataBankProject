using System.Web.Mvc;
using DataBankProj.Extensibility.Service;

namespace DataBankProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService dataService;

        public HomeController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public ActionResult Index()
        {
            return View(new SelectList(dataService.GetListOfTypes()));
        }

        public ActionResult Edit(int id, string type)
        {
            return View(dataService.GetByIdAndType(id, type));
        }

        public ActionResult AddNewEntity(string type)
        {
            return View(dataService.GetTypeByName(type));
        }
    }
}