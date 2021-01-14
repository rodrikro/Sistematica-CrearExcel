namespace Tester
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ConectaBD = new System.Windows.Forms.Button();
            this.btn_estatus = new System.Windows.Forms.Button();
            this.btn_GetTables = new System.Windows.Forms.Button();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.btn_GetColumns = new System.Windows.Forms.Button();
            this.txt_NombreTabla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_resultado = new System.Windows.Forms.DataGridView();
            this.btn_GenQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_numeroExpediente = new System.Windows.Forms.TextBox();
            this.btn_GetResultData = new System.Windows.Forms.Button();
            this.btn_GenExcel = new System.Windows.Forms.Button();
            this.txt_NombreMedico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ConectaBD
            // 
            this.btn_ConectaBD.Location = new System.Drawing.Point(38, 74);
            this.btn_ConectaBD.Name = "btn_ConectaBD";
            this.btn_ConectaBD.Size = new System.Drawing.Size(103, 23);
            this.btn_ConectaBD.TabIndex = 0;
            this.btn_ConectaBD.Text = "Conecta BD";
            this.btn_ConectaBD.UseVisualStyleBackColor = true;
            this.btn_ConectaBD.Click += new System.EventHandler(this.btn_ConectaBD_Click);
            // 
            // btn_estatus
            // 
            this.btn_estatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_estatus.FlatAppearance.BorderSize = 0;
            this.btn_estatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_estatus.Location = new System.Drawing.Point(540, 25);
            this.btn_estatus.Name = "btn_estatus";
            this.btn_estatus.Size = new System.Drawing.Size(122, 23);
            this.btn_estatus.TabIndex = 2;
            this.btn_estatus.UseVisualStyleBackColor = false;
            // 
            // btn_GetTables
            // 
            this.btn_GetTables.Location = new System.Drawing.Point(182, 74);
            this.btn_GetTables.Name = "btn_GetTables";
            this.btn_GetTables.Size = new System.Drawing.Size(103, 23);
            this.btn_GetTables.TabIndex = 4;
            this.btn_GetTables.Text = "GetTables";
            this.btn_GetTables.UseVisualStyleBackColor = true;
            this.btn_GetTables.Click += new System.EventHandler(this.btn_GetTables_Click);
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.Location = new System.Drawing.Point(38, 223);
            this.txt_respuesta.Multiline = true;
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_respuesta.Size = new System.Drawing.Size(247, 285);
            this.txt_respuesta.TabIndex = 5;
            // 
            // btn_GetColumns
            // 
            this.btn_GetColumns.Location = new System.Drawing.Point(182, 126);
            this.btn_GetColumns.Name = "btn_GetColumns";
            this.btn_GetColumns.Size = new System.Drawing.Size(103, 23);
            this.btn_GetColumns.TabIndex = 6;
            this.btn_GetColumns.Text = "GetColumns";
            this.btn_GetColumns.UseVisualStyleBackColor = true;
            this.btn_GetColumns.Click += new System.EventHandler(this.btn_GetColumns_Click);
            // 
            // txt_NombreTabla
            // 
            this.txt_NombreTabla.Location = new System.Drawing.Point(38, 128);
            this.txt_NombreTabla.Name = "txt_NombreTabla";
            this.txt_NombreTabla.Size = new System.Drawing.Size(138, 20);
            this.txt_NombreTabla.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre Tabla";
            // 
            // dtgv_resultado
            // 
            this.dtgv_resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_resultado.Location = new System.Drawing.Point(324, 223);
            this.dtgv_resultado.Name = "dtgv_resultado";
            this.dtgv_resultado.Size = new System.Drawing.Size(338, 285);
            this.dtgv_resultado.TabIndex = 9;
            // 
            // btn_GenQuery
            // 
            this.btn_GenQuery.Location = new System.Drawing.Point(182, 170);
            this.btn_GenQuery.Name = "btn_GenQuery";
            this.btn_GenQuery.Size = new System.Drawing.Size(103, 23);
            this.btn_GenQuery.TabIndex = 10;
            this.btn_GenQuery.Text = "GenQuery";
            this.btn_GenQuery.UseVisualStyleBackColor = true;
            this.btn_GenQuery.Click += new System.EventHandler(this.btn_GenQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Numero Expediente";
            // 
            // txt_numeroExpediente
            // 
            this.txt_numeroExpediente.Location = new System.Drawing.Point(38, 170);
            this.txt_numeroExpediente.Name = "txt_numeroExpediente";
            this.txt_numeroExpediente.Size = new System.Drawing.Size(138, 20);
            this.txt_numeroExpediente.TabIndex = 11;
            this.txt_numeroExpediente.Text = "1";
            // 
            // btn_GetResultData
            // 
            this.btn_GetResultData.Location = new System.Drawing.Point(324, 170);
            this.btn_GetResultData.Name = "btn_GetResultData";
            this.btn_GetResultData.Size = new System.Drawing.Size(338, 23);
            this.btn_GetResultData.TabIndex = 13;
            this.btn_GetResultData.Text = "GetResult";
            this.btn_GetResultData.UseVisualStyleBackColor = true;
            this.btn_GetResultData.Click += new System.EventHandler(this.btn_GetResultData_Click);
            // 
            // btn_GenExcel
            // 
            this.btn_GenExcel.Location = new System.Drawing.Point(324, 125);
            this.btn_GenExcel.Name = "btn_GenExcel";
            this.btn_GenExcel.Size = new System.Drawing.Size(338, 23);
            this.btn_GenExcel.TabIndex = 14;
            this.btn_GenExcel.Text = "Genera Excel";
            this.btn_GenExcel.UseVisualStyleBackColor = true;
            this.btn_GenExcel.Click += new System.EventHandler(this.btn_GenExcel_Click);
            // 
            // txt_NombreMedico
            // 
            this.txt_NombreMedico.Location = new System.Drawing.Point(324, 99);
            this.txt_NombreMedico.Name = "txt_NombreMedico";
            this.txt_NombreMedico.Size = new System.Drawing.Size(338, 20);
            this.txt_NombreMedico.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nombre del Médico";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 520);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_NombreMedico);
            this.Controls.Add(this.btn_GenExcel);
            this.Controls.Add(this.btn_GetResultData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_numeroExpediente);
            this.Controls.Add(this.btn_GenQuery);
            this.Controls.Add(this.dtgv_resultado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NombreTabla);
            this.Controls.Add(this.btn_GetColumns);
            this.Controls.Add(this.txt_respuesta);
            this.Controls.Add(this.btn_GetTables);
            this.Controls.Add(this.btn_estatus);
            this.Controls.Add(this.btn_ConectaBD);
            this.Name = "Form1";
            this.Text = "Tester";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_resultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ConectaBD;
        private System.Windows.Forms.Button btn_estatus;
        private System.Windows.Forms.Button btn_GetTables;
        private System.Windows.Forms.TextBox txt_respuesta;
        private System.Windows.Forms.Button btn_GetColumns;
        private System.Windows.Forms.TextBox txt_NombreTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_resultado;
        private System.Windows.Forms.Button btn_GenQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_numeroExpediente;
        private System.Windows.Forms.Button btn_GetResultData;
        private System.Windows.Forms.Button btn_GenExcel;
        private System.Windows.Forms.TextBox txt_NombreMedico;
        private System.Windows.Forms.Label label3;
    }
}

