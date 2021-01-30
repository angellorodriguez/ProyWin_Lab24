using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab24
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frmAgr = new frmAgregar();
            frmAgr.ShowDialog();
            CargarCursos();
        }

        private void CargarCursos()
        {
            Conexiones conexiones = new Conexiones();
            List<Curso> miListaAMostar = conexiones.CursoListar();
            miListaCursos.DataSource = miListaAMostar;

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarCursos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (miListaCursos.SelectedRows.Count > 0) { 
            Curso miCursoSeleccionado = new Curso();
            miCursoSeleccionado.Nombre= miListaCursos.SelectedRows[0].Cells["Nombre"].Value.ToString();
            miCursoSeleccionado.Duracion=Convert.ToInt32(miListaCursos.SelectedRows[0].Cells["Duracion"].Value);
            miCursoSeleccionado.Descripcion = miListaCursos.SelectedRows[0].Cells["Descripcion"].Value.ToString();

            frmEditar frmE = new frmEditar();
            frmE.CargarCurso(miCursoSeleccionado);
            frmE.ShowDialog();
            CargarCursos();
            }
            else
            {
                MessageBox.Show("No has seleccionado ninguna fila en la lista de Cursos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (miListaCursos.SelectedRows.Count > 0)
            {
                
                string NombreAEliminar = miListaCursos.SelectedRows[0].Cells["Nombre"].Value.ToString();

                Conexiones miConexion = new Conexiones();
                int resultadoEliminacion=miConexion.CursoEliminar(NombreAEliminar);
                if (resultadoEliminacion == 1)
                {
                    MessageBox.Show("Curso eliminado exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de la eliminar el curso.");
                }
                CargarCursos();
            }
            else
            {
                MessageBox.Show("No has seleccionado ninguna fila en la lista de Cursos");
            }
        }
    }
}
