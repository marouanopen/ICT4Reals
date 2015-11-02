using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class TRdatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramId">ID of the tram</param>
        /// <param name="railId">ID of the rail it's moved to</param>
        /// <returns></returns>
        public bool MoveTram(int tramId, int railId) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE Tram SET";  //replace with INSERT if needed
                query += " SpoorID = '" + railId + "' WHERE TramID = " + tramId; //replace 'user.X' with the data u need.
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public int TramOnRail(int tramId) // replace user with the data u want to add/ change to the table
        {
            int ret = 0; //result of query will end up in here
            List<Dictionary<string, object>> RailQuery = getQuery("SELECT SpoorID FROM Tram WHERE TramID =" + tramId);
            foreach (Dictionary<string, object> results in RailQuery) //look for all possible results in the query result.
            {
                ret = ((Convert.ToInt32(results["SpoorID"]))); //add each result to the created list
            }

            return ret;     //this will return the list as result from the query
        }

        public bool AddTram(int tramId, int lengte, int spoorId, int typeId)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO Tram(tramID, lengte, spoorID, typeID)";  //replace with INSERT if needed
                query += " VALUES('" + tramId + ", " + lengte + ", " + spoorId + ", " + typeId + "')"; //replace 'user.X' with the data u need.
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool DeleteTram(int tramId)
        {
            try
            {
                string query; // the query will end up in here
                query = "DELETE FROM Tram";  //replace with INSERT if needed
                query += "WHERE TramID = " + tramId; //replace 'user.X' with the data u need.
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public bool UpdateTramStatus(int tramId, int statusId) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE Tram_Status SET";  //replace with INSERT if needed
                query += " StatusStatusID = '" + statusId + "' WHERE TramTramID = " + tramId; //replace 'user.X' with the data u need.
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
 