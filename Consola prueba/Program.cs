using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;


namespace Consola_prueba
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Conexion con = Conexion.getInstancia();
                using (SqlConnection conexion = con.CrearConexion())
                {
                    conexion.Open();
                    Console.WriteLine("conexion exitosa!");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al realizar la conexion:" + ex.Message);
            }
            Console.ReadKey();
        }// fin de static void Main(string[] args)
    }// fin de  public class Program
}// fin de namespace Consola_prueba
