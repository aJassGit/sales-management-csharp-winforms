﻿using CapaNegocio;
using CapaPrincipal;
using System;
using System.Windows.Forms;
using CapaDato;


namespace ProyectoFinalLabo2
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

        }
        private void msNuevoProducto_Click(object sender, EventArgs e)
        {
            FormCarga nuevoProducto = new FormCarga();
            nuevoProducto.lblTitle.Text = "Carga de Productos";
            nuevoProducto.btnCargar.Text = "Cargar";
            nuevoProducto.ShowDialog();
            cargaDgv();
        }

        private void msNuevoEmpleado_Click(object sender, EventArgs e)
        {
            FormEmpleado formEmpleado = new FormEmpleado();
            formEmpleado.ShowDialog();
        }

        private void msRealizarVenta_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.ShowDialog();
        }

        private void msSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿SEGURO QUE DESEA SALIR?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cargaDgv()
        {
            NegocioProducto negocio = new NegocioProducto();

            dgvLista.DataSource = negocio.Listar();

            dgvLista.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["Vencimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLista.Columns["id"].Visible = false;

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            cargaDgv();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)dgvLista.CurrentRow.DataBoundItem;
            FormCarga nuevoProducto = new FormCarga(seleccionado);
            nuevoProducto.lblTitle.Text = "Modificar Productos";
            nuevoProducto.btnCargar.Text = "Salvar";
            nuevoProducto.ShowDialog();
            cargaDgv();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar este Producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if(resultado == DialogResult.Yes)
            {
                Producto seleccionado = (Producto)dgvLista.CurrentRow.DataBoundItem;
                NegocioProducto negocio = new NegocioProducto();
                negocio.eliminarProducto(seleccionado.Id);
            }
            cargaDgv();
        }
    }
}
