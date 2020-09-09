using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Options()
        {
            return View("Search");
        }
    }
}