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

namespace DBZ
{
    public partial class VistadeDatos : Form
    {
        private Conexiondragonball conexion;

        public VistadeDatos()
        {
        }

        public VistadeDatos(object dataGridViewXmen)
        {
            conexion = new Conexiondragonball();
            InitializeComponent();
            dataGridViewDBZ.DataSource = conexion.LeerPersonajes();
        }
    
        private void buttonRegresarInterfaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDBZ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

    }
}