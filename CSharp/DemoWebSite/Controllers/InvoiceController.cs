using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoWebSite.Filters;

namespace DemoWebSite.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        [BasicAuthenticationFilter("testUser", "testPassword")]
        public ActionResult Index()
        {
            return View();
        }
    }
}