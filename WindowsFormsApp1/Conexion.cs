using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Conexion
    {
        SqlConnection miConex = new SqlConnection(
             "Data Source=LAPTOP-6RQ1RPCU;" +
            "Initial Catalog=Tienda;" +
            "User id=Eunice;Password=12345;");

        public string pruebaConexion()
        {
            if (miConex.State == ConnectionState.Open)
                miConex.Close();
            try
            {
                miConex.Open();
                return "Conexión a tabla Producto exitosa";
            }
            catch (Exception)
            {
                return "Falló la conexión";
            }
            finally
            {
                miConex.Close();
            }
        }


        public SqlConnection AbrirConexion()
        {
            if (miConex.State == ConnectionState.Closed)
                miConex.Open();
            return miConex;
        }

        public SqlConnection CerrarConexion()
        {
            if (miConex.State == ConnectionState.Open)
                miConex.Close();
            return miConex;
        }
    }
}
