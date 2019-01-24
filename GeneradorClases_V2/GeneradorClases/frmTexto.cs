using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class frmTexto : Form
    {
        public frmTexto()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtXML.Text == "")
            {
                MessageBox.Show(this, "No hay ningun texto escrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }
        }

        public string Showing(IWin32Window Container)
        {
            this.ShowDialog(Container);
            return txtXML.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtXML.Text = "";
            this.Close();
        }
    }
}
