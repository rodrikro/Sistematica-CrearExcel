﻿
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTool_Configuracion = new System.Windows.Forms.ToolStripLabel();
            this.btntool_Tester = new System.Windows.Forms.ToolStripLabel();
            this.mtxt_FechaInicio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxt_FechaFin = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GenerarReporte
            // 
            this.btn_GenerarReporte.BackColor = System.Drawing.Color.Lime;
            this.btn_GenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btn_GenerarReporte.Location = new System.Drawing.Point(17, 375);
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
            this.txt_Resultado.Location = new System.Drawing.Point(17, 315);
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
            this.lbl_estatus.Location = new System.Drawing.Point(13, 292);
            this.lbl_estatus.Name = "lbl_estatus";
            this.lbl_estatus.Size = new System.Drawing.Size(0, 20);
            this.lbl_estatus.TabIndex = 4;
            // 
            // txt_NombreMedico
            // 
            this.txt_NombreMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreMedico.Location = new System.Drawing.Point(214, 28);
            this.txt_NombreMedico.Name = "txt_NombreMedico";
            this.txt_NombreMedico.Size = new System.Drawing.Size(40, 32);
            this.txt_NombreMedico.TabIndex = 5;
            this.txt_NombreMedico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_NombreMedico.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-10, 28);
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
            this.lbl_cargando.Location = new System.Drawing.Point(160, 273);
            this.lbl_cargando.Name = "lbl_cargando";
            this.lbl_cargando.Size = new System.Drawing.Size(94, 17);
            this.lbl_cargando.TabIndex = 7;
            this.lbl_cargando.Text = "Cargando . . .";
            this.lbl_cargando.Visible = false;
            // 
            // btn_Tester
            // 
            this.btn_Tester.Location = new System.Drawing.Point(315, 28);
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
            this.btn_abrirReporte.Location = new System.Drawing.Point(215, 375);
            this.btn_abrirReporte.Name = "btn_abrirReporte";
            this.btn_abrirReporte.Size = new System.Drawing.Size(175, 35);
            this.btn_abrirReporte.TabIndex = 9;
            this.btn_abrirReporte.Text = "Abrir Reporte";
            this.btn_abrirReporte.UseVisualStyleBackColor = false;
            this.btn_abrirReporte.Click += new System.EventHandler(this.btn_abrirReporte_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTool_Configuracion,
            this.btntool_Tester});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(406, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTool_Configuracion
            // 
            this.btnTool_Configuracion.Name = "btnTool_Configuracion";
            this.btnTool_Configuracion.Size = new System.Drawing.Size(83, 22);
            this.btnTool_Configuracion.Text = "Configuración";
            this.btnTool_Configuracion.Click += new System.EventHandler(this.btnTool_Configuracion_Click);
            // 
            // btntool_Tester
            // 
            this.btntool_Tester.Name = "btntool_Tester";
            this.btntool_Tester.Size = new System.Drawing.Size(37, 22);
            this.btntool_Tester.Text = "Tester";
            this.btntool_Tester.Visible = false;
            this.btntool_Tester.Click += new System.EventHandler(this.btntool_Tester_Click);
            // 
            // mtxt_FechaInicio
            // 
            this.mtxt_FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxt_FechaInicio.Location = new System.Drawing.Point(175, 152);
            this.mtxt_FechaInicio.Mask = "00/00/0000";
            this.mtxt_FechaInicio.Name = "mtxt_FechaInicio";
            this.mtxt_FechaInicio.Size = new System.Drawing.Size(192, 32);
            this.mtxt_FechaInicio.TabIndex = 11;
            this.mtxt_FechaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_FechaInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fecha Fin:";
            // 
            // mtxt_FechaFin
            // 
            this.mtxt_FechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxt_FechaFin.Location = new System.Drawing.Point(175, 215);
            this.mtxt_FechaFin.Mask = "00/00/0000";
            this.mtxt_FechaFin.Name = "mtxt_FechaFin";
            this.mtxt_FechaFin.Size = new System.Drawing.Size(192, 32);
            this.mtxt_FechaFin.TabIndex = 13;
            this.mtxt_FechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Formato: DD/MM/AAAA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Formato: DD/MM/AAAA";
            // 
            // FrmReportePacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 428);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtxt_FechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtxt_FechaInicio);
            this.Controls.Add(this.toolStrip1);
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
            this.Load += new System.EventHandler(this.FrmReportePacientes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel btnTool_Configuracion;
        private System.Windows.Forms.ToolStripLabel btntool_Tester;
        private System.Windows.Forms.MaskedTextBox mtxt_FechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxt_FechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}