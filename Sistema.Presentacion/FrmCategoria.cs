using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmCategoria : Form
    {
        private string NombreAnt;
        public FrmCategoria()
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


        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar();
            btnActualizar.Visible = false;
        }// fin de private void FrmCategoria_Load(object sender, EventArgs e)

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int letras;
            letras = Convert.ToInt32(txtBuscar.TextLength);
            lblContarLetras.Text = letras.ToString();
            if (letras == 0)
            {
                this.Listar();


            }
            else
            {
                this.Buscar();
            }

        }
        private void MesajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }// fin de    private void MesajeOK(string mensaje)

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Resp = "";
                if (txtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar algunos datos, seran remarcados", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                    txtNombre.Select();
                }
                else
                {
                    Resp = NCategoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (Resp.Equals("OK"))
                    {
                        this.MesajeOK("Se inserto de forma correcta el regristro");
                        this.Limpiar();
                        this.Listar();

                    }
                    else
                    {
                        this.MensajeError(Resp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        } //fin de  private void btnInsertar_Click(object sender, EventArgs e)
          // Metodo para mostrar mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }// fin de private void MensajeOK(string mensaje)
        //Metodo para mostrar mensaje error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }// FIN DE   private void MensajeError(string mensaje)
        //Metodo para Limpiar los controles del Formulario
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtID.Text = string.Empty;
            errorIcono.Clear();
        }// fin de private void Limpiar()

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el(los) registros(s) seleccionado(s)?",
                    "Sistema de Ventas",MessageBoxButtons.OK, MessageBoxIcon.Question);
                int Codigo;
                string Resp = "";
                foreach(DataGridViewRow row in dgvListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        Codigo = Convert.ToInt32(row.Cells[1].Value);
                        Resp = NCategoria.Eliminar(Codigo);
                        if (Resp.Equals("OK"))
                        {
                            this.MensajeOK("Se elimino el registro: " +Convert.ToString(row.Cells[2].Value));
                            //this.Listar();
                        }
                        else
                        {
                            this.MensajeError(Resp);
                        }
                    }// fin de if (Convert.ToBoolean(row.Cells[0].Value))
                }// fin de   foreach(DataGridViewRow row in dgvListado.Rows)

            }// fin del try
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }// fin del cath

            this.Listar();
        }// fin private void btnEliminar_Click(object sender, EventArgs e)

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }//FIN private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                String Resp = "";
                if(txtNombre.Text == String.Empty || txtID.Text == String.Empty)
                {
                    this.MensajeError("Falta Ingresar algunos datso, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    txtNombre.Select();
                }
                else
                {
                    Resp = NCategoria.Actualizar(Convert.ToInt32(txtID.Text), txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (Resp.Equals("OK"))
                    {
                        this.MensajeOK("Se Actualizo de forma Correcta el Registro");
                        if (this.NombreAnt != txtNombre.Text)
                        {
                            this.MensajeOK("El Nombre de la Categoria se Modifico");

                        }
                        this.Limpiar();
                        this.Listar();
                        btnInsertar.Visible = true;
                        btnActualizar.Visible = false;
                        tabControl1.SelectedIndex = 0;


                    }
                    else
                    {
                        this.MensajeError(Resp);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
            this.NombreAnt = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            btnActualizar.Visible = true;
            btnInsertar.Visible = false;
            tabControl1.SelectedIndex = 1;
        }
    }// FIN DE  public partial class FrmCategoria : Form
}// FIN DE namespace Sistema.Presentacion





























