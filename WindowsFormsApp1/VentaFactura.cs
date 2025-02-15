using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class VentaFactura : Productos
    {
        public string Tipo;
        public VentaFactura(int id,string tipo, string name, int cantidad,double precio, string marca) : base(id, name, cantidad, precio, marca)
        {
            base.Id = id;
            Tipo = tipo;
            base.Name = name;
            base.Cantidad = cantidad;
            base.Precio = precio;
            base.Marca = marca;
        }
        
    }
}
