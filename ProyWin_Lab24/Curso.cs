using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyWin_Lab24
{
    public class Curso
    {
        private string varNombre;
        private int varDuracion;
        private string varDescripcion;

        public string Nombre
        {
            set { varNombre = value; }
            get { return varNombre; }
        }

        public int Duracion
        {
            set { varDuracion = value; }
            get { return varDuracion; }
        }

        public string Descripcion
        {
            set { varDescripcion = value; }
            get { return varDescripcion; }
        }

    }
}
