
namespace Tester
{
    partial class ConfiguracionSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionSistema));
            this.txt_RutaGuardado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_GuardarConfiguracion = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_AbrirCarpeta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_AbrirCarpeta)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_RutaGuardado
            // 
            this.txt_RutaGuardado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RutaGuardado.Location = new System.Drawing.Point(16, 57);
            this.txt_RutaGuardado.Name = "txt_RutaGuardado";
            this.txt_RutaGuardado.ReadOnly = true;
            this.txt_RutaGuardado.Size = new System.Drawing.Size(473, 26);
            this.txt_RutaGuardado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ruta de guardado: ";
            // 
            // btn_GuardarConfiguracion
            // 
            this.btn_GuardarConfiguracion.BackColor = System.Drawing.Color.Lime;
            this.btn_GuardarConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarConfiguracion.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarConfiguracion.Location = new System.Drawing.Point(16, 112);
            this.btn_GuardarConfiguracion.Name = "btn_GuardarConfiguracion";
            this.btn_GuardarConfiguracion.Size = new System.Drawing.Size(519, 35);
            this.btn_GuardarConfiguracion.TabIndex = 4;
            this.btn_GuardarConfiguracion.Text = "Guardar";
            this.btn_GuardarConfiguracion.UseVisualStyleBackColor = false;
            this.btn_GuardarConfiguracion.Click += new System.EventHandler(this.btn_GuardarConfiguracion_Click);
            // 
            // btn_AbrirCarpeta
            // 
            this.btn_AbrirCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("btn_AbrirCarpeta.Image")));
            this.btn_AbrirCarpeta.Location = new System.Drawing.Point(495, 57);
            this.btn_AbrirCarpeta.Name = "btn_AbrirCarpeta";
            this.btn_AbrirCarpeta.Size = new System.Drawing.Size(40, 27);
            this.btn_AbrirCarpeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_AbrirCarpeta.TabIndex = 5;
            this.btn_AbrirCarpeta.TabStop = false;
            this.btn_AbrirCarpeta.Click += new System.EventHandler(this.btn_AbrirCarpeta_Click);
            // 
            // ConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 160);
            this.Controls.Add(this.btn_AbrirCarpeta);
            this.Controls.Add(this.btn_GuardarConfiguracion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_RutaGuardado);
            this.Name = "ConfiguracionSistema";
            this.ShowIcon = false;
            this.Text = "Cardio Sys - Configuracion Sistema";
            this.Load += new System.EventHandler(this.ConfiguracionSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_AbrirCarpeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_RutaGuardado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_GuardarConfiguracion;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox btn_AbrirCarpeta;
    }
}