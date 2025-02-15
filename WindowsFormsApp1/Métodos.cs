using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Métodos
    {
        private Conexion Ocon = new Conexion();
        DataTable tabla = new DataTable();
        SqlCommand command = new SqlCommand();
        SqlDataReader read;


        public DataTable VerRegistro()
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "SELECT * FROM Productos";
            command.CommandType = CommandType.Text;
            read = command.ExecuteReader();
            tabla.Load(read);
            Ocon.CerrarConexion();
            return tabla;
        }
        public DataTable VerRegistroV()
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "SELECT * FROM ProductosV";
            command.CommandType = CommandType.Text;
            read = command.ExecuteReader();
            tabla.Load(read);
            Ocon.CerrarConexion();
            return tabla;
        }
        public bool InsertRegis(string _tipo, string _name, double _precio, int _cant,
            string _marca)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "INSERT INTO Productos(Tipo,Nombre,Precio,Cantidad,Marca)" +
                "VALUES(@Tipo,@Nombre,@Precio,@Cantidad,@Marca)";
            command.Parameters.AddWithValue("@Tipo", _tipo);
            command.Parameters.AddWithValue("@Nombre", _name);
            command.Parameters.AddWithValue("@Precio", _precio);
            command.Parameters.AddWithValue("@Cantidad", _cant);
            command.Parameters.AddWithValue("@Marca", _marca);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool InsertRegisV(int _id, string _tipo, string _name, double _precio, int _cant,
            string _marca)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "INSERT INTO ProductosV(Id,Tipo,Nombre,Precio,Cantidad,Marca)" +
                "VALUES(@Id,@Tipo,@Nombre,@Precio,@Cantidad,@Marca)";
            command.Parameters.AddWithValue("@Id", _id);
            command.Parameters.AddWithValue("@Tipo", _tipo);
            command.Parameters.AddWithValue("@Nombre", _name);
            command.Parameters.AddWithValue("@Precio", _precio);
            command.Parameters.AddWithValue("@Cantidad", _cant);
            command.Parameters.AddWithValue("@Marca", _marca);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool EliminarRegis(int _id)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "DELETE FROM Productos WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", _id);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ModificarRegis(int _id, string _tipo, string _name, double _precio, int _cant,
            string _marca)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "UPDATE Productos SET Tipo=@Tipo,Nombre=@Nombre," +
                        "Precio=@Precio,Cantidad=@Cantidad,Marca=@Marca " +
                        "WHERE Id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", _id);
            command.Parameters.AddWithValue("@Tipo", _tipo);
            command.Parameters.AddWithValue("@Nombre", _name);
            command.Parameters.AddWithValue("@Precio", _precio);
            command.Parameters.AddWithValue("@Cantidad", _cant);
            command.Parameters.AddWithValue("@Marca", _marca);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RestarCant(int _id, int _cant, int _rcant)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "UPDATE Productos SET Cantidad=@Cantidad " +
                        "WHERE Id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", _id);
            command.Parameters.AddWithValue("@Cantidad", _cant - _rcant);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SumarCant(int _id, int _cant, int _rcant)
        {
            command.Connection = Ocon.AbrirConexion();
            command.CommandText = "UPDATE ProductosV SET Cantidad=@Cantidad " +
                        "WHERE Id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Id", _id);
            command.Parameters.AddWithValue("@Cantidad", _cant + _rcant);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Ocon.CerrarConexion();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
