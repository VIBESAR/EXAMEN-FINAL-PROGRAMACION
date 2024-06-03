using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBZ.Data.DataAcces;
using DBZ.Data.Models;

namespace DBZ
{
    public partial class Formprincipal : Form
    {
        private Conexiondragonball Conexion;

        public Formprincipal()
        {
            InitializeComponent();
        }

        private void buttonEmpezar_Click(object sender, EventArgs e)
        {
            Forminterfaz forma2 = new Forminterfaz();
            forma2.Show();
            this.Hide();
            
        }

        private void buttonConexion_Click(object sender, EventArgs e)
        {
            Conexion = new Conexiondragonball();
            if (Conexion.ProbarConexion())
            {
                MessageBox.Show("LA CONEXION ES CORRECTA");
            }
            else
            {
                MessageBox.Show("FALLO LA CONEXION");
            }
        }

        private void Formprincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
