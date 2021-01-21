
namespace Tester
{
    partial class FrmReportePacientes
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
            this.components = new System.ComponentModel.Container();
            this.btn_GenerarReporte = new System.Windows.Forms.Button();
            this.txt_NumeroExpediente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Resultado = new System.Windows.Forms.TextBox();
            this.lbl_estatus = new System.Windows.Forms.Label();
            this.txt_NombreMedico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_cargando = new System.Windows.Forms.Label();
            this.btn_Tester = new System.Windows.Forms.Button();
            this.btn_abrirReporte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GenerarReporte
            // 
            this.btn_GenerarReporte.BackColor = System.Drawing.Color.Lime;
            this.btn_GenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btn_GenerarReporte.Location = new System.Drawing.Point(17, 282);
            this.btn_GenerarReporte.Name = "btn_GenerarReporte";
            this.btn_GenerarReporte.Size = new System.Drawing.Size(192, 35);
            this.btn_GenerarReporte.TabIndex = 0;
            this.btn_GenerarReporte.Text = "Generar Reporte";
            this.btn_GenerarReporte.UseVisualStyleBackColor = false;
            this.btn_GenerarReporte.Click += new System.EventHandler(this.btn_GenerarReporte_Click);
            // 
            // txt_NumeroExpediente
            // 
            this.txt_NumeroExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NumeroExpediente.Location = new System.Drawing.Point(129, 90);
            this.txt_NumeroExpediente.Name = "txt_NumeroExpediente";
            this.txt_NumeroExpediente.Size = new System.Drawing.Size(154, 32);
            this.txt_NumeroExpediente.TabIndex = 1;
            this.txt_NumeroExpediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_NumeroExpediente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_NumeroExpediente_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero de Expediente";
            // 
            // txt_Resultado
            // 
            this.txt_Resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Resultado.Location = new System.Drawing.Point(17, 222);
            this.txt_Resultado.Multiline = true;
            this.txt_Resultado.Name = "txt_Resultado";
            this.txt_Resultado.ReadOnly = true;
            this.txt_Resultado.Size = new System.Drawing.Size(373, 54);
            this.txt_Resultado.TabIndex = 3;
            // 
            // lbl_estatus
            // 
            this.lbl_estatus.AutoSize = true;
            this.lbl_estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estatus.Location = new System.Drawing.Point(13, 199);
            this.lbl_estatus.Name = "lbl_estatus";
            this.lbl_estatus.Size = new System.Drawing.Size(0, 20);
            this.lbl_estatus.TabIndex = 4;
            // 
            // txt_NombreMedico
            // 
            this.txt_NombreMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreMedico.Location = new System.Drawing.Point(278, 142);
            this.txt_NombreMedico.Name = "txt_NombreMedico";
            this.txt_NombreMedico.Size = new System.Drawing.Size(75, 32);
            this.txt_NombreMedico.TabIndex = 5;
            this.txt_NombreMedico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_NombreMedico.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre del Medico";
            this.label2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_cargando
            // 
            this.lbl_cargando.AutoSize = true;
            this.lbl_cargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cargando.Location = new System.Drawing.Point(158, 177);
            this.lbl_cargando.Name = "lbl_cargando";
            this.lbl_cargando.Size = new System.Drawing.Size(94, 17);
            this.lbl_cargando.TabIndex = 7;
            this.lbl_cargando.Text = "Cargando . . .";
            this.lbl_cargando.Visible = false;
            // 
            // btn_Tester
            // 
            this.btn_Tester.Location = new System.Drawing.Point(315, 12);
            this.btn_Tester.Name = "btn_Tester";
            this.btn_Tester.Size = new System.Drawing.Size(75, 23);
            this.btn_Tester.TabIndex = 8;
            this.btn_Tester.Text = "Tester";
            this.btn_Tester.UseVisualStyleBackColor = true;
            this.btn_Tester.Visible = false;
            this.btn_Tester.Click += new System.EventHandler(this.btn_Tester_Click);
            // 
            // btn_abrirReporte
            // 
            this.btn_abrirReporte.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_abrirReporte.Enabled = false;
            this.btn_abrirReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abrirReporte.ForeColor = System.Drawing.Color.White;
            this.btn_abrirReporte.Location = new System.Drawing.Point(215, 282);
            this.btn_abrirReporte.Name = "btn_abrirReporte";
            this.btn_abrirReporte.Size = new System.Drawing.Size(175, 35);
            this.btn_abrirReporte.TabIndex = 9;
            this.btn_abrirReporte.Text = "Abrir Reporte";
            this.btn_abrirReporte.UseVisualStyleBackColor = false;
            this.btn_abrirReporte.Click += new System.EventHandler(this.btn_abrirReporte_Click);
            // 
            // FrmReportePacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 350);
            this.Controls.Add(this.btn_abrirReporte);
            this.Controls.Add(this.btn_Tester);
            this.Controls.Add(this.lbl_cargando);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NombreMedico);
            this.Controls.Add(this.lbl_estatus);
            this.Controls.Add(this.txt_Resultado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NumeroExpediente);
            this.Controls.Add(this.btn_GenerarReporte);
            this.Name = "FrmReportePacientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cardio Sys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerarReporte;
        private System.Windows.Forms.TextBox txt_NumeroExpediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Resultado;
        private System.Windows.Forms.Label lbl_estatus;
        private System.Windows.Forms.TextBox txt_NombreMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_cargando;
        private System.Windows.Forms.Button btn_Tester;
        private System.Windows.Forms.Button btn_abrirReporte;
    }
}