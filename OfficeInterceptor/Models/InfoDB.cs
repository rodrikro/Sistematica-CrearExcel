using OfficeInterceptor.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace OfficeInterceptor.Models
{
    public class InfoDB 
    {
        DBConnectClass _db = null;

        //C:\CS
        //C:/SF/CardioSys/CardioSys.mdb
        public InfoDB(string src = "C:/CS/CardioSys.mdb", string pwd = "sfa080808528", string user = "sf") 
        {
            this._db = new DBConnectClass(src, pwd, user);
        }

        public List<string> GetTables()
        {
            List<string> nombreTablas = new List<string>();

            try
            {
                string mensaje = "";
                bool ok = this._db.Conecta(out mensaje);


                if (!ok)
                {
                    return nombreTablas;
                }

                DataTable userTables = null;



                string[] arrayTablasRestringidas = {
                    "Clinicas",
                    "DatosPacienteBuscar",
                    "Ligas",
                    "Materiales",
                    "MaterialesBuscar",
                    "Medicos",
                    "NumeroClinica",
                    "NumeroExpediente",
                    "NumeroMaterial",
                    "NumeroMedico",
                    "NumeroProveedor",
                    "Presiones2",
                    "Proveedores",
                    "Usuarios"
                };

                string[] restrictions = new string[4];

                restrictions[3] = "Table";

                userTables = this._db.con.GetSchema("Tables", restrictions);

                for (int i = 0; i < userTables.Rows.Count; i++)
                {
                    nombreTablas.Add(userTables.Rows[i][2].ToString());
                }


                for (int i = 0; i < nombreTablas.Count; i++)
                {
                    foreach (var restringidas in arrayTablasRestringidas)
                    {
                        if (nombreTablas[i] == restringidas)
                        {
                            nombreTablas.Remove(nombreTablas[i]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this._db.Cerrar();
            }

            return nombreTablas;
        }

        public List<string> GetColumns(string nombreTabla)
        {
            List<string> nombreColumnas = new List<string>();
            try
            {
                string mensaje = "";
                bool ok = this._db.Conecta(out mensaje);
                DataTable columnsTable = null;


                if (!ok)
                {
                    return nombreColumnas;
                }

                columnsTable = this._db.con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, 
                    new object[] { null, null, nombreTabla, null });

                for (int i = 0; i < columnsTable.Rows.Count; i++)
                {
                    nombreColumnas.Add(columnsTable.Rows[i][3].ToString());
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this._db.Cerrar();
            }
            return nombreColumnas;

        }

        public DataTable GetDatos( string query )
        {
            DataTable dtResultado = new DataTable();

            try
            {
                string mensaje = "";
                bool ok = this._db.Conecta(out mensaje);

                if (!ok)
                {
                    return dtResultado;
                }


                using (OleDbDataAdapter da =new OleDbDataAdapter(query, this._db.con))
                {
                    da.Fill(dtResultado);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this._db.Cerrar();
            }

            return dtResultado;
        }

        public List<PacienteClass> GetPacientes(string query)
        {
            DataTable dtResultado = new DataTable();
            DataSet dsResultado = new DataSet();
            List<PacienteClass> lista = new List<PacienteClass>();

            PacienteClass O = new PacienteClass();

            try
            {
                string mensaje = "";
                bool ok = this._db.Conecta(out mensaje);

                if (!ok)
                {
                    return lista;
                }


                using (OleDbDataAdapter da = new OleDbDataAdapter(query, this._db.con))
                {
                    da.Fill(dtResultado);
                }


                if (dtResultado.Rows.Count > 0)
                {

                    foreach (DataRow item in dtResultado.Rows)
                    {
                        O = new PacienteClass();
                        O.Numero = item["Numero"].ToString();
                        O.Nombre = item["Nombre"].ToString();
                        O.NumeroExpediente = item["NumeroExpediente"].ToString();
                        O.NSS = item["NSS"].ToString();
                        O.FechaExpediente = DateTime.Parse(item["FechaExpediente"].ToString());
                        O.Medico= item["Medico"].ToString();

                        lista.Add(O);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this._db.Cerrar();
            }

            return lista;
        }


        public string GeneraQuery(string tabla, string [] columnas, string numeroExpediente, int top = 0,
            string fechaInicio = "", string fechaFin = "")
        {
            string query = "";
            string strColumnas = "";

            foreach (string col in columnas)
            {
                strColumnas += col + ",";
            }

            if (top == 0)
            {
                query += " SELECT " + strColumnas.TrimEnd(',');
            }
            else
            {
                query += " SELECT TOP "+top.ToString() + " " + strColumnas.TrimEnd(',');
            }


            query += " FROM " + tabla;

            if (!string.IsNullOrEmpty(numeroExpediente) || numeroExpediente == "0")
            {
                query += " WHERE NumeroExpediente = "+numeroExpediente;
            }

            else if(!string.IsNullOrEmpty(fechaInicio)  && !string.IsNullOrEmpty(fechaFin))
            {
                //query += " WHERE NumeroExpediente = " + numeroExpediente;
                query += " WHERE FechaExpediente >= #" + formateaFecha(fechaInicio) +"#";
                query += " AND FechaExpediente <= #" + formateaFecha(fechaFin) +"#";

            }

            return query;
        }

        private string formateaFecha(string fecha)
        {
            //FORMATO: mm/dd/yyyy
            string fechaInglesa = "";

            var arregloFecha = fecha.Split('/');

            string dia = arregloFecha[0];
            string mes = arregloFecha[1];
            string anio = arregloFecha[2];

            fechaInglesa = mes+"/"+dia+"/"+anio;

            return fechaInglesa;
        }
    }
}
