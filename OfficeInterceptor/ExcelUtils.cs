using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using OfficeInterceptor.Clases;
using OfficeInterceptor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

//using Microsoft.CSharp.RuntimeBinder;
//using Excel = Microsoft.Office.Interop.Excel;



namespace OfficeInterceptor
{
    public class ExcelUtils
    {
        public ExcelUtils() { }

        /// <summary>
        /// Obtiene una ruta en formato STRING de un fichero de excel generado por paciente.
        /// </summary>
        /// <param name="numeroExpediente"></param>
        /// <param name="nombreMedico"></param>
        /// <param name="mensaje"></param>
        /// <param name="srcDB"></param>
        /// <param name="pwdDB"></param>
        /// <returns></returns>
        public string GeneraExcel(int numeroExpediente, string nombreMedico,  out string mensaje, string srcDB, string pwdDB)
        {
            mensaje = "";
            string rutaExcel = "";

            //Para no batallar en debug
            srcDB = string.IsNullOrEmpty(srcDB) ? "C:/CS/CardioSys.mdb" : srcDB;
            pwdDB = string.IsNullOrEmpty(pwdDB) ? "sfa080808528" : pwdDB;

            InfoDB info = new InfoDB(srcDB, pwdDB);

            List<DataTable> listaDTResultados = new List<System.Data.DataTable>();
            PacienteClass paciente = new PacienteClass();

            try
            {
                //Paso 1. Obtener Nombres de tablas
                List<string> listaTablas = new List<string>();
                listaTablas = info.GetTables();

                //Paso 2. Renombra tablas para presentar en excel
                //string[,] renombreTablas = RenombraTablas(listaTablas);

                //Paso 3. Recorrer las tablas
                foreach (string tableName in listaTablas)
                {
                    //Paso 4. Al Recorrer Tablas obtener sus columnas
                    List<string> listaColumnas = new List<string>();
                    listaColumnas = info.GetColumns(tableName);

                    //Paso 5. Construir query por cada tabla usando el numero de expediente
                    string query = info.GeneraQuery(tableName, listaColumnas.ToArray(), numeroExpediente.ToString());



                    //Paso 6. Obtener datos por cada tabla
                    System.Data.DataTable dt = info.GetDatos(query);
                    listaDTResultados.Add(dt);

                    //Paso 6.1 Obtiene datos de paciente
                    if (tableName.Contains("DatosPaciente"))
                    {
                        paciente = info.GetPaciente(query);
                    }

                }


                //Paso 6. Construye el excel y obtiene la ruta
                //rutaExcel = ConstruyeExcel(listaDTResultados, listaTablas,numeroExpediente, renombreTablas);
                rutaExcel = ConstruyeExcel(listaDTResultados, listaTablas, numeroExpediente, paciente, nombreMedico);

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return rutaExcel;
        }

        private string ConstruyeExcel(List<DataTable> dtResultados, List<string> listaTablas, int numeroExpediente, 
            PacienteClass paciente, string nombreMedico)
        {
            //string paciente = "Exp " + numeroExpediente.ToString();
            string fecha = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            string nombreArchivo = "Exp " + numeroExpediente + " " + paciente.Nombre + "_" + fecha;
            string pathFile = Environment.CurrentDirectory + @"\" + nombreArchivo +".xlsx";
            string rutaExcel = "ConstruyeExcel";

            int row = 1, col = 1;
            int maximRow = 0, maximCol = 0;

            try
            {
                //Crea documento de excel
                using (var workbook = new XLWorkbook())
                {
                    //Crea hoja de trabajo en documento de excel
                    var hoja = workbook.Worksheets.Add("Reporte");

                    //Titulo 
                    hoja.Cell(row, 3).Value = "EXPEDIENTE CLÍNICO";
                    hoja.Cell(row, 3).Style.Font.Bold = true;
                    hoja.Cell(row, 3).Style.Font.FontSize = 16;

                    row = row + 2;

                    //Datos del paciente
                    hoja.Cell(row, 1).Value = "PACIENTE: ";
                    hoja.Cell(row, 1).Style.Font.FontSize = 14;
                    hoja.Cell(row, 3).Value = paciente.Nombre;
                    hoja.Cell(row, 3).Style.Font.FontSize = 14;
                    hoja.Cell(row, 8).Value = "EXPEDIENTE: ";
                    hoja.Cell(row, 8).Style.Font.FontSize = 14;
                    hoja.Cell(row, 10).Value = paciente.NumeroExpediente;
                    hoja.Cell(row, 10).Style.Font.FontSize = 14;

                    row = row + 1;
                    //Datos del Medico
                    hoja.Cell(row, 1).Value = "MEDICO: ";
                    hoja.Cell(row, 1).Style.Font.FontSize = 14;
                    hoja.Cell(row, 3).Value = nombreMedico;
                    hoja.Cell(row, 3).Style.Font.FontSize = 14;

                    //Fecha
                    hoja.Cell(row, 8).Value = "FECHA: ";
                    hoja.Cell(row, 8).Style.Font.FontSize = 14;
                    DateTime fechaActual = DateTime.Now;
                    string fechaValue = fechaActual.ToString("dd MMM yyyy");
                    hoja.Cell(row, 10).Value = fechaValue;
                    hoja.Cell(row, 10).Style.Font.FontSize = 14;

                    //Ayuda para excel
                    row = row + 1;

                    //Contador para nombre de tablas
                    int contadorNombreTablas = 0;
                    foreach (DataTable dt in dtResultados)
                    {
                        row = row + 1;
                        //string nombreTabla = listaTablas.ToArray()[contadorNombreTablas];
                        string nombreTablaActual = listaTablas.ToArray()[contadorNombreTablas];

                        string nombreTabla = RenombraTablas(listaTablas, nombreTablaActual);

                        hoja.Cell(row, 1).Value = "" + nombreTabla +": ";
                        hoja.Cell(row, 1).Style.Fill.BackgroundColor = XLColor.Orange;
                        hoja.Cell(row, 1).Style.Font.FontColor = XLColor.White;
                        hoja.Cell(row, 1).Style.Font.Bold = true;

                        //Aumenta row para poner las columnas
                        row = row + 1;

                        //Obtiene las columnas de la tabla
                        for (int i = 1; i <= dt.Columns.Count; i++)
                        {
                            string colTitulo = dt.Columns[(i - 1)].ToString();
                            hoja.Cell(row, i).Value = colTitulo;

                            maximRow = (maximRow < row) ? row : maximRow;
                            maximCol = (maximCol < i) ? i : maximCol;
                        }

                        //Aumenta row para poner los datos
                        row = row + 1;
                        for (int i = 1; i <= dt.Columns.Count; i++)
                        {
                            string valor = dt.Rows[0][(i - 1)].ToString();
                            hoja.Cell(row, i).Value = valor;
                        }

                        //Aumenta row para poner otra tabla
                        contadorNombreTablas++;
                        row = row + 2;
                    }
                    workbook.SaveAs(pathFile);

                }

                rutaExcel = pathFile;
            }
            catch (Exception ex) 
            {
                rutaExcel = "";
                throw; 
            }
            finally { }

            return rutaExcel;
        }

        private void GetPaciente()
        {

        }


        private string RenombraTablas(List<string> listaTablas, string nombreTablaActual)
        {
            string[,] nombreTablasRenombradas = null;
            string nombreTablaExcel = "";
                
            try
            {
                nombreTablasRenombradas = new string[2, listaTablas.Count];

                for (int i = 0; i < listaTablas.Count; i++)
                {
                    switch (nombreTablaActual)
                    {
                        case "AntecedentesCardio":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "ANTECEDENTES CARDIOVASCULARES";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "AntecedentesPato":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "ANTECEDENTES PATOLOGICOS";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "AspectosTecnicos":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "ASPECTOS TECNICOS DE INTERVENCIONISMO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Cateterismo":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "INDICACION DE CATETERISMO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "CodigoInfarto":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "CODIGO INFARTO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Complicaciones":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "COMPLICACIONES DEL PROCEDIMIENTO INTERVENCIONISTA";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "DatosPaciente":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "DATOS PACIENTE";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "EscalasRiesgo":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "ESCALAS DE RIESGO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Hemodinamia":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "REPORTE DE HEMODINAMIA";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Ivus":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "IVUS DIAGNOSTIVO / IVUS POST ICP";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Laboratorio":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "LABORATORIO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Medicacion":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "MEDICACION";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Paraclinicos":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "PARACLINICOS Y ESTRATIFICACION";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "PresentacionClinica":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "ANTECEDENTES CARDIOVASCULARES";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Presiones":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "PRESIONES";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                        case "Seguimiento":
                            nombreTablasRenombradas[0, i] = listaTablas.ToArray()[i];
                            nombreTablasRenombradas[1, i] = "SEGUIMIENTO";
                            nombreTablaExcel = nombreTablasRenombradas[1, i];
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                nombreTablasRenombradas = new string[1, 1];
                throw;
            }
            finally
            {

            }
            return nombreTablaExcel;

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
//Acordeon
//https://github.com/ClosedXML/ClosedXML