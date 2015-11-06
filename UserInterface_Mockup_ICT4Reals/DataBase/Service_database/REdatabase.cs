using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class REdatabase : Database
    {
        public bool updateRepair(int tramID, int StatusID)
        {
            try
            {

                string query;
                query = "UPDATE tram_status SET";
                query += " statusStatusID =" + StatusID + " WHERE TramTramID = " + tramID;
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        public bool controleMax()
        {
            int bigcount = 0;
            int smallcount = 0;

            List<Dictionary<string, object>> ret = GetAlllogs();
            foreach (Dictionary<string, object> logs in ret)
            {
                if (Convert.ToString(logs["type"]) == "groot" && Convert.ToString(logs["soort"]) == "schoonmaak")
                {
                    bigcount++;
                }
                if (Convert.ToString(logs["type"]) == "klein" && Convert.ToString(logs["soort"]) == "schoonmaak")
                {
                    smallcount++;
                }
                if( smallcount > 4 || bigcount > 1)
                {
                    return false;
                }
                    
                
            }
            return true;
        }


        public List<Dictionary<string, object>> GetAllStatus() //name of ur query
        {
            List<Dictionary<string, object>> ret = getQuery("SELECT TramTramID, StatusStatusID FROM tram_status WHERE statusStatusID = 3 OR statusStatusID = 4 ");
            return ret;     //this will return the list as result from the query.
        }
        /// <summary>
        /// update trams after repair
        /// </summary>
        /// <param name="tramID">current tram id</param>
        /// <param name="date">current date</param>
        /// <returns></returns>
        public bool updateLog(int tramID, DateTime date, int superbeurt)
        {
            try
            {
                string query;
                query = "UPDATE Beurt SET";
                query +=  "einddatum = to_date('" + date.ToString("MM-dd-yyyy") + "','MM-DD-YYYY') , superbeurt =" + superbeurt + "WHERE TramID = " + tramID;
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        public List<Dictionary<string, object>> GetAlllogs() //name of ur query
        {
            List<Dictionary<string, object>> ret = getQuery("SELECT * FROM beurt WHERE soort = reparatie");
            return ret;     //this will return the list as result from the query.
        }

    }
}
