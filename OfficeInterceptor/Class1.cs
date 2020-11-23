using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace OfficeInterceptor
{
    public class Class1
    {
        public Class1() { }

        private void excelGen()
        {
            //Construccion de excel e instancia de objeto
            Excel.Application excel = new Excel.Application();
            Excel._Workbook libro = null;
            Excel._Worksheet hoja = null;
            Excel.Range rango = null;

            //Creacion de libro, y hoja de trabajo
            libro = (Excel._Workbook)excel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            hoja = (Excel._Worksheet)libro.Worksheets.Add();
            hoja.Name = "Reporte";
            ((Excel.Worksheet)excel.ActiveWorkbook.Sheets["Hoja1"]).Delete();

            //Ejemplo de excel
            hoja.Cells[1, 2] = "Ejemplo de excel";

            hoja.Cells[3, 2] = "Codigo";
            hoja.Cells[3, 2] = "descripcion";
            hoja.Cells[3, 2] = "observaciones";

            //Borde para celdas
            rango = hoja.Range["B3", "D3"];
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            //centrar texto
            rango = hoja.Rows[3];
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rango = hoja.Columns[1];
            rango.ColumnWidth = 1;

            rango = hoja.Columns[2];
            rango.ColumnWidth = 10;

            rango = hoja.Columns[3];
            rango.ColumnWidth = 20;

            rango = hoja.Columns[4];
            rango.ColumnWidth = 20;

            libro.Saved = true;
            libro.SaveAs(Environment.CurrentDirectory + @"\Ejemplo.xlsx");


            //Liberarlo de la RAM
            libro.Close();
            releaseObject(libro);

            excel.UserControl = false;
            excel.Quit();
            releaseObject(excel);
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
