using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class frmPrincipal : Form
    {
        ParametrosConexion fParametrosConexion;
        fSelectDataBase frmSelectDatabase;
        public frmPrincipal()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("NombreAtributo");
            dt.Columns.Add("tipoDato");
            gvAttributos.DataSource = dt;
            fParametrosConexion = null;
            frmSelectDatabase = null;
            this.Text = Environment.UserDomainName;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = (DataTable)gvAttributos.DataSource;

            if (dt.Rows.Count > 0 && txtNamespace.Text != "" && txtNombreClase.Text != "")
            {
                try
                {
                    //Generamos la clase
                    Utilidades.GenerarArchivo(dt, txtNombreClase.Text, txtNamespace.Text, txtRutaArchivo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Falta especificar cosas para generar la clase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmTexto frmtexto = new frmTexto();
            gvAttributos.DataSource = Utilidades.CargarXMLDataTable(frmtexto.Showing(this));
        }

        //Busca la ruta donde se va a generar el archivo
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtRutaArchivo.Text != "")
            {
                folderBrowser.SelectedPath = txtRutaArchivo.Text;
            }
            else
            {
                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            }
            //Abrimos el buscador
            DialogResult dgResult = folderBrowser.ShowDialog(this);
            if (dgResult == DialogResult.OK)
            {
                txtRutaArchivo.Text = folderBrowser.SelectedPath;
            }
        }


        private void gvAttributos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gvAttributos.Rows[e.RowIndex].Cells["tipoDato"].Value.ToString() == "")
            {
                gvAttributos.Rows[e.RowIndex].Cells["tipoDato"].Value = "string";
            }
        }

        private void gvAttributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (gvAttributos.Columns[e.ColumnIndex] == gvAttributos.Columns["NombreAtributo"])
                {
                    if (gvAttributos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    {
                        DataTable dt = (DataTable)gvAttributos.DataSource;
                        dt.Rows.InsertAt(dt.NewRow(), dt.Rows.Count + 1);
                        gvAttributos.DataSource = dt;
                        gvAttributos.Tag = e.RowIndex;
                        gvAttributos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Clipboard.GetText();
                        gvAttributos_CellEndEdit(sender, e);
                    }
                }
            }
        }

        private void gvAttributos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnCargarTodo_Click(object sender, EventArgs e)
        {
            string[] sNames;
            sNames = Clipboard.GetText().Replace("\n", "").Split('\r');
            if (sNames.Length > 0)
            {
                DataTable dt = (DataTable)gvAttributos.DataSource;
                dt.Rows.Clear();//Borramos todas las filas
                for (int i = 0; i < sNames.Length; i++)
                {
                    dt.Rows.InsertAt(dt.NewRow(), dt.Rows.Count + 1);
                    string[] sValores = sNames[i].Split('\t');
                    gvAttributos.Rows[i].Cells["NombreAtributo"].Value = sValores[0];
                    if (sValores.Length > 1)
                    {
                        gvAttributos.Rows[i].Cells["tipoDato"].Value = sValores[1];
                    }
                    else
                    {
                        gvAttributos.Rows[i].Cells["tipoDato"].Value = "string";
                    }
                }
            }
            else
            {
                gvAttributos.Rows[gvAttributos.Rows.Count - 1].Cells["NombreAtributo"].Value = Clipboard.GetText();
            }
        }

        private void btnCargarBd_Click(object sender, EventArgs e)
        {
            if (fParametrosConexion == null)
            {
                fParametrosConexion = new ParametrosConexion();
            }
            else
            {
                fParametrosConexion.Visible = true;
            }
            Conexion oConexion = fParametrosConexion.ShowModal();
            if (oConexion.ConnectionString != "")
            {
                fSelectDataBase frmSelectDatabase = new fSelectDataBase(oConexion);
                frmSelectDatabase.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "No se estableción ninguna conexión", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
