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
                dgvListado.DataSource = NPersona.Listar();
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
                dgvListado.DataSource = NPersona.Buscar(txtBuscar.Text);
                lblTotal.Text = "Total Registros:" + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }// Fin de private void Buscar()

        ErrorProvider errorNombre = new ErrorProvider();
        ErrorProvider errorNumeroDocumento = new ErrorProvider();
        ErrorProvider errorTipoDocumento = new ErrorProvider();
        ErrorProvider errorTipoPersona = new ErrorProvider();
        ErrorProvider errortelefono = new ErrorProvider();
        ErrorProvider errorEmail = new ErrorProvider();
        ErrorProvider errorDireccion = new ErrorProvider();
        private bool ValidarVacios()
        {
            bool esValido = false;
            if (txtNombre.Text == string.Empty) errorNombre.SetError(txtNombre, "Ingrese un nombre.");
            else { errorNombre.Clear();}
            
            if (cmbTipoDocumento.SelectedIndex == 0) errorTipoDocumento.SetError(cmbTipoDocumento, "Seleccione una opción.");
            else { errorTipoDocumento.Clear(); }

            if (cmbTipoPersona.SelectedIndex == 0) errorTipoPersona.SetError(cmbTipoPersona, "Seleccione una opción.");
            else { errorTipoPersona.Clear(); }

            if (txtNumDocumento.Text == string.Empty) errorNumeroDocumento.SetError(txtNumDocumento, "Ingrese un número de documento.");
            else { errorNumeroDocumento.Clear(); }

            if (txtTelefono.Text == string.Empty) errortelefono.SetError(txtTelefono, "Ingrese un telefono.");
            else { errortelefono.Clear(); }

            if (txtEmail.Text == string.Empty) errorEmail.SetError(txtEmail, "Ingrese un correo.");
            else { errorEmail.Clear(); }

            if (txtDireccion.Text == string.Empty) errorDireccion.SetError(txtDireccion, "Ingrese una dirección.");
            else { errorDireccion.Clear(); }

            if(txtNombre.Text != string.Empty && cmbTipoDocumento.SelectedIndex != 0 && cmbTipoPersona.SelectedIndex != 0
                && txtNumDocumento.Text != string.Empty && txtTelefono.Text != string.Empty 
                && txtEmail.Text != string.Empty && txtDireccion.Text != string.Empty)
            {
                esValido = true;
            }
            else
            {
                esValido = false;
            }

            return esValido;
        
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            this.Listar();
            btnActualizar.Visible = false;
            this.Limpiar();
        }


        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }// fin de private void MensajeOK(string mensaje)

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }// FIN DE   private void MensajeError(string mensaje)


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
        private void btnInsertar_Click(object sender, EventArgs e)
        {
             try
             {
                bool esValido = ValidarVacios();
                string Resp = "";
                if (esValido)
                {
                    string TipoPersona = cmbTipoPersona.SelectedItem.ToString();
                    string TipoDocuento = cmbTipoDocumento.SelectedItem.ToString();

                    Resp = NPersona.Insertar(TipoPersona,txtNombre.Text, TipoDocuento, txtNumDocumento.Text.Trim(),
                                            txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                    if (Resp.Equals("OK"))
                    {
                        this.MensajeOK("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();

                    }
                    else
                    {
                        this.MensajeError(Resp);
                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar algunos datos, seran remarcados", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message + ex.StackTrace);

             }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            cmbTipoPersona.SelectedIndex = 0;
            cmbTipoDocumento.SelectedIndex = 0;
            txtNumDocumento.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtID.Clear();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el(los) registros(s) seleccionado(s)?",
                    "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Question);
                int Codigo;
                string Resp = "";
                foreach (DataGridViewRow row in dgvListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        Codigo = Convert.ToInt32(row.Cells[1].Value);
                        Resp = NPersona.Eliminar(Codigo);
                        if (Resp.Equals("OK"))
                        {
                            this.MensajeOK("Se eliminó el registro: " + Convert.ToString(row.Cells[3].Value));
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
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool esValido = ValidarVacios();
                string Resp = "";
                if (esValido)
                {
                    string TipoPersona = cmbTipoPersona.SelectedItem.ToString();
                    string TipoDocuento = cmbTipoDocumento.SelectedItem.ToString();

                    Resp = NPersona.Actualizar(Convert.ToInt32(txtID.Text), TipoPersona, txtNombre.Text, TipoDocuento, txtNumDocumento.Text.Trim(),
                                            txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                    if (Resp.Equals("OK"))
                    {
                        this.MensajeOK("Se actualizó de forma correcta el registro");
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
                else
                {
                  this.MensajeError(Resp);
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
            txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
            cmbTipoDocumento.SelectedItem = Convert.ToString(dgvListado.CurrentRow.Cells["TipoDocumento"].Value);
            cmbTipoPersona.SelectedItem = Convert.ToString(dgvListado.CurrentRow.Cells["TipoPersona"].Value);
            txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
            txtNumDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["NumeroDocumento"].Value);
            txtEmail.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value);
            btnActualizar.Visible = true;
            btnInsertar.Visible = false;
            tabControl1.SelectedIndex = 1;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            int letras;
            letras = Convert.ToInt32(txtNombre.TextLength);
            lblContarLetrasMant.Text = letras.ToString();
        }
    }
}
