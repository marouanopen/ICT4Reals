using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                query += " statusStatusID =" + StatusID + " WHERE TramTramID = "+ tramID; 
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public List<Dictionary<string, object>> GetAllStatus() //name of ur query
        {
            List<Dictionary<string, object>> ret = getQuery("SELECT TramTramID, StatusStatusID FROM gebruiker WHERE GebruikerID = 5"); 
            return ret;     //this will return the list as result from the query.
        }
        /// <summary>
        /// update trams after repair
        /// </summary>
        /// <param name="tramID">current tram id</param>
        /// <param name="date">current date</param>
        /// <returns></returns>
        public bool updateLog(int tramID, DateTime date)
        {
            try
            {
                string query;
                query = "UPDATE Beurt SET";
                query += "einddatum =" + date + " WHERE TramID = " + tramID;
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

    }
}
