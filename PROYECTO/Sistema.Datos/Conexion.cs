using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sistema.Datos;

namespace Sistema.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion con = null;

        private Conexion()
        {
            this.Base = "L3_Sistema3erP2024N";
            this.Servidor = "DESKTOP-J3T0LDQ\\SQLEXPRESS";
            this.Usuario = "acampos";
            this.Clave = "acampos";
            this.Seguridad = true;

        }// fin de  private Conexion()
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if (this.Seguridad)
                {
            Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
        }
                else
                {
            Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + "; Password=" + this.Clave;
        }

        }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }//Fin de public SqlConnection CrearConexion()
public static Conexion getInstancia()
{
    if (con == null)
    {
        con = new Conexion();

    }
    return con;
}

    } // Fin de  public class Conexion
}// fin del main

