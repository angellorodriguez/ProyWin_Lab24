using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyWin_Lab24
{
    public class Interfaces
    {
        public interface IConexiones
        {
            List<Curso> CursoListar();
            int CursoInsertar(Curso objCurso);
            int CursoEliminar(String nombre);
            int CursoEditar(Curso objCurso);
        }
    }
}
