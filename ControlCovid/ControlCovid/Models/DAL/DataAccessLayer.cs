using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ControlCovid.Models.DAL
{
    public class DataAccessLayer
    {
        public string AlmacenarAsistente(Asistente prmasistente)
        {

            SqlCommand cmd = new SqlCommand();
            string Id = "";
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Sakura"]);
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.covid_InsertarAsistente";
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numero_identificacion",prmasistente.NumeroIdentificacion));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tipoId", prmasistente.TipoIdentificacion));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_servicio", prmasistente.IdServicio));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nombre_1", prmasistente.PrimerNombre));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nombre_2", prmasistente.SegundoNombre));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@apellido_1", prmasistente.PrimerApellido));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@apellido_2", prmasistente.SegundoApellido));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@telefono", prmasistente.Telefono));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", prmasistente.CorreoElectronico));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_servicio", prmasistente.FechaServicio));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@primera_asistencia", prmasistente.EsPrimeravez));
                Id = Convert.ToString(cmd.ExecuteScalar());
               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return Id;
        }

        public void ModificarAsistente(UsuarioTemperatura prmasistente)
        {

            SqlCommand cmd = new SqlCommand();
            string Id = "";
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Sakura"]);
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.covid_ActualizarAsistente";
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numero_identificacion", prmasistente.NumeroIdentificacion));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tipoId", prmasistente.TipoIdentificacion));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Temperatura", prmasistente.Temperatura));                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }            
        }


        public SqlDataReader RecuperarListaAsistentes(DateTime prmFecha, string prmStrIdServicio)
        {

            SqlCommand cmd = new SqlCommand();
            string Id = "";
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Sakura"]);
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.covid_RecuperarAsistente";
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Fecha", prmFecha));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdServicio", prmStrIdServicio));
                SqlDataReader datos =cmd.ExecuteReader();
                return datos;
            }
            catch (Exception ex)
            {
                throw;
            }           
        }
    }
}