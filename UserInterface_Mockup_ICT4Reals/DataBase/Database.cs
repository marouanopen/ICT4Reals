using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Types;



namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    public class Database
    {
        //fields
        private OracleConnection con;

        /// <summary>
        /// constructor
        /// </summary>

        public Database()
        {
        }

        /// <summary>
        /// doQuery
        /// </summary>
        /// <param name="query">here u need to insert your query </param>
        /// <returns></returns>
        protected int doQuery(string query)
        {
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                OracleTransaction transact = cmd.Connection.BeginTransaction();
                cmd.Transaction = transact;
                int ret = cmd.ExecuteNonQuery();
                transact.Commit();
                Disconnect();
                return ret;

            }
            catch (Exception e) { Console.WriteLine(e.ToString()); return -1; }
            finally { Disconnect(); }
        }

        #region GetQuery
        /// <summary>
        /// GetQuery
        /// </summary>
        /// <param name="query">here u need to insert your query</param>
        /// <returns></returns>
        protected List<Dictionary<string, object>> getQuery(string query)
        {
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                bool read = false;

                OracleDataReader data = cmd.ExecuteReader();


                while (data.Read())
                {
                    read = true;
                    Dictionary<string, object> d = new Dictionary<string, object>();
                    for (int c = 0; c < data.FieldCount; c++)
                        d.Add(data.GetName(c).ToLower(), data.GetValue(c));


                    ret.Add(d);
                }

                if(!read)
                {
                    throw new Exception("An open connection is already active");
                }

                Disconnect();
                return ret;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Dictionary<string, object>>();
            }
            finally { Disconnect(); }
        }
#endregion

        /// <summary>
        /// Connect
        /// </summary>
        private void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = "Data Source=fhictora01.fhict.local/fhictora;Persist Security Info=True;User ID=dbi310866;Password=O4g03ym3r8";
            //con.ConnectionString = "Data Source=172.21.136.11:1521/xe;Persist Security Info=True;User ID=system;Password=vbNEA73jMt";
            con.Open();
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        private void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public List<string> QueryName() //name of ur query
        {
            List<string> ret = new List<string>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT naam FROM gebruiker WHERE GebruikerID = 1"); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                ret.Add((Convert.ToString(results["naam"]))); //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret;     //this will return the list as result from the query.
        }
    }

}

