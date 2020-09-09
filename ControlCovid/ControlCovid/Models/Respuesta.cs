using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Models
{
    public class Respuesta
    {
        public bool Existosa{ get; set; }
        public string Mensaje { get; set; }
    }

    public class Consulta
    {

        private List<SelectListItem> listaServicios = new List<SelectListItem>();

        public Consulta()
        {
            listaServicios = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Servicio Domingo 7:00 am",Value="21",Selected=true},
                new SelectListItem(){Text="Servicio Domingo 9:00 am",Value="22",Selected=false},
                new SelectListItem(){Text="Servicio Domingo 11:00 am",Value="23",Selected=false}
                //new SelectListItem(){Text="Servicio Domingo 4:00 pm",Value="24",Selected=false},
                //new SelectListItem(){Text="Servicio Domingo 6:00 pm",Value="25",Selected=false},
                //new SelectListItem(){Text="Servicio Jueves 6:00 pm",Value="26",Selected=false},
            };
        }

        [Display(Name = "Fecha del servicio (*)")]
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaServicio { get; set; }
        public string IdServicio { get; set; }


        [Display(Name = "Servicio (*)")]
        public List<SelectListItem> Servicio
        {
            get { return listaServicios; }
            set { }
        }

    }
}