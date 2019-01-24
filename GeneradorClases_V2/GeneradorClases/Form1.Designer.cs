namespace GeneradorClases
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtNombreClase = new System.Windows.Forms.TextBox();
            this.lblClase = new System.Windows.Forms.Label();
            this.gvAttributos = new System.Windows.Forms.DataGridView();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblCargar = new System.Windows.Forms.Label();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargarTodo = new System.Windows.Forms.Button();
            this.btnCargarBd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttributos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(15, 560);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(94, 23);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtNombreClase
            // 
            this.txtNombreClase.Location = new System.Drawing.Point(139, 41);
            this.txtNombreClase.Name = "txtNombreClase";
            this.txtNombreClase.Size = new System.Drawing.Size(260, 20);
            this.txtNombreClase.TabIndex = 2;
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Location = new System.Drawing.Point(12, 44);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(98, 13);
            this.lblClase.TabIndex = 2;
            this.lblClase.Text = "Nombre de la clase";
            // 
            // gvAttributos
            // 
            this.gvAttributos.AllowUserToResizeColumns = false;
            this.gvAttributos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gvAttributos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAttributos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAttributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAttributos.Location = new System.Drawing.Point(15, 219);
            this.gvAttributos.Name = "gvAttributos";
            this.gvAttributos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gvAttributos.Size = new System.Drawing.Size(469, 335);
            this.gvAttributos.TabIndex = 6;
            this.gvAttributos.Tag = "-1";
            this.gvAttributos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvAttributos_MouseDoubleClick);
            this.gvAttributos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAttributos_CellEndEdit);
            this.gvAttributos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAttributos_CellClick);
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(12, 18);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(121, 13);
            this.lblNameSpace.TabIndex = 2;
            this.lblNameSpace.Text = "Nombre del Namespace";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(139, 15);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(260, 20);
            this.txtNamespace.TabIndex = 1;
            // 
            // btnCargar
            // 
            this.btnCargar.Enabled = false;
            this.btnCargar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(16, 101);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(43, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "...";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblCargar
            // 
            this.lblCargar.AutoSize = true;
            this.lblCargar.Location = new System.Drawing.Point(13, 85);
            this.lblCargar.Name = "lblCargar";
            this.lblCargar.Size = new System.Drawing.Size(56, 13);
            this.lblCargar.TabIndex = 2;
            this.lblCargar.Text = "Cargar xml";
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(344, 563);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(104, 20);
            this.txtXML.TabIndex = 0;
            this.txtXML.Visible = false;
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaArchivo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtRutaArchivo.Location = new System.Drawing.Point(15, 168);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(432, 20);
            this.txtRutaArchivo.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(453, 167);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 20);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cargar desde tabla en una base de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Generar en la ruta:";
            // 
            // btnCargarTodo
            // 
            this.btnCargarTodo.Image = global::GeneradorClases.Properties.Resources.PasteHS;
            this.btnCargarTodo.Location = new System.Drawing.Point(16, 194);
            this.btnCargarTodo.Name = "btnCargarTodo";
            this.btnCargarTodo.Size = new System.Drawing.Size(32, 23);
            this.btnCargarTodo.TabIndex = 8;
            this.btnCargarTodo.UseVisualStyleBackColor = true;
            this.btnCargarTodo.Click += new System.EventHandler(this.btnCargarTodo_Click);
            // 
            // btnCargarBd
            // 
            this.btnCargarBd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarBd.Image = global::GeneradorClases.Properties.Resources.Connection_Manager;
            this.btnCargarBd.Location = new System.Drawing.Point(376, 101);
            this.btnCargarBd.Name = "btnCargarBd";
            this.btnCargarBd.Size = new System.Drawing.Size(108, 49);
            this.btnCargarBd.TabIndex = 3;
            this.btnCargarBd.UseVisualStyleBackColor = true;
            this.btnCargarBd.Click += new System.EventHandler(this.btnCargarBd_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 606);
            this.Controls.Add(this.btnCargarTodo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCargarBd);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.gvAttributos);
            this.Controls.Add(this.lblNameSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCargar);
            this.Controls.Add(this.lblClase);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.txtNombreClase);
            this.Controls.Add(this.btnGenerar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.Opacity = 0.9;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de clases";
            ((System.ComponentModel.ISupportInitialize)(this.gvAttributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtNombreClase;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.DataGridView gvAttributos;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblCargar;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnCargarTodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarBd;
        private System.Windows.Forms.Label label2;
    }
}

