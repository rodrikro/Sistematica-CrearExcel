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
        string _rutaGuardado = Environment.CurrentDirectory;
        public ExcelUtils( string rutaGuardado ) 
        {
            this._rutaGuardado = (string.IsNullOrEmpty(rutaGuardado)) ? this._rutaGuardado : rutaGuardado;
        }

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
            srcDB = string.IsNullOrEmpty(srcDB) ? "C:/SF/CardioSys/CardioSys.mdb" : srcDB;
            pwdDB = string.IsNullOrEmpty(pwdDB) ? "sfa080808528" : pwdDB;

            InfoDB info = new InfoDB(srcDB, pwdDB);

            List<PacienteClass> LPacientes = new List<PacienteClass>();
            List<List<DataTable>> listaResultadosPorPaciente = new List<List<DataTable>>();

            List<DataTable> listaDTResultados = new List<System.Data.DataTable>();

            try
            {
                string query = string.Empty;
                int top = 3;

                //0. Obtener lista de pacientes consultados

                //1. Obtener columnas de la tabla "DatosPaciente"
                List<string> listaColumnas = new List<string>();
                listaColumnas = info.GetColumns("DatosPaciente");


                //2. Generar query de la tabla
                string numeroExpedienteStr = (numeroExpediente == 0) ? string.Empty : numeroExpediente.ToString();
                query = info.GeneraQuery("DatosPaciente", listaColumnas.ToArray(), numeroExpedienteStr);

                //3. Obtener los pacientes
                LPacientes = info.GetPacientes(query);


                //Paso 1. Obtener Nombres de tablas
                List<string> listaTablas = new List<string>();
                listaTablas = info.GetTables();

                //Recorre los pacientes
                foreach (PacienteClass paciente in LPacientes)
                {
                    listaDTResultados = new List<DataTable>();

                    //Paso 3. Recorrer las tablas
                    foreach (string tableName in listaTablas)
                    {
                        //Paso 4. Al Recorrer Tablas obtener sus columnas
                        listaColumnas = new List<string>();
                        listaColumnas = info.GetColumns(tableName);

                        //Paso 5. Construir query por cada tabla usando el numero de expediente
                        query = info.GeneraQuery(tableName, listaColumnas.ToArray(), paciente.NumeroExpediente);

                        //Paso 6. Obtener datos por cada tabla
                        System.Data.DataTable dt = info.GetDatos(query);
                        listaDTResultados.Add(dt);
                    }

                    listaResultadosPorPaciente.Add(listaDTResultados);
                }

                //Paso 7. Construye el excel y obtiene la ruta
                rutaExcel = ConstruyeExcel(listaResultadosPorPaciente, listaTablas, numeroExpediente, LPacientes, nombreMedico);

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return rutaExcel;
        }

        private string ConstruyeExcel(List<List<DataTable>> listaResultadosPorPaciente, List<string> listaTablas, int numeroExpediente, 
            List<PacienteClass> LPacientes, string nombreMedico)
        {
            PacienteClass [] arrayPacientes = LPacientes.ToArray();
            var arrayResultados = listaResultadosPorPaciente.ToArray();
            //List<System.Data.DataTable>[10]

            //string paciente = "Exp " + numeroExpediente.ToString();
            string fecha = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00");

            string nombreArchivo = "Exp " + numeroExpediente + " " + arrayPacientes[0].Nombre + "_" + fecha;

            nombreArchivo = (arrayPacientes.Length>1)? "Expedientes_" + fecha : nombreArchivo;

            //string pathFile = Environment.CurrentDirectory + @"\" + nombreArchivo +".xlsx";
            string pathFile = this._rutaGuardado + @"\" + nombreArchivo + ".xlsx";
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
                    hoja.RowHeight = 20;
                    //Titulo 
                    hoja.Cell(row, 3).Value = "EXPEDIENTE CLÍNICO";
                    hoja.Cell(row, 3).Style.Font.Bold = true;
                    hoja.Cell(row, 3).Style.Font.FontSize = 16;

                    row++;
                    row++;
                    for (int i = 0; i < arrayPacientes.Length; i++)
                    {
                        
                        //Datos del paciente
                        hoja.Cell(row, 1).Value = "PACIENTE: ";
                        hoja.Cell(row, 1).Style.Font.FontSize = 14;
                        hoja.Cell(row, 3).Value = arrayPacientes[i].Nombre;
                        hoja.Cell(row, 3).Style.Font.FontSize = 14;
                        hoja.Cell(row, 3).Style.Fill.BackgroundColor = XLColor.Green;
                        hoja.Cell(row, 3).Style.Font.FontColor = XLColor.White;

                        hoja.Cell(row, 8).Value = "EXPEDIENTE: ";
                        hoja.Cell(row, 8).Style.Font.FontSize = 14;
                        hoja.Cell(row, 10).Value = arrayPacientes[i].NumeroExpediente;
                        hoja.Cell(row, 10).Style.Font.FontSize = 14;
                        hoja.Cell(row, 10).Style.Fill.BackgroundColor = XLColor.Green;
                        hoja.Cell(row, 10).Style.Font.FontColor = XLColor.White;

                        row++;
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

                        row++;

                        //Inicia la escritura de las tablas
                        int contadorNombreTablas = 0;

                        int colNombreTabla = 1;
                        int colTitulosTabla = 1;
                        int colDatosTabla = 1;

                        int rowNombreTabla = 0;
                        int rowTitulosTabla = 0;
                        int rowDatosPaciente = 0;


                        //Titulos de tabla
                        row = row + 1;
                        rowNombreTabla = row;

                        //Aumenta row para poner las columnas
                        row = row + 1;
                        rowTitulosTabla = row;

                        //Aumenta row para poner los datos
                        row = row + 1;
                        rowDatosPaciente = row;

                        foreach (DataTable dt in arrayResultados[i])
                        {
                            string nombreTablaActual = listaTablas.ToArray()[contadorNombreTablas];
                            string nombreTabla = RenombraTablas(listaTablas, nombreTablaActual);

                            hoja.Cell(rowNombreTabla, colNombreTabla).Value = "" + nombreTabla + ": ";
                            hoja.Cell(rowNombreTabla, colNombreTabla).Style.Fill.BackgroundColor = XLColor.Orange;
                            hoja.Cell(rowNombreTabla, colNombreTabla).Style.Font.FontColor = XLColor.White;
                            hoja.Cell(rowNombreTabla, colNombreTabla).Style.Font.Bold = true;

                            for (int t = 1; t <= dt.Columns.Count; t++)
                            {
                                string colTitulo = dt.Columns[(t - 1)].ToString();
                                hoja.Cell(rowTitulosTabla, colTitulosTabla).Value = colTitulo;

                                colNombreTabla++;
                                colTitulosTabla++;                                
                            }

                            for (int d = 1; d <= dt.Columns.Count; d++)
                            {
                                string valor = dt.Rows[0][(d - 1)].ToString();
                                hoja.Cell(rowDatosPaciente, colDatosTabla).Value = valor;
                                
                                colDatosTabla++;
                            }

                            //--------------------------------------------------------------------------
                            //Aumenta row para poner otra tabla
                            contadorNombreTablas++;

                        }
                        //--------------------------------------------------------------------------
                        colNombreTabla = 1;
                        colTitulosTabla = 1;
                        colDatosTabla = 1;
                        contadorNombreTablas = 0;
                        row = row + 2;
                    }



                    //Termina de construir el excel
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