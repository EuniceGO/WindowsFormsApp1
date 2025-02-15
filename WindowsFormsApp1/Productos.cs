using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Productos
    {
        protected int id;
        protected string name;
        protected int cantidad;
        protected double precio;
        protected string marca;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Cantidad
        {

            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public Productos(int id, string name, int cantidad, double precio, string marca)
        {
            this.id = Id;
            this.name = Name;
            this.cantidad = Cantidad;
            this.precio = Precio;
            this.marca = Marca;
        }
    }
}
