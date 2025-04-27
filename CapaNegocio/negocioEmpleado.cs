using CapaDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioEmpleado
    {
        public List<Empleado> Listar()
        {
            List<Empleado> listaempleados = new List<Empleado>();
            AccesoDato accesoDato = new AccesoDato();

            try
            {
                accesoDato.setearConsulta("SELECT Id, Nombre, Apellido FROM EMPLEADOS");
                accesoDato.ejecutarLectura();
                while (accesoDato.Lectura.Read())
                {
                    Empleado empleado = new Empleado();

                    empleado.Id = (int)accesoDato.Lectura["Id"];
                    empleado.Nombre = (string)accesoDato.Lectura["Nombre"];
                    empleado.Apellido = (string)accesoDato.Lectura["Apellido"];

                    listaempleados.Add(empleado);
                }
            }
            catch (Exception Error)
            {

                throw Error;
            }
            finally { accesoDato.cerrarConexion(); }
            return listaempleados;
        }

        public void cargarEmpleado(Empleado nuevoEmpleado)
        {
            AccesoDato accesoDato = new AccesoDato();
            try
            {
                accesoDato.setearConsulta("INSERT INTO EMPLEADOS(nombre, apellido) VALUES ('"+nuevoEmpleado.Nombre+ "' , '" + nuevoEmpleado.Apellido + "')");
                accesoDato.ejecutarEscritura();
            }
            catch (Exception Error)
            {

                throw Error;
            }
            finally 
            {
                accesoDato.cerrarConexion(); 
            }
        }
    }
}
