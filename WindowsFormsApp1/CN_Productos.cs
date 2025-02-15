using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class CN_Productos
    {

        Métodos Omet = new Métodos();

        public DataTable verRegistro()
        {
            DataTable table = new DataTable();
            table = Omet.VerRegistro();
            return table;
        }
        public DataTable verRegistroV()
        {
            DataTable table = new DataTable();
            table = Omet.VerRegistroV();
            return table;
        }

        public bool InsertarRegis(string tipo, string nombre, double precio, int cantidad, string marca)
        {
            return Omet.InsertRegis(tipo, nombre, precio, cantidad, marca);
        }
        public bool InsertarRegisV(int id, string tipo, string nombre, double precio, int cantidad, string marca)
        {
            return Omet.InsertRegisV(id, tipo, nombre, precio, cantidad, marca);
        }
        public bool EliminarRegis(int id)
        {
            return Omet.EliminarRegis(id);
        }
        public bool ModificarRegis(int id, string tipo, string nombre, double precio, int cantidad, string marca)
        {
            return Omet.ModificarRegis(id, tipo, nombre, precio, cantidad, marca);
        }
        public bool RestarCant(int id, int cant, int rcant)
        {
            return Omet.RestarCant(id, cant, rcant);
        }
        public bool SumarCant(int id, int cant, int rcant)
        {
            return Omet.SumarCant(id, cant, rcant);
        }
    }
}
