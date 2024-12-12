using Sistema.Datos;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NPersona
    {
        //Metodo Listar Registros 
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.listar();
        }// fin de public static DataTable Listar()

        // Metodo para buscar registros
        public static DataTable Buscar(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.Buscar(Valor);

        } // fin de ublic static DataTable Buscar(string Valor)
          //Metodo para registro 

        public static string Insertar(string tipo_persona, string nombre, string Tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DPersona Datos = new DPersona();
            String Existe = Datos.Existe(num_documento);
            if (Existe.Equals("No se puede actualizar el registro"))
            {
                return "Una persona con este DNI ya existe";

            }
            else
            {
                EPersona obj = new EPersona();
                obj.tipo_persona = tipo_persona;
                obj.nombre = nombre;
                obj.Tipo_documento = Tipo_documento;
                obj.num_documento = num_documento;
                obj.direccion = direccion;
                obj.telefono = telefono;
                obj.email = email;
                return Datos.Insertar(obj);

            }

        }// fin de public static string Insertar(string Nombre, string Descripcion)
        // metodo para para eliminar registros desde NCategoria
        public static string Eliminar(int Id)
        {
            DPersona Datos = new DPersona();
            return Datos.Eliminar(Id);
        }// FIN DE    public static string Eliminar(int Id)

        //Metodo para actualizar registro desde  NCategoria
        public static string Actualizar(int idpersona, string tipo_persona, string nombre, string Tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DPersona Datos = new DPersona();
            string Existe = Datos.Existe(num_documento);
            if (Existe.Equals("1"))
            {
                return "Una persona con este DNI ya existe";

            }
            else
            {
                EPersona obj = new EPersona();
                obj.idpersona = idpersona;
                obj.tipo_persona = tipo_persona;
                obj.nombre = nombre;
                obj.Tipo_documento = Tipo_documento;
                obj.num_documento = num_documento;
                obj.direccion = direccion;
                obj.telefono = telefono;
                obj.email = email;
                return Datos.Actualizar(obj);

            }


        } // FIN DE  public static string Actualizar(int Id, string Nombre, string Descripcion)


    }
}
