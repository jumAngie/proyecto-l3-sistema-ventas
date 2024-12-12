using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class frmPersonas : Form
    {
        public frmPersonas()
        {
            InitializeComponent();
        }

        // metodo Listar Registros
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NCategoria.Listar();
                lblTotal.Text = "Total Registros: " + Convert.ToString(dgvListado.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }// fin de private void Listar()
         // Metodo Buscar Registros
        private void Buscar()
        {
            try
            {
                dgvListado.DataSource = NCategoria.Buscar(txtBuscar.Text);
                lblTotal.Text = "Total Registros:" + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }// Fin de private void Buscar()
    }
}
