using ControlCovid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index()
        {
            return View("Edit");
        }
   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTemperatura(UsuarioTemperatura prmAsistente)
        {
            if (ModelState.IsValid)
            {

                ControlCovid.Models.BLL.AsistenteBLL asistenteBLL = new Models.BLL.AsistenteBLL();
                Respuesta data = asistenteBLL.ModificarAsistente(prmAsistente);

                if (data.Existosa)
                {
                    ViewBag.TheResult = true;
                    ViewBag.Mensaje = $"Registro de temperatura finalizado correctamente.";
                    prmAsistente = new UsuarioTemperatura();
                    ModelState.Clear();
                    return View("Edit", prmAsistente);
                }
                else
                {

                    ViewBag.TheResult = false;
                    ViewBag.Mensaje = $"No se pudo registrar su solicitud por el siguiente motivo: {data.Mensaje}";
                    return View("Edit", prmAsistente);
                }


            }
            else
            {

                return View("Edit", prmAsistente);
            }      
        }
    }
}