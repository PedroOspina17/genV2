namespace GeneradorClases
{
    partial class fSelectDataBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsTablas = new System.Windows.Forms.ListBox();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.GrupoLenguajes = new System.Windows.Forms.GroupBox();
            this.rbCSharp = new System.Windows.Forms.RadioButton();
            this.rbVB = new System.Windows.Forms.RadioButton();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.btnRuta = new System.Windows.Forms.Button();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.GrupoLenguajes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsTablas
            // 
            this.lsTablas.FormattingEnabled = true;
            this.lsTablas.Location = new System.Drawing.Point(12, 12);
            this.lsTablas.Name = "lsTablas";
            this.lsTablas.Size = new System.Drawing.Size(284, 342);
            this.lsTablas.TabIndex = 0;
            this.lsTablas.SelectedIndexChanged += new System.EventHandler(this.lsTablas_SelectedIndexChanged);
            // 
            // lstCampos
            // 
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.Location = new System.Drawing.Point(302, 12);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCampos.Size = new System.Drawing.Size(341, 121);
            this.lstCampos.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(122, 407);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(104, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 407);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(104, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // GrupoLenguajes
            // 
            this.GrupoLenguajes.Controls.Add(this.rbCSharp);
            this.GrupoLenguajes.Controls.Add(this.rbVB);
            this.GrupoLenguajes.Location = new System.Drawing.Point(302, 139);
            this.GrupoLenguajes.Name = "GrupoLenguajes";
            this.GrupoLenguajes.Size = new System.Drawing.Size(341, 49);
            this.GrupoLenguajes.TabIndex = 3;
            this.GrupoLenguajes.TabStop = false;
            this.GrupoLenguajes.Text = "Lenguajes";
            // 
            // rbCSharp
            // 
            this.rbCSharp.AutoSize = true;
            this.rbCSharp.Checked = true;
            this.rbCSharp.Location = new System.Drawing.Point(65, 19);
            this.rbCSharp.Name = "rbCSharp";
            this.rbCSharp.Size = new System.Drawing.Size(39, 17);
            this.rbCSharp.TabIndex = 0;
            this.rbCSharp.TabStop = true;
            this.rbCSharp.Text = "C#";
            this.rbCSharp.UseVisualStyleBackColor = true;
            // 
            // rbVB
            // 
            this.rbVB.AutoSize = true;
            this.rbVB.Location = new System.Drawing.Point(19, 19);
            this.rbVB.Name = "rbVB";
            this.rbVB.Size = new System.Drawing.Size(39, 17);
            this.rbVB.TabIndex = 0;
            this.rbVB.Text = "VB";
            this.rbVB.UseVisualStyleBackColor = true;
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(302, 253);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(341, 20);
            this.txtRuta.TabIndex = 4;
            this.txtRuta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(299, 237);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 5;
            this.lblRuta.Text = "Ruta:";
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(302, 279);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(35, 24);
            this.btnRuta.TabIndex = 2;
            this.btnRuta.Text = "...";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(299, 191);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(298, 13);
            this.lblNameSpace.TabIndex = 5;
            this.lblNameSpace.Text = "Namespace aplicacion. Ejemplo: (Comfama.TiendasDeportes)";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(302, 207);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(341, 20);
            this.txtNamespace.TabIndex = 4;
            this.txtNamespace.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fSelectDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 455);
            this.Controls.Add(this.lblNameSpace);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.GrupoLenguajes);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lstCampos);
            this.Controls.Add(this.lsTablas);
            this.Name = "fSelectDataBase";
            this.Text = "Seleccionar base de datos";
            this.GrupoLenguajes.ResumeLayout(false);
            this.GrupoLenguajes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsTablas;
        private System.Windows.Forms.ListBox lstCampos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox GrupoLenguajes;
        private System.Windows.Forms.RadioButton rbCSharp;
        private System.Windows.Forms.RadioButton rbVB;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.TextBox txtNamespace;


    }
}