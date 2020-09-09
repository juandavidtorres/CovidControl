using ControlCovid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            Consulta consulta = new Consulta();
            return View("Index",consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerarReporte(Consulta prmParametros)
        {
            if (ModelState.IsValid)
            {
                ControlCovid.Models.BLL.AsistenteBLL asistenteBLL = new Models.BLL.AsistenteBLL();
                List<dynamic> lista = asistenteBLL.RecuperarListaAsistentes(prmParametros.FechaServicio, prmParametros.IdServicio);
                TempData["Resultados"] = lista;
                return RedirectToAction("Index", "Print");
            }
            else
            {
                return View("Index", prmParametros);
            }
        }
    }
}