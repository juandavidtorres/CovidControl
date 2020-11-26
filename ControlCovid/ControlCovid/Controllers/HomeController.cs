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
            ViewBag.MostrarFormulario = false;
            ViewBag.Diagnostico = true;
            ViewBag.MostrarModal = false;
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
                    ViewBag.MostrarModal = false;
                    ViewBag.MostrarFormulario = true;
                    ViewBag.Diagnostico = false;                    
                    Response.AddHeader("REFRESH", "7;URL=/Home/Index");
                    return View("Index",prmAsistente);
                }
                else
                {

                    ViewBag.TheResult = false;
                    ViewBag.MostrarModal = false;
                    ViewBag.MostrarFormulario = true;
                    ViewBag.Mensaje = $"No se pudo registrar su solicitud por el siguiente motivo: {data.Mensaje}";
                    return View("Index", prmAsistente);
                }

               
            }
            else
            {
                ViewBag.MostrarFormulario = true;
                ViewBag.MostrarModal = false;
                return View("Index", prmAsistente);
            }


        }
        public ActionResult GuardarAsistente()
        {
            Asistente prmAsistente = new Asistente();
            ViewBag.MostrarFormulario = false;
            ViewBag.MostrarModal = false;
            ViewBag.Diagnostico = true;
            return View("Index", prmAsistente);
        }

        public ActionResult GuardarDiagnostico()
        {
            Asistente prmAsistente = new Asistente();
            ViewBag.MostrarFormulario = false;
            ViewBag.MostrarModal = false;
            ViewBag.Diagnostico = true;
            return View("Index", prmAsistente);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarDiagnostico(FormCollection prmFormulario)
        {
            //(Convert.ToBoolean(prmFormulario[""]))
            if (((Convert.ToBoolean(prmFormulario["Fiebre"].Split(',')[0]) || (Convert.ToBoolean(prmFormulario["Respirar"].Split(',')[0]))|| (Convert.ToBoolean(prmFormulario["Garganta"].Split(',')[0]))
                || (Convert.ToBoolean(prmFormulario["Olfato"].Split(',')[0])) || (Convert.ToBoolean(prmFormulario["Olfato"].Split(',')[0])) || (Convert.ToBoolean(prmFormulario["Tos"].Split(',')[0]))
                || (Convert.ToBoolean(prmFormulario["Fatiga"].Split(',')[0])))==false) && (Convert.ToBoolean(prmFormulario["Respuesta"])==false))
            {
                ViewBag.MostrarFormulario = true;
                ViewBag.Diagnostico = false;
                ModelState.Clear();
                Asistente prmAsistente = new Asistente();                
                return View("Index", prmAsistente);
            }
            else
            {
                prmFormulario.Clear();
                Asistente datos = new Asistente();
                ViewBag.MostrarFormulario = false;
                ViewBag.Diagnostico = true;
                ViewBag.MostrarModal = true;
                return View("Index", datos);
            }
          
        }

    }
}