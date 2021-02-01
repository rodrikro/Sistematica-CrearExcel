using OfficeInterceptor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Diagnostics;

namespace Tester
{
    public partial class FrmReportePacientes : Form
    {
        int Segundos = 0;
        string _rutaExcel = string.Empty;
        public FrmReportePacientes()
        {
            InitializeComponent();
        }

        private void btn_GenerarReporte_Click(object sender, EventArgs e)
        {
            GeneraReporte();
        }

        private void GeneraReporte()
        {
            string mensaje = "";
            string rutaExcel = "";
            string numeroExpediente = "0";
            string nombreMedico = string.Empty;

            string srcDB = "";
            string pwdDB = "";

            try
            {
                // --------------------------------------------------
                this.Segundos = 0;
                lbl_cargando.Visible = true;
                lbl_estatus.Text = "";
                btn_GenerarReporte.Enabled = false;
                btn_abrirReporte.Enabled = false;
                // --------------------------------------------------
                numeroExpediente = (string.IsNullOrEmpty(txt_NumeroExpediente.Text)) ? "0" : txt_NumeroExpediente.Text;
                nombreMedico = (string.IsNullOrEmpty(txt_NombreMedico.Text)) ? string.Empty : txt_NombreMedico.Text;
                // --------------------------------------------------

                var appSettings = ConfigurationSettings.AppSettings;
                string result = appSettings["srcDB"] ?? "C:/SF/CardioSys/CardioSys.mdb";


                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                string rutaGuardado = conf.AppSettings.Settings["rutaGuardado"].Value ?? Environment.CurrentDirectory;
                
                // --------------------------------------------------
                ExcelUtils excel = new ExcelUtils(rutaGuardado);
                // --------------------------------------------------
                srcDB = result;

                // --------------------------------------------------
                // --------------------------------------------------
                rutaExcel = excel.GeneraExcel(int.Parse(numeroExpediente), nombreMedico,
                    out mensaje, srcDB, pwdDB);

                this._rutaExcel = rutaExcel;

                if (!string.IsNullOrEmpty(mensaje))
                {
                    txt_Resultado.Text = mensaje;
                }
                else
                {
                    lbl_estatus.Text = "Reporte Generado en la ruta: ";
                    txt_Resultado.Text = rutaExcel;
                    btn_abrirReporte.Enabled = true;
                    AbrirArchivo(rutaExcel);
                    



                }
            }
            catch (Exception ex)
            {
                txt_Resultado.Text = ex.Message;
            }
            finally
            {    
                lbl_cargando.Visible = false;
                btn_GenerarReporte.Enabled = true;
            }
        }
        
        private void AbrirArchivo(string ruta)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = "EXCEL.EXE";
            //startInfo.Arguments = f;
            Process.Start(ruta);
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

        private void txt_NumeroExpediente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                GeneraReporte();
            }
        }

        private void btn_abrirReporte_Click(object sender, EventArgs e)
        {
            AbrirArchivo(this._rutaExcel);
        }

        private void btntool_Tester_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnTool_Configuracion_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema frm = new ConfiguracionSistema();
            frm.Show();
        }
    }
}
