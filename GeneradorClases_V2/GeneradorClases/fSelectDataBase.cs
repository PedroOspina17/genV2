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
    public partial class fSelectDataBase : Form
    {
        private fSelectDataBase() { }
        private Conexion oConexion;
        public fSelectDataBase(Conexion oConexion)
        {
            InitializeComponent();
            this.oConexion = oConexion;
            lsTablas.DataSource = getTables();
            lsTablas.ValueMember = "TABLE_NAME";
            lsTablas.DisplayMember = "TABLE_NAME";
        }

        /// <summary>
        /// Obtiene las lista de tablas
        /// </summary>
        /// <returns></returns>
        private DataTable getTables()
        {
            SqlConnection con = new SqlConnection(oConexion.ConnectionString);
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                command.Connection = con;
                command.CommandText = "SELECT TABLE_NAME, TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";
                command.CommandType = CommandType.Text;
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al obtener las tablas: " + ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        private DataTable getFields(string sTableName)
        {
            SqlConnection con = new SqlConnection(oConexion.ConnectionString);
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                command.Connection = con;
                //command.CommandText = "SELECT TABLE_CATALOG, TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + sTableName + "'";
                command.CommandText = ""
                                    + " SELECT ORIGINAL_DB_NAME() TABLE_CATALOG"
                                    + " 	,OBJECT_NAME(c.object_id) TABLE_NAME"
                                    + " 	,c.name COLUMN_NAME"
                                    + " 	,ty.name DATA_TYPE"
                                    + " 	, c.max_length CHARACTER_MAXIMUM_LENGTH"
                                    + " 	, c.precision NUMERIC_PRECISION"
                                    + " 	, c.scale NUMERIC_SCALE "
                                    + " 	,ISNULL((SELECT 1 FROM sys.index_columns pkc"
			                        + "      INNER JOIN sys.indexes pk  ON pk.object_id = pkc.object_id "
			                        + "      WHERE pkc.object_id = c.Object_Id AND pkc.column_id = c.Column_Id AND pk.is_primary_key = 1)"
			                        + "      ,0) AS IS_PRIMARY_KEY"
	                                + "      ,ISNULL((SELECT 1 FROM sys.foreign_key_columns fkc"
			                        + "       WHERE parent_object_id = c.Object_Id AND fkc.parent_column_id = c.Column_Id)"
			                        + "      ,0) AS IS_FOREIGN_KEY"
                                    + "      ,c.is_nullable AS IS_NULLABLE"       
                                    + " FROM sys.columns c "
                                    + " INNER JOIN sys.types ty ON c.system_type_id = ty.system_type_id AND c.user_type_id = ty.user_type_id"
                                    + " WHERE  c.object_id = OBJECT_ID('" + sTableName + "')";
                command.CommandType = CommandType.Text;
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al obtener las tablas: " + ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        private DataTable getReferences(string sTableName)
        {
            SqlConnection con = new SqlConnection(oConexion.ConnectionString);
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                command.Connection = con;

                command.CommandText = ""
                        + "SELECT p.name parentTable,pc.name parentColumn, r.name referencedTable,rc.name referencedColumn"
                        + " FROM sys.foreign_keys fk"
                        + " INNER JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id"
                        + " INNER JOIN sys.tables p ON fkc.parent_object_id = p.object_id"
                        + " INNER JOIN sys.columns pc ON fkc.parent_object_id = pc.object_id AND fkc.parent_column_id = pc.column_id"
                        + " INNER JOIN sys.tables r ON fkc.referenced_object_id = r.object_id"
                        + " INNER JOIN sys.columns rc ON fkc.referenced_object_id = rc.object_id AND fkc.referenced_column_id = rc.column_id"
                        + " WHERE OBJECT_ID(N'" + sTableName + "') = fk.parent_object_id ";
                command.CommandType = CommandType.Text;
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al obtener las referencias: " + ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        private void lsTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCampos.DataSource = getFields(lsTablas.SelectedValue.ToString());
            lstCampos.DisplayMember = "COLUMN_NAME";
            lstCampos.ValueMember = "COLUMN_NAME";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string sLanguage = "";
            if (rbCSharp.Checked)
            {
                sLanguage = "cs";
            }
            else if (rbVB.Checked)
            {
                sLanguage = "vb";
            }
            try
            {
                string sMsg = validar();
                if (string.IsNullOrEmpty(sMsg))
                {
                    Generadora oGenerador = new Generadora(lsTablas.SelectedValue.ToString(), txtRuta.Text, sLanguage, txtNamespace.Text, Settings.Default.BaseDatos);
                    oGenerador.Generar(getFields(lsTablas.SelectedValue.ToString()), getSelectedValues(ref lstCampos), getReferences(lsTablas.SelectedValue.ToString()));
                    MessageBox.Show(this, "Todo el código ha sido generado correctamente", "Generador de clases", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, sMsg, "Generador de clases", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al generar: " + ex.Message + " - " + ex.StackTrace, "Generador de clases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string validar()
        {
            string msg = "";
            if (txtRuta.Text == "")
            {
                msg = "Debe especificar la ruta donde se va a generar el código.";
            }
            else
            {
                if (txtRuta.Text != "" && !System.IO.Directory.Exists(txtRuta.Text))
                {
                    msg = "Directorio no válido, no existe o no se tiene acceso.";
                }
                else
                {
                    if (lsTablas.SelectedIndex == -1)
                    {
                        msg = "Seleccione la tabla que desea generar.";
                    }
                    else
                    {
                        if (lstCampos.SelectedIndex == -1)
                        {
                            msg = "Seleccione los campos de la tabla que serán claves o indices.";
                        }
                    }
                }
            }
            return msg;
        }

        private string[] getSelectedValues(ref ListBox lb)
        {
            string[] values = null;
            if (lb.SelectedItems.Count > 0)
            {
                values = new string[lb.SelectedItems.Count];
                for (int i = 0; i < lb.SelectedItems.Count; i++)
                {
                    values[i] = Convert.ToString(((DataRowView)lb.SelectedItems[i])["COLUMN_NAME"]);
                }
            }
            return values;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowser.SelectedPath;
            }
        }

    }
}
