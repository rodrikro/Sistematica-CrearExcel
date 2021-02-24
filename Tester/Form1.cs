using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OfficeInterceptor;
using OfficeInterceptor.Models;

namespace Tester
{
    public partial class Form1 : Form
    {
        List<string> _listaNombresTablas = null;
        List<string> _listaNombresColumnas = null;
        string _query = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ConectaBD_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            //public InfoDB(string src = "C:/CS/CardioSys.mdb", string user = "sf", string pwd = "sfa080808528") 
            DBConnectClass db = new DBConnectClass("C:/CS/CardioSys.mdb", "sfa080808528");
            
            bool ok = db.Conecta(out mensaje);

            botonEstatus(ok);
            //MessageBox.Show(ok.ToString()+" /mensaje:\n"+mensaje, "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_respuesta.Text = "";
            txt_respuesta.Text = mensaje;

        }

        private void btn_GetTables_Click(object sender, EventArgs e)
        {
            InfoDB info = new InfoDB();

            try
            {
                string listaTablas = "";
                this._listaNombresTablas = info.GetTables();

                foreach (var item in this._listaNombresTablas)
                {
                    listaTablas += item + Environment.NewLine;
                }

                txt_respuesta.Text = "";
                txt_respuesta.Text = listaTablas;

                botonEstatus(true);

            }
            catch (Exception ex)
            {
                txt_respuesta.Text = ex.Message;
                botonEstatus(false);

            }

        }

        private void botonEstatus(bool ok)
        {
            Color colorEstatus = new Color();

            if (ok) { colorEstatus = Color.Green; }
            else { colorEstatus = Color.Red; }

            btn_estatus.BackColor = colorEstatus;
        }

        private void btn_GetColumns_Click(object sender, EventArgs e)
        {
            InfoDB info = new InfoDB();

            try
            {
                string listaColumnas = "";
                this._listaNombresColumnas = info.GetColumns(txt_NombreTabla.Text);

                foreach (var item in this._listaNombresColumnas)
                {
                    listaColumnas += item + "," + Environment.NewLine;
                }

                txt_respuesta.Text = "";
                txt_respuesta.Text = listaColumnas;

                botonEstatus(true);

            }
            catch (Exception ex)
            {
                txt_respuesta.Text = ex.Message;
                botonEstatus(false);

            }
        }

        private void btn_GenQuery_Click(object sender, EventArgs e)
        {
            InfoDB info = new InfoDB();

            try
            {
                this._query = info.GeneraQuery(txt_NombreTabla.Text,_listaNombresColumnas.ToArray(), txt_numeroExpediente.Text);

                txt_respuesta.Text = this._query;


                botonEstatus(true);

            }
            catch (Exception ex)
            {
                txt_respuesta.Text = ex.Message;
                botonEstatus(false);

            }
        }

        private void btn_GetResultData_Click(object sender, EventArgs e)
        {
            InfoDB info = new InfoDB();

            try
            {
                var dt = info.GetDatos(this._query);

                dtgv_resultado.DataSource = dt;
                botonEstatus(true);

            }
            catch (Exception ex)
            {
                txt_respuesta.Text = ex.Message;
                botonEstatus(false);

            }
        }

        private void btn_GenExcel_Click(object sender, EventArgs e)
        {
            ExcelUtils excel = new ExcelUtils("");
            string mensaje = "";
            string rutaExcel = "";
            string numeroExpediente = "0";

            try
            {
                numeroExpediente = (string.IsNullOrEmpty(txt_numeroExpediente.Text)) ? "0" : txt_numeroExpediente.Text;

                rutaExcel = excel.GeneraExcel( int.Parse(numeroExpediente) , txt_NombreMedico.Text,
                    out mensaje,"","","","");

                txt_respuesta.Text = rutaExcel;
                botonEstatus(true);

                if (!string.IsNullOrEmpty(mensaje)) 
                {
                    txt_respuesta.Text = mensaje;
                    botonEstatus(false);
                }

            }
            catch (Exception ex)
            {
                botonEstatus(false);
                txt_respuesta.Text = ex.Message;
            }


        }
    }
}
