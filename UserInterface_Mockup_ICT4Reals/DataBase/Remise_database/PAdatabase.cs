using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.Remise;
using UserInterface_Mockup_ICT4Reals.AdminSystem;
using UserInterface_Mockup_ICT4Reals.DataBase;
using System.Windows.Forms;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class PAdatabase : Database
    {
        /// <summary>
        /// fields
        /// </summary>
        Database database = new Database();

        public List<Dictionary<string, object>> GetTramInfo(int TramId)
        {
            List<Dictionary<string, object>> TramInfo= getQuery("SELECT TramID, SpoorID, TypeID, AanwezigOpSpoor FROM Tram WHERE TramID = " + TramId);

            return TramInfo;
        }
        public List<Dictionary<string, object>> GetRailInfo(int RailId)
        {
            List<Dictionary<string, object>> RailInfo = getQuery("SELECT SpoorID, Blokkeer, RemiseID FROM Tram WHERE SpoorID = " + RailId);
            return RailInfo;
        }
        /// <summary>
        /// creates a new service in the database (not a instance of service)
        /// </summary>
        /// <param name="tramid">id of the tram that has the service registered to it</param>
        /// <param name="kind">the kind of service ()</param>
        /// <returns>return bool</returns>
        public bool MakeService(int tramid, string kind)
        {
            int id = 1;
            try
            {
                List<Dictionary<string, object>> services = GetAllServices();
                foreach (Dictionary<string, object> beurt in services)
                {
                    id++;
                }
                string query; // the query will end up in here
                query = "insert into beurt(BeurtID, Soort, BeginDatum, Einddatum, TramID, SuperBeurtID) Values("+ id +", '" + kind + "', to_date('" + DateTime.Now.ToString("MM-dd-yyyy hh:mm") + "','MM-DD-YYYY hh24:MI'), null, " + tramid + ", null)";  //replace with INSERT if need
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        /// <summary>
        /// gets all services from the database
        /// </summary>
        /// <returns>all the services that are known in the database</returns>
        public List<Dictionary<string, object>> GetAllServices() //name of ur query
        {
            List<Dictionary<string, object>> services = getQuery("SELECT * FROM beurt"); //replace your query with te example query, replace 'QueryX' with a clear name.
            return services;     //this will return the list as result from the query.
        } 
        /// <summary>
        /// updates the trampart of the database (tram, tram_status, and rail)
        /// </summary>
        /// <param name="tramnr">the id of the tram that should be updated</param>
        /// <returns>bool that indicates if the action has succeeded</returns>
        public bool RefreshTramdatabase(int tramnr)
        {
            string query; // the query will end up in here
            int type = 0;
            int onrail;

            foreach(Tram t in Administration.GetTramList)
            {
                
                if(t.Id == tramnr)
                {
                        if (t.Type == "Combino")
                        {
                            type = 1;
                        }
                        if (t.Type == "11G")
                        {
                            type = 2;
                        }
                        if (t.Type == "Dubbel kop combino")
                        {
                            type = 3;
                        }
                        if (t.Type == "12G")
                        {
                            type = 4;
                        }
                        if (t.Type == "Opleidingstrams")
                        {
                            type = 5;
                        }
                        if (!t.OnRail)
                        {
                            onrail = 0;
                        }
                        else
                        {
                            t.OnRail = true;
                            onrail = 1;
                        }
                        query = "Update tram set TramID = " + t.Id + ", SpoorID = " + t.Rail.Id + ", TypeID = " + type + ", AanwezigOpSpoor = " + onrail + " where tramid = " + t.Id;  //replace with INSERT if need
                        doQuery(query); //query will be activated
                        //doquery update status 
                        query = "update tram_status set tramtramid = " + t.Id + ", statusstatusid = " + (int)t._Status + "where tramtramid = " + t.Id;
                        doQuery(query);
                        return true;
                }
            }
            return false;
            
        }
        
    }
}
