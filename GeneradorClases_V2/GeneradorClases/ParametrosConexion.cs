using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class ParametrosConexion : Form
    {
        Conexion oConexion;
        public ParametrosConexion()
        {
            InitializeComponent();
            oConexion = new Conexion();
            getFromSettings();

        }

        private void getFromSettings()
        {
            if (!string.IsNullOrEmpty(Settings.Default.Servidor))
            {
                txtServidor.Text = Settings.Default.Servidor;
            }

            if (!string.IsNullOrEmpty(Settings.Default.BaseDatos))
            {
                txtBaseDatos.Text = Settings.Default.BaseDatos;
            }

            if (!string.IsNullOrEmpty(Settings.Default.Usuario))
            {
                txtUsuario.Text = Settings.Default.Usuario;
            }
            if (!string.IsNullOrEmpty(Settings.Default.Password))
            {
                txtPassword.Text = Settings.Default.Password;
            }

        }

        private void setToSettings()
        {
            Settings.Default.Servidor = txtServidor.Text;
            Settings.Default.BaseDatos = txtBaseDatos.Text;
            Settings.Default.Usuario = txtUsuario.Text;
            Settings.Default.Password = txtPassword.Text;
            Settings.Default.Save();
        }

        private bool validar()
        {
            bool bReturn = true;
            if (txtServidor.Text == "" || txtBaseDatos.Text == "")
            {
                bReturn = false;

            }
            if (!chkAutenticacion.Checked)
            {
                if (txtUsuario.Text == "" || txtPassword.Text == "")
                {
                    bReturn = false;
                }
            }
            return bReturn;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.oConexion.ConnectionString = @"Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtBaseDatos.Text + ";Integrated Security=" + (chkAutenticacion.Checked ? "True" : "False") + ";User ID=" + txtUsuario.Text + ";Password=" + txtPassword.Text;
                //Probamos la conexion
                try
                {
                    SqlConnection connection = new SqlConnection(this.oConexion.ConnectionString);
                    connection.Open();
                    connection.Close();
                    this.Visible = false;
                    setToSettings();
                }
                catch (Exception ex)
                {
                    DialogResult dgResutl = MessageBox.Show(this, "Se ha probado la conexión y no se ha podido estalecer conexón alguna, ¿Desea continuar de todas formas?", "Conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dgResutl == DialogResult.Yes)
                    {
                        this.Visible = false;
                        setToSettings();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Falta especificar algun o algunos campos", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Conexion ShowModal()
        {
            this.Visible = false;
            this.ShowDialog();
            return this.oConexion;
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}
