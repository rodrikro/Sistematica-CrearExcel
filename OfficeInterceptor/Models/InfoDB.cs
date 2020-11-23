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

        public PacienteClass GetPaciente(string query)
        {
            DataTable dtResultado = new DataTable();
            DataSet dsResultado = new DataSet();

            PacienteClass O = new PacienteClass();

            try
            {
                string mensaje = "";
                bool ok = this._db.Conecta(out mensaje);

                if (!ok)
                {
                    return O;
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

            return O;
        }


        public string GeneraQuery(string tabla, string [] columnas, string numeroExpediente)
        {
            string query = "";
            string strColumnas = "";

            foreach (string col in columnas)
            {
                strColumnas += col + ",";
            }


            query += " SELECT " + strColumnas.TrimEnd(',');
            query += " FROM " + tabla;
            query += " WHERE NumeroExpediente = "+numeroExpediente;

            return query;
        }
    }
}
