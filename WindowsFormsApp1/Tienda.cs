using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Tienda : Form
    {
        private List<VentaFactura> lProductos;
        string rd;


        private bool opcEdit = false;
        public Tienda()
        {
            InitializeComponent();
            lProductos = new List<VentaFactura>();

        }
        private void limpiar()
        {
            textBox3.Text = "";
            txtCant.Text = "";
            txtProduct.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            textBox5.Text = "";
        }
        private void cargarLista()
        {

            CN_Productos Oprod = new CN_Productos();
            dgvProducto.DataSource = Oprod.verRegistro();
            this.dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void cargarListaV()
        {

            CN_Productos Oprod = new CN_Productos();
            dataGridView1.DataSource = Oprod.verRegistroV();
            this.dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDespensa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Tienda_Load(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count > 0)
            {
                try
                {
                    opcEdit = true;
                    btnModificar.Enabled = false;
                    /*
                    textBox3.Text = dgvProducto.CurrentRow.Cells[0].Value.ToString();
                    string rd = dgvProducto.CurrentRow.Cells[1].Value.ToString();
                    txtProduct.Text = dgvProducto.CurrentRow.Cells[2].Value.ToString();
                    txtPrecio.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                    txtCant.Text = dgvProducto.CurrentRow.Cells[4].Value.ToString();
                    txtMarca.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();
                    if (rd == btnDrog.Text)
                    {
                        btnDrog.Checked = true;
                    }
                    else if (rd == btnPapel.Text)
                    {
                        btnPapel.Checked = true;
                    }
                    else if (rd == btnDespensa.Text)
                    {
                        btnDespensa.Checked = true;
                    }
                    */

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error cargar los datos: " + ex);
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CN_Productos datos = new CN_Productos();
            if (opcEdit == false)
            //actua para insert
            {
                try
                {
                    bool estado = datos.EliminarRegis(Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value));
                    if (estado)
                    {
                        MessageBox.Show("El registro se eliminó exitosamente");
                        cargarLista();
                        //invocar a un método que limpie el formulario
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = "";
            if (btnDrog.Checked)
            {
                tipo = btnDrog.Text;
            }
            else if (btnPapel.Checked)
            {
                tipo = btnPapel.Text;
            }
            else if (btnDespensa.Checked)
            {
                tipo = btnDespensa.Text;
            }
            CN_Productos datos = new CN_Productos();
            if (opcEdit == false)
            //actua para insert
            {
                try
                {
                    bool estado = datos.InsertarRegis(tipo, txtProduct.Text,
                        Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtCant.Text), txtMarca.Text);

                    if (estado)
                    {
                        MessageBox.Show("El registro se almacenó exitosamente");
                        cargarLista();
                        //invocar a un método que limpie el formulario
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            }

            if (opcEdit == true)
            {
                try
                {
                    bool estado = datos.ModificarRegis(Convert.ToInt32(textBox3.Text), tipo, txtProduct.Text,
                        float.Parse(txtPrecio.Text), Convert.ToInt32(txtCant.Text), txtMarca.Text);
                    if (estado)
                    {
                        MessageBox.Show("El registro se modificó exitosamente");
                        cargarLista();
                        opcEdit = false;
                        cargarLista();
                        //invocar a un método que limpie el formulario
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            }
            btnModificar.Enabled = true;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            
            double precio =0;
            int cant = Int32.Parse(txtCant.Text);
            double precioT = 0;

            if (rd.Equals("Papeleria"))
            {
                precio = (Double.Parse(txtPrecio.Text) * 0.16) + (Double.Parse(txtPrecio.Text));
                precioT = precio * cant;
                
                
            }
            else if (rd.Equals("Droguería"))
            {
                precio = (Double.Parse(txtPrecio.Text) * 0.12) + (Double.Parse(txtPrecio.Text));
                precioT = precio * cant;

            }
            else if (rd.Equals("Despensa"))
            {
                precio = (Double.Parse(txtPrecio.Text) * 0.04) + (Double.Parse(txtPrecio.Text));
                precioT = precio * cant;

            }
            VentaFactura tmpProducto = new VentaFactura(Int32.Parse(textBox3.Text), rd, txtProduct.Text, Int32.Parse(txtCant.Text), precioT,txtMarca.Text);
            this.lProductos.Add(tmpProducto);
            CN_Productos datos = new CN_Productos();
            if (opcEdit == false)
            {
                try
                {
                    bool estado = datos.RestarCant(Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value),
                        Convert.ToInt32(dgvProducto.CurrentRow.Cells[4].Value), Convert.ToInt32(txtCant.Text));
                    if (estado)
                    {
                        MessageBox.Show("Se añadio el producto a la compra");
                        cargarLista();
                        //invocar a un método que limpie el formulario
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            }
            //Tabla de Estadisticas
            cargarListaV();
            CN_Productos datos2 = new CN_Productos();
            string tipo = "";
            if (btnDrog.Checked)
            {
                tipo = btnDrog.Text;
            }
            else if (btnPapel.Checked)
            {
                tipo = btnPapel.Text;
            }
            else if (btnDespensa.Checked)
            {
                tipo = btnDespensa.Text;
            }

            bool existe = false;
            if (dataGridView1.RowCount > 0)
            {
                // Primero averigua si el registro existe:
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt16(dataGridView1.Rows[i].Cells[0].Value) == Int32.Parse(textBox3.Text))
                    {
                        existe = true;
                        break;
                    }
                }
            }
            if (existe == true)
            {
                try
                {
                    bool estado = datos2.SumarCant(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value),
                        Convert.ToInt32(txtCant.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            }
            else
            {
                try
                {
                    bool estado = datos2.InsertarRegisV(Int32.Parse(textBox3.Text), tipo, txtProduct.Text,
                        Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtCant.Text), txtMarca.Text);
                    if (estado)
                    {
                        cargarListaV();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al insertar el registro: " + ex);
                }
            } 
        }
        private void dgvProducto_MouseClick(object sender, MouseEventArgs e)
        {

            textBox3.Text = dgvProducto.CurrentRow.Cells[0].Value.ToString();
            rd = dgvProducto.CurrentRow.Cells[1].Value.ToString();
            txtProduct.Text = dgvProducto.CurrentRow.Cells[2].Value.ToString();
            txtPrecio.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
            txtCant.Text = dgvProducto.CurrentRow.Cells[4].Value.ToString();
            txtMarca.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();
            if (rd == btnDrog.Text)
            {
                btnDrog.Checked = true;
            }
            else if (rd == btnPapel.Text)
            {
                btnPapel.Checked = true;
            }
            else if (rd == btnDespensa.Text)
            {
                btnDespensa.Checked = true;
            }
        }

        private void btnMostrarC_Click(object sender, EventArgs e)
        {
            Venta form2 = new Venta(lProductos);
            form2.Show();
        }
    }
}
