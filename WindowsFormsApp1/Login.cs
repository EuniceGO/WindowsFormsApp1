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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar el nombre de usuario y la contraseña
            if (username == "rebeca@gmail.com" && password == "12345")
            {
                MessageBox.Show("Inicio de sesión exitoso");
                // Realizar acciones adicionales después de un inicio de sesión exitoso
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                // Realizar acciones adicionales después de un inicio de sesión fallido
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
