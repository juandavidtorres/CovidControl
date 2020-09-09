using ControlCovid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Asistente datos = new Asistente();
            return View("Index",datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAsistente(Asistente prmAsistente)
        {
            if (ModelState.IsValid)
            {
                
                ControlCovid.Models.BLL.AsistenteBLL asistenteBLL = new Models.BLL.AsistenteBLL();                
                Respuesta data =  asistenteBLL.AlmacenarAsistente(prmAsistente);

                if (data.Existosa )
                {
                    ViewBag.TheResult = true;
                    ViewBag.Mensaje = $"Registro exitoso, su codigo de registro es:  {data.Mensaje}.";
                    prmAsistente = new Asistente();
                    ModelState.Clear();
                    return View("Index",prmAsistente);
                }
                else
                {

                    ViewBag.TheResult = false;
                    ViewBag.Mensaje = $"No se pudo registrar su solicitud por el siguiente motivo: {data.Mensaje}";
                    return View("Index", prmAsistente);
                }

               
            }
            else
            {
              
                return View("Index", prmAsistente);
            }


        }
        public ActionResult GuardarAsistente()
        {
            Asistente prmAsistente = new Asistente();
            return View("Index", prmAsistente);
        }

    }
}