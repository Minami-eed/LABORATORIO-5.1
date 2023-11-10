/* Importar librerias */
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using LABORATORIO_5._1.Entities;
namespace LABORATORIO_5._1.DAO
{
    public class ClienteDAO
    {
        private string cadena;

        public ClienteDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

        public IEnumerable<Cliente> GetClientes() 
        {
            List<Cliente> temporal = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("exec usp_clientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Cliente()
                    {
                        idcliente = dr.GetString(0),
                        nombrecia = dr.GetString(1),
                        direccion = dr.GetString(2),
                        idpais = dr.GetString(3),
                        telofono = dr.GetString(4)
                    });
                }
            }
            return temporal;
        }

        /* Método Agregar, retorna de mensaje del proceso */
        public string Agregar(Cliente reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Agregar_Cliente", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod", reg.idcliente);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@direecion", reg.direccion);
                    cmd.Parameters.AddWithValue("@idpais", reg.idpais);
                    cmd.Parameters.AddWithValue("@fono", reg.telofono);
                    cn.Open();
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha agregado {c} cliente";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        /* Método Actualizar, retorna de mensaje del proceso */
        public string Actualizar(Cliente reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Actualizar_Cliente", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod", reg.idcliente);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@direccion", reg.direccion);
                    cmd.Parameters.AddWithValue("@idpais", reg.idpais);
                    cmd.Parameters.AddWithValue("@fono", reg.telofono);
                    cn.Open();
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha agregado {c} cliente";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }
    }
}
