namespace DBZ
{
    partial class VistadeDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistadeDatos));
            this.dataGridViewDBZ = new System.Windows.Forms.DataGridView();
            this.buttonRegresarInterfaz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDBZ)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDBZ
            // 
            this.dataGridViewDBZ.Location = new System.Drawing.Point(12, 39);
            this.dataGridViewDBZ.Name = "dataGridViewDBZ";
            this.dataGridViewDBZ.RowHeadersWidth = 51;
            this.dataGridViewDBZ.RowTemplate.Height = 24;
            this.dataGridViewDBZ.Size = new System.Drawing.Size(1018, 418);
            this.dataGridViewDBZ.TabIndex = 0;
            this.dataGridViewDBZ.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDBZ_CellContentClick);
            // 
            // buttonRegresarInterfaz
            // 
            this.buttonRegresarInterfaz.Location = new System.Drawing.Point(31, 463);
            this.buttonRegresarInterfaz.Name = "buttonRegresarInterfaz";
            this.buttonRegresarInterfaz.Size = new System.Drawing.Size(211, 63);
            this.buttonRegresarInterfaz.TabIndex = 1;
            this.buttonRegresarInterfaz.Text = "REGRESAR";
            this.buttonRegresarInterfaz.UseVisualStyleBackColor = true;
            this.buttonRegresarInterfaz.Click += new System.EventHandler(this.buttonRegresarInterfaz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "LISTADO DE PERSONAJES";
            // 
            // VistadeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 536);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRegresarInterfaz);
            this.Controls.Add(this.dataGridViewDBZ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistadeDatos";
            this.Text = "DATOSDBZ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDBZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDBZ;
        private System.Windows.Forms.Button buttonRegresarInterfaz;
        private System.Windows.Forms.Label label1;
    }
}
