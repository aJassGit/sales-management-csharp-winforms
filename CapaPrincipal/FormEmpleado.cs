using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
using CapaNegocio;

namespace CapaPrincipal
{
    public partial class FormEmpleado : Form
    {
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtApellido.Text)))
            {
                if (
                    System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, "^[A-Za-z]") &&
                    System.Text.RegularExpressions.Regex.IsMatch(txtApellido.Text, "^[A-Za-z]")
                    )
                {
                    Empleado empleado = new Empleado();
                    AccesoDato accesoDato = new AccesoDato();
                    NegocioEmpleado negocioEmpleado = new NegocioEmpleado();
                    try
                    {
                        empleado.Nombre = txtNombre.Text;
                        empleado.Apellido = txtApellido.Text;

                        negocioEmpleado.cargarEmpleado(empleado);
                        MessageBox.Show("El Empleado fue cargado con exito!", "Empleado Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception Error)
                    {
                        throw Error;
                    }
                    finally
                    {
                        accesoDato.cerrarConexion();
                    }
                } else
                {
                    MessageBox.Show("Llene los campos unicamente con letras", "Error en el intento de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Faltan datos por ingresar", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
