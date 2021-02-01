using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tester
{
    public partial class ConfiguracionSistema : Form
    {
        public ConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void btn_AbrirCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_RutaGuardado.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        
        private void UbicarCarpetaSistema()
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                string rutaGuardado = conf.AppSettings.Settings["rutaGuardado"].Value;


                txt_RutaGuardado.Text = rutaGuardado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
        private void ConfiguracionSistema_Load(object sender, EventArgs e)
        {
            UbicarCarpetaSistema();
        }

        private void btn_GuardarConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                conf.AppSettings.Settings["rutaGuardado"].Value = txt_RutaGuardado.Text;
                conf.Save(ConfigurationSaveMode.Full);

                MessageBox.Show("Ruta guardada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
