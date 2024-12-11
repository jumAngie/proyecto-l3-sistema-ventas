using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Sistema.Entidades;
namespace Sistema.Negocio
{
    public class NCategoria
    {
        //Metodo Listar Registros 
        public static DataTable Listar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.listar();
        }// fin de public static DataTable Listar()

        // Metodo para buscar registros
        public static DataTable Buscar(string Valor)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(Valor);

        } // fin de ublic static DataTable Buscar(string Valor)
       //Metodo para registro 
       public static string Insertar(string Nombre, string Descripcion)
       {
            DCategoria Datos = new DCategoria();
            String Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "la Categoria ya existe";

            }
            else
            {
                ECategoria obj = new ECategoria();
                obj.nombre = Nombre;
                obj.descripcion = Descripcion;
                return Datos.Insertar(obj);

            }
            
        }// fin de public static string Insertar(string Nombre, string Descripcion)
        // metodo para para eliminar registros desde NCategoria
        public static string Eliminar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Eliminar(Id);
        }// FIN DE    public static string Eliminar(int Id)

        //Metodo para actualizar registro desde  NCategoria
        public static string Actualizar(int Id, string Nombre, string Descripcipn)
        {
            DCategoria Datos = new DCategoria();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "la Categroia ya existe";

            }
            else
            {
                ECategoria obj = new ECategoria();
                obj.idcategoria = Id;
                obj.nombre = Nombre;
                obj.descripcion = Descripcipn;
                return Datos.Actualizar(obj);

            }


        } // FIN DE  public static string Actualizar(int Id, string Nombre, string Descripcion)



    }// fin de   public class NCategoria
}// fin de namespace Sistema.Negocio
