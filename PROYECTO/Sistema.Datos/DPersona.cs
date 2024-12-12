using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class DPersona
    {
        private object Comando;

        //Declarar metodo para listar
        public DataTable listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_listar", sqlcon);
                Comando.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
        }// fin de public DataTable listar()
        //Metodo para buscar registro

        public DataTable Buscar(string valor)
        {
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_buscar", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                sqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }//fin de public DataTable Buscar(string valor)

        //Metodo para Insertar Registros
        public string Insertar(EPersona Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_insertar", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@tipo_persona",     SqlDbType.VarChar).Value = Obj.tipo_persona;
                Comando.Parameters.Add("@nombre",           SqlDbType.VarChar).Value = Obj.nombre;
                Comando.Parameters.Add("@Tipo_documento",   SqlDbType.VarChar).Value = Obj.Tipo_documento;
                Comando.Parameters.Add("@num_documento",    SqlDbType.VarChar).Value = Obj.num_documento;
                Comando.Parameters.Add("@direccion",        SqlDbType.VarChar).Value = Obj.direccion;
                Comando.Parameters.Add("@telefono",         SqlDbType.VarChar).Value = Obj.telefono;
                Comando.Parameters.Add("@email",            SqlDbType.VarChar).Value = Obj.email;
                sqlCon.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar en el registro";

            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon?.Close();
                }
            }// fin finally
            return respuesta;

        }// fin de  public string Insertar(ECategoria Obj)
         //Metodo para eliminar registros
        public string Eliminar(int id)
        {
            string respuesta = " ";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_eliminar", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idpersona", SqlDbType.Int).Value = id;
                sqlCon.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return respuesta;
        }//fin de public eliminar
        //Metodo para Actualizar Registro 
        public string Actualizar(EPersona Obj)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idpersona", SqlDbType.Int).Value = Obj.idpersona;
                Comando.Parameters.Add("@tipo_persona", SqlDbType.VarChar).Value = Obj.tipo_persona;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.nombre;
                Comando.Parameters.Add("@Tipo_documento", SqlDbType.VarChar).Value = Obj.Tipo_documento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.num_documento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.email;
                SqlCon.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puede actualizar el registro";



            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return respuesta;
        }// fin de  public string Actualizar(ECategoria Obj)

        public string Existe(string valor)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puede actualizar el registro";


            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return respuesta;

        } // fin de  public string Existe(string valor)

    }
}
