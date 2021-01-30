using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab24
{
    public partial class frmEditar : Form
    {
        public frmEditar()
        {
            InitializeComponent();
        }

        public void CargarCurso(Curso cursoAEditar)
        {
            txtNombre.Text = cursoAEditar.Nombre;
            txtDuracion.Text = cursoAEditar.Duracion.ToString();
            txtDescripcion.Text = cursoAEditar.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Curso miCursoAEditar = new Curso();
            miCursoAEditar.Nombre = txtNombre.Text;
            miCursoAEditar.Duracion =Convert.ToInt32(txtDuracion.Text);
            miCursoAEditar.Descripcion = txtDescripcion.Text;

            Conexiones miConexion = new Conexiones();
            int resultadoEditando =miConexion.CursoEditar(miCursoAEditar);
            if (resultadoEditando == 1)
            {
                MessageBox.Show("Curso actualizado exitosamente.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al momento de la edición del curso.");
            }
            Close();
        }
    }
}
