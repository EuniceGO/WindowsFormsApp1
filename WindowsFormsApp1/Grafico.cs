using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Grafico : Form
    {
        SqlConnection miConex = new SqlConnection();
        public Grafico()
        {
            InitializeComponent();
        }

        private void btnVisualizarTabla_Click(object sender, EventArgs e)
        {

        }
    }
}
