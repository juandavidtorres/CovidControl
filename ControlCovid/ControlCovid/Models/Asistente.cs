using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCovid.Models
{
    public class Asistente
    {
        private List<SelectListItem> listaServicios = new List<SelectListItem>();
        public Asistente()
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

        [Display(Name = "Número de identificación (*)")]
        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public string NumeroIdentificacion { get; set; }
        [Display(Name = "Tipos de identificación (*)")]
        public List<SelectListItem> TiposIdentificacion;
        public string TipoIdentificacion { get; set; }

        [Display(Name = "Primer nombre (*)")]
        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [Display(Name = "Primer apellido (*)")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }

        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Telefono (*)")]
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electronico es inválido")]
        [Display(Name = "Correo electronico (*)")]
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        public string CorreoElectronico { get; set; }    

        [Display(Name = "Horario del servicio (*)")]
        public List<SelectListItem> Servicio {
            get { return listaServicios; }
            set { }
        }

        public string IdServicio { get; set; }
        [Display(Name = "¿Asiste por primera vez?")]
        public bool EsPrimeravez { get; set; }
        public DateTime FechaServicio { get; set; }
    }

    public enum TiposIdentficiacion
    {
        CC = 1,
        CE = 2,
        TI = 3,
        PA = 4,

    }

    public class UsuarioTemperatura
    {     
        
        [Display(Name = "Número de identificación (*)")]
        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public string NumeroIdentificacion { get; set; }
        [Display(Name = "Tipos de identificación (*)")]
        public List<SelectListItem> TiposIdentificacion;


        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "El valor de la temperatura no es válido, solo se permiten 2 decimales.")]
        [Required(ErrorMessage = "La temperatura es obligatoria.")]
        [Range(0, 100, ErrorMessage = "El máximo valor para la temperatura es 100.")]
        public decimal Temperatura { get; set; }
        public string TipoIdentificacion { get; set; }
    }

}