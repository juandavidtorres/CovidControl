using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ControlCovid.Models.BLL
{
    public class AsistenteBLL
    {
        public Respuesta AlmacenarAsistente(Asistente prmasistente)
        {
            Respuesta data = new Respuesta();
            try
            {
                ControlCovid.Models.DAL.DataAccessLayer dataAccessLayer = new DAL.DataAccessLayer();
                int idServicioJueves = 26;
                prmasistente.SegundoApellido = String.IsNullOrEmpty(prmasistente.SegundoApellido) ? String.Empty : prmasistente.SegundoApellido;
                prmasistente.SegundoNombre = String.IsNullOrEmpty(prmasistente.SegundoNombre) ? String.Empty : prmasistente.SegundoNombre;
                prmasistente.FechaServicio = Convert.ToInt32(prmasistente.IdServicio) == idServicioJueves ? ControlCovid.Models.BLL.ValidacionesBLL.ProximoServicio(DateTime.Now, DayOfWeek.Thursday) : ControlCovid.Models.BLL.ValidacionesBLL.ProximoServicio(DateTime.Now, DayOfWeek.Sunday);
                data.Mensaje= dataAccessLayer.AlmacenarAsistente(prmasistente);
                data.Existosa = true;
            }
            catch (Exception ex)
            {
                data.Mensaje = ex.Message;
                data.Existosa = false;
            }
            return data;
        }


        public Respuesta ModificarAsistente(UsuarioTemperatura prmasistente)
        {
            Respuesta data = new Respuesta();
            try
            {
                ControlCovid.Models.DAL.DataAccessLayer dataAccessLayer = new DAL.DataAccessLayer();
                dataAccessLayer.ModificarAsistente(prmasistente);
                data.Mensaje = string.Empty;
                data.Existosa = true;
            }
            catch (Exception ex)
            {
                data.Mensaje = ex.Message;
                data.Existosa = false;
            }
            return data;
        }

        public List<dynamic> RecuperarListaAsistentes(DateTime prmFecha, string prmStrIdServicio)
        {
            List<dynamic> lista = new List<dynamic>();
            try
            {
                ControlCovid.Models.DAL.DataAccessLayer dataAccessLayer = new DAL.DataAccessLayer();
                SqlDataReader lector = dataAccessLayer.RecuperarListaAsistentes(prmFecha, prmStrIdServicio);
                while (lector.Read())
                {
                    dynamic datos = new ExpandoObject();
                    datos.Id = Convert.ToString(lector["Id"]);
                    datos.NumeroIdentificacion = Convert.ToString(lector["numero_identificacion"]);
                    datos.Servicio = Convert.ToString(lector["Servicio"]);
                    datos.Nombre = Convert.ToString(lector["Nombre"]);
                    datos.FechaServicio = Convert.ToString(lector["fecha_servicio"]);                    
                    datos.Temperatura = Convert.ToString(lector["Temperatura"]);
                    datos.EsNuevo =  Convert.ToBoolean(lector["primera_asistencia"]) ? "Si":"No";
                    lista.Add(datos);
                }
                lector.Close();
                
            }
            catch (Exception ex)
            {
                throw;
            }

            return lista;
        }
    }
}
