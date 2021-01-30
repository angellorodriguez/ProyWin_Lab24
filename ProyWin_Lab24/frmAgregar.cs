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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estas accediendo a la ventana para crear un nuevo registro de Curso");
            Curso miNuevoCurso = new Curso();

            miNuevoCurso.Nombre = txtNombre.Text;
            miNuevoCurso.Duracion = Convert.ToInt32(txtDuracion.Text);
            miNuevoCurso.Descripcion = txtDescripcion.Text;

            Conexiones miConexion = new Conexiones();
           int ValorDevuelto= miConexion.CursoInsertar(miNuevoCurso);
            if (ValorDevuelto == 1)
            {
                MessageBox.Show("Curso ingresado exitosamente.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al momento de la inserción del nuevo curso.");
            }
            Close();
        }
    }
}
