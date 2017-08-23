using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Services;
using VendingMachine.Models;
using VendingMachine.Models.enums;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Maintenance()
        {
            return View();
        }

    }
}