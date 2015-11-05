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
        /// change the location of the tram with given id
        /// replace the spoorid given spoorid
        /// </summary>
        /// <param name="tramId">ID of the tram</param>
        /// <param name="railId">ID of the rail it's moved to</param>
        /// <returns></returns>
        public bool MoveTram(int tramId, int railId) // move the tram to a diffrent location
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE Tram SET";  //update the location of the tram
                query += " SpoorID = '" + railId + "' WHERE TramID = " + tramId; //change the location of to a new location from the tram with the matching id
                if (doQuery(query) == -1)  //query will be activated
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        /// <summary>
        /// not used
        /// </summary>
        /// <param name="tramId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// adds a tram to the database, uses the given variables
        /// </summary>
        /// <param name="tramId">the id of the tram</param>
        /// <param name="spoorId">the id of the rail the tram is on</param>
        /// <param name="typeId">the id of the type of the tram (represented vby an enum)</param>
        /// <returns></returns>
        public bool AddTram(int tramId, int spoorId, int typeId)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO Tram(tramID, spoorID, typeID, AanwezigOpSpoor)";  //adding a tram
                query += " VALUES(" + tramId + ", " + spoorId + ", " + typeId + ", 1)"; //insert data given to db
                if (doQuery(query) == -1)//query will be activated
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        /// <summary>
        /// Deletes a tram from the database matching the given id
        /// </summary>
        /// <param name="tramId">id of the tram you want to delete</param>
        /// <returns></returns>
        public bool DeleteTram(int tramId)
        {
            try
            {
                string query; // the query will end up in here
                query = "DELETE FROM Tram";  //delete a tram
                query += " WHERE TramID = " + tramId; //deletes tram with given tram id
                if (doQuery(query) == -1) //query will be activated
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        /// <summary>
        /// Update the tram status
        /// </summary>
        /// <param name="tramId">the id of the tram you want to update</param>
        /// <param name="statusId">1= OK 2= Dirty 3= Defect 4= DirtyAndDefect</param>
        /// <returns>true if status is updates else false</returns>
        public bool UpdateTramStatus(int tramId, int statusId)
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE Tram_Status SET"; //UPDATE tram status
                query += " StatusStatusID = '" + statusId + "' WHERE TramTramID = " + tramId;
                    //updates tram_status with given status
                if (doQuery(query) == -1) //query will be activated
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false; // if query fails, return a false.
            }
        }
    }
}
 