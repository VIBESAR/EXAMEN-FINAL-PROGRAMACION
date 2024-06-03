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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBZ
{
    public partial class Forminterfaz : Form
    {
        private Usuario usr = new Usuario();
        Conexiondragonball conect = new Conexiondragonball();
        List<Usuario> todos = new List<Usuario>();
        cursor cursor1 = new cursor();

        private string[] niveleski = {
    "Divino",
    "Ordinario",
    "Malvado"
        };
        private string[] universo = {
    "1",
    "11",
    "7",
    "6"
        };

        public Forminterfaz()
        {
            InitializeComponent();
        }

        private void Forminterfaz_Load(object sender, EventArgs e)
        {
            comboBoxki.Items.AddRange(niveleski);
            comboBoxuniverso.Items.AddRange(universo);
            iniciar();
        }

        private void buttonLeer_Click(object sender, EventArgs e)
        {
            VistadeDatos VistadeDatos = new VistadeDatos();
            VistadeDatos.Show();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Estas seguro de crear uno nuevo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                usr.Nombre = textBoxnombre.Text;
                usr.Edad = Convert.ToInt32(textBoxedad.Text);
                usr.Humano = checkBoxhumano.Checked;
                usr.Poder = textBoxpoder.Text;
                usr.Nivel_Ki = comboBoxki.Text;
                usr.Universo = comboBoxuniverso.Text;
                conect.Insertar(usr);
                MessageBox.Show("Personaje agregado");
                iniciar();
            }
            else if (confirmacion == DialogResult.No)
            {
                MessageBox.Show("Seleccionaste'No'");
            }
        }


        private void blanquear()
        {
            textBoxid.Clear();
            textBoxnombre.Clear();
            textBoxedad.Clear();
            textBoxpoder.Clear();
            comboBoxki.Text="";
            comboBoxuniverso.Text = "";
            checkBoxhumano.Checked = false;
        }
        private void iniciar()
        {
            blanquear();
            todos = conect.ObtenerTodosLosUsuarios();
            if (todos.Count > 0)
            {
                cursor1.Total = todos.Count;
                MostrarEncontrado(todos[cursor1.current]);
            }
            else
            {
                MessageBox.Show("No hay registros de personajes");
            }
        }
        private void buttonObtenerTodos_Click(object sender, EventArgs e)
        {
            blanquear();
        }



        private void buttonsiguiente_Click(object sender, EventArgs e)
        {
            if (cursor1.current < cursor1.Total - 1)
            {
                cursor1.current++;
            }
            else
            {
                cursor1.current = 0;
                MessageBox.Show("Finalizaron los registros, regresando al inicio.");
            }

            MostrarEncontrado(todos[cursor1.current]);
        }

        private void buttonanterior_Click(object sender, EventArgs e)
        {
            if (cursor1.current > 0)
            {
                cursor1.current--;
            }
            else
            {
                cursor1.current = cursor1.Total - 1;
                MessageBox.Show("Iniciastes los registros, regresando al final.");
            }

            MostrarEncontrado(todos[cursor1.current]);
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            usr.ID = Convert.ToInt32(textBoxid.Text);
            usr.Nombre = textBoxnombre.Text;
            usr.Edad = Convert.ToInt32(textBoxedad.Text);
            usr.Humano = checkBoxhumano.Checked;
            usr.Poder = textBoxpoder.Text;
            usr.Nivel_Ki = comboBoxki.Text;
            usr.Universo = comboBoxuniverso.Text;
            conect.Actualizar(usr);
            MessageBox.Show("Todo Correcto Actualizado");
        }

        private void buttonbuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxid.Text))
            {
                MessageBox.Show("Por favor ingrese un ID valido para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idABuscar;
            if (!int.TryParse(textBoxid.Text, out idABuscar))
            {
                MessageBox.Show("El ID que ingreso no es válido. Por favor, revisa y ingresa un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario Buscarhumano = conect.BuscarPorId(idABuscar);

            if (Buscarhumano != null)
            {
                MostrarEncontrado(Buscarhumano);
            }
            else
            {
                MessageBox.Show("No hay ningún libro con el ID especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MostrarEncontrado(Usuario usr)
        {
            textBoxid.Text = usr.ID.ToString();
            textBoxnombre.Text = usr.Nombre;
            textBoxedad.Text = usr.Edad.ToString();
            checkBoxhumano.Checked = usr.Humano;
            textBoxpoder.Text = usr.Poder;
            comboBoxki.SelectedItem = usr.Nivel_Ki;
            comboBoxuniverso.SelectedItem = usr.Universo;

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Estas seguro de Eliminarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int id = int.Parse(textBoxid.Text);
                try
                {
                    conect.Eliminar(id);
                    MessageBox.Show("Eliminaste a un personaje.");
                    iniciar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar un personaje: " + ex.Message);
                }
            }
            else if (confirmacion == DialogResult.No)
            {
    
                MessageBox.Show("Seleccionaste'No'");
            }
        }
    }
}
