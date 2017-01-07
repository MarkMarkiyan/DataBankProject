using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBankProj.DAL;
using DataBankProj.DAL.Models;

namespace DataBankProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DataContext();
         
            var users = db.Users;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}