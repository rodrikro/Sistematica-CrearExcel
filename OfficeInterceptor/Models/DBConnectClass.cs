using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace OfficeInterceptor.Models
{
    public class DBConnectClass
    {
        string conectionString = "";
        public OleDbConnection con;

        /// <summary>
        /// src = C:\\CS\\CardioSys.mdb
        //  user = sf
        //  Pwd = sfa080808528
        /// </summary>
        /// <param name="src"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public DBConnectClass(string src, string pwd, string user = "sf")//string src = "C:/CS/CardioSys.mdb", string user = "sf", string pwd= "sfa080808528"
        {
            //https://social.msdn.microsoft.com/Forums/es-ES/8d4c2cbd-c669-49f7-8ba6-79039f1a7d7c/error-de-conexin-a-base-de-datos-en-access-2007-cifrada?forum=netfxes

            string provider = "Microsoft.ACE.OLEDB.12.0";
            conectionString = String.Format(@"Provider={0};" + "Jet OLEDB:Database Password={1}; " + "Data Source={2}",
                provider, pwd, src);
        }

        public bool Conecta(out string msg)
        {
            msg = "";
            bool ok = false;
            try
            {
                this.con = new OleDbConnection(conectionString);
                this.con.Open();
                ok = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                ok = false;
            }

            return ok;

        }

        public bool Cerrar()
        {
            bool ok = false;
            try
            {
                con.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
            return ok;
        }

    }
}
