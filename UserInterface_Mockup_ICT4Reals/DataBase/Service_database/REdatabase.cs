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
            List<Dictionary<string, object>> ret = getQuery("SELECT naam FROM gebruiker WHERE GebruikerID = 5"); 
            return ret;     //this will return the list as result from the query.
        }

    }
}
