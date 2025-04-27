using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace ProyectoFinalLabo2
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }


        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormDetalle formDetalle = new FormDetalle();
            formDetalle.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            NegocioEmpleado negocioEmpleado = new NegocioEmpleado();

            cmbEmpleado.DataSource = negocioEmpleado.Listar();
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.DisplayMember = "Nombre";
        }
    }
}
