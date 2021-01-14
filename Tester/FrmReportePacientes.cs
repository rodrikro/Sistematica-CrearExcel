using OfficeInterceptor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tester
{
    public partial class FrmReportePacientes : Form
    {
        int Segundos = 0;
        public FrmReportePacientes()
        {
            InitializeComponent();
        }

        private void btn_GenerarReporte_Click(object sender, EventArgs e)
        {
            ExcelUtils excel = new ExcelUtils();
            string mensaje = "";
            string rutaExcel = "";
            string numeroExpediente = "0";
            string nombreMedico = string.Empty;

            try
            {
                this.Segundos = 0;
                lbl_cargando.Visible = true;

                numeroExpediente = (string.IsNullOrEmpty(txt_NumeroExpediente.Text)) ? "0" : txt_NumeroExpediente.Text;
                nombreMedico = (string.IsNullOrEmpty(txt_NombreMedico.Text)) ? string.Empty : txt_NombreMedico.Text;

                rutaExcel = excel.GeneraExcel(int.Parse(numeroExpediente), nombreMedico,
                    out mensaje, "", "");

                if (!string.IsNullOrEmpty(mensaje))
                {
                    txt_Resultado.Text = mensaje;
                }
                else
                {
                    txt_Resultado.Text = rutaExcel;

                }
            }
            catch (Exception ex)
            {
                txt_Resultado.Text = ex.Message;
            }
            finally 
            {
                lbl_cargando.Visible = false;
            }
            
            
        }

        
        private void TextoLoading(int segundos) 
        {
            string texto = "";
            float residuo = 0;

            if (segundos>1) 
            {
                //Puede ser 2 o 3
                residuo = segundos % 2;
                if (residuo == 0)
                {
                    texto = "Cargando . . ";
                }
                else 
                {
                    residuo = segundos % 3;
                    if (residuo == 0)
                    {
                        texto = "Cargando . . . ";
                    }
                    else
                    {
                        texto = "Cargando . ";
                    }
                }
            }
            else
            {
                texto = "Cargando . ";
            }
            lbl_cargando.Text = texto;

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Segundos++;
            TextoLoading(this.Segundos);
        }

        private void btn_Tester_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
