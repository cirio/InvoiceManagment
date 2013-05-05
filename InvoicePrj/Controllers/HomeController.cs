using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using InvoicePrj.Models;

namespace InvoicePrj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DateInvoice = DateTime.Today.ToString("yyyy/MM/dd");
            return View();
        }
    }
}
