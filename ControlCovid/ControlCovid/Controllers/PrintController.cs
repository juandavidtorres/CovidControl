using ControlCovid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
           object lista =  TempData["Resultados"];
           ViewBag.Lista = lista;
           return View("Index", lista);
        }
    }
}