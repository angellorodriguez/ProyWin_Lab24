using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab24
{
    public class Conexiones : Interfaces.IConexiones
    {
        private string cadenaDeConexion = "Data Source=ML-RefVm-282052; DataBase=Cibertec; Integrated Security= SSPI";

        public int CursoEditar(Curso cursoPorEditar)
        {
            int valorDevuelto = 0; //0 si hubo un error, 1 si la edicion fue un éxito
            SqlConnection miConexion = new SqlConnection(cadenaDeConexion);
            try { 
            
            miConexion.Open();
            SqlCommand miComando = new SqlCommand("update Curso set Duracion=@nuevaDuracion, Descripcion=@nuevaDescripcion where Nombre = @NombreABuscar", miConexion);
            miComando.CommandType = CommandType.Text;
            miComando.Parameters.AddWithValue("@NombreABuscar", cursoPorEditar.Nombre);
            miComando.Parameters.AddWithValue("@nuevaDuracion", cursoPorEditar.Duracion);
            miComando.Parameters.AddWithValue("@nuevaDescripcion", cursoPorEditar.Descripcion);
            miComando.ExecuteNonQuery();
            valorDevuelto = 1;

            }
            catch (Exception ex)
            {
                valorDevuelto = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return valorDevuelto;
        }

        public int CursoEliminar(string nombre)
        {
            int valorDevuelto = 0; //0 si hubo un error, 1 si la eliminación fue un éxito
            SqlConnection miConexion = new SqlConnection(cadenaDeConexion);
            try
            {

                miConexion.Open();
                SqlCommand miComando = new SqlCommand("delete from Curso where Nombre=@nombreAEliminar", miConexion);
                miComando.CommandType = CommandType.Text;
                miComando.Parameters.AddWithValue("@nombreAEliminar", nombre);

                miComando.ExecuteNonQuery();
                valorDevuelto = 1;

            }
            catch (Exception ex)
            {
                valorDevuelto = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return valorDevuelto;
        }

        public int CursoInsertar(Curso cursoNuevo)
        {
            int valorDevuelto = 0; //0 si hubo un error, 1 si la inserción fue un éxito
            SqlConnection miConexion = new SqlConnection(cadenaDeConexion);
            try { 
            
            miConexion.Open();
                SqlCommand miComando = new SqlCommand("insert into Curso  values(@Nombre,@Duracion,@Descripcion)", miConexion);
                miComando.CommandType = CommandType.Text;
                miComando.Parameters.AddWithValue("@Nombre", cursoNuevo.Nombre);
                miComando.Parameters.AddWithValue("@Duracion", cursoNuevo.Duracion);
                miComando.Parameters.AddWithValue("@Descripcion", cursoNuevo.Descripcion);

                miComando.ExecuteNonQuery();
                valorDevuelto = 1;
                
            }
            catch(Exception ex)
            {
                valorDevuelto = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexion.Close();
            }

            return valorDevuelto;
        }

        public List<Curso> CursoListar()
        {
            List<Curso> ListaEncontrada = new List<Curso>();
            try { 
            SqlConnection miConexion = new SqlConnection(cadenaDeConexion);

            SqlCommand miComando = new SqlCommand("SELECT * FROM Curso", miConexion);
            miComando.CommandType = CommandType.Text;
            SqlDataAdapter miDataAdapter = new SqlDataAdapter(miComando);

                //DataSet miDataSet = new DataSet();
                //miDataAdapter.Fill(miDataSet);

                //    for (int contador = 0; contador < miDataSet.Tables[0].Rows.Count; contador++)
                //{
                //    Curso nuevoCurso = new Curso();
                //    //nuevoCurso.Nombre = miDataSet.Tables[0].Rows[contador][0].ToString();
                //    nuevoCurso.Nombre = miDataSet.Tables[0].Rows[contador]["Nombre"].ToString();
                //    nuevoCurso.Duracion =Convert.ToInt32(miDataSet.Tables[0].Rows[contador]["Duracion"]);
                //    nuevoCurso.Descripcion = miDataSet.Tables[0].Rows[contador]["Descripcion"].ToString();
                //    ListaEncontrada.Add(nuevoCurso);
                //}

                DataTable miListaEncontrada = new DataTable();
                miDataAdapter.Fill(miListaEncontrada);

                for (int contador = 0; contador < miListaEncontrada.Rows.Count; contador++)
                {
                    Curso nuevoCurso = new Curso();
                    //nuevoCurso.Nombre = miListaEncontrada.Rows[contador][0].ToString();
                    nuevoCurso.Nombre = miListaEncontrada.Rows[contador]["Nombre"].ToString();
                    nuevoCurso.Duracion = Convert.ToInt32(miListaEncontrada.Rows[contador]["Duracion"]);
                    nuevoCurso.Descripcion = miListaEncontrada.Rows[contador]["Descripcion"].ToString();
                    ListaEncontrada.Add(nuevoCurso);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ListaEncontrada;

        }
    }
}
