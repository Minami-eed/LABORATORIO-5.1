/* Importar librerias */
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using LABORATORIO_5._1.Entities;
namespace LABORATORIO_5._1.DAO
{
    public class PaisDAO
    {
        /*  
            En el cuerpo de la clase, defina una variable cadena la cual almacena el contenido de la conexión 
            almacenada en appsettings.json, tal como se muestra.
         */
        private string cadena; /* Almacena la coneccion */

        public PaisDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

        /* Metodo GetPaises */
        public IEnumerable<Pais> GetPaises() 
        {
            List<Pais> temporal = new List<Pais>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("exec usp_paises", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pais()
                    {
                        Idpais = dr.GetString(0),
                        Nombrepais = dr.GetString(1)
                    });
                }
            }
            return temporal;
        }

    }
}
