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
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        /// <summary>
        /// adds a tram to the database given the tramid, spoorid, typeid as data
        /// </summary>
        /// <param name="tramId">ID of the tram</param>
        /// <param name="spoorId">ID of the tracks</param>
        /// <param name="typeId">ID of the type of tram, combi/double etc</param>
        /// <returns></returns>
        public bool AddTram(int tramId, int spoorId, int typeId)
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO Tram(tramID, spoorID, typeID)";  //adding a tram
                query += " VALUES('" + tramId + ", " + spoorId + ", " + typeId + "')"; //insert data given to db
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        /// <summary>
        /// Deletes a tram from the database matching the given id
        /// </summary>
        /// <param name="tramId"></param>
        /// <returns></returns>
        public bool DeleteTram(int tramId)
        {
            try
            {
                string query; // the query will end up in here
                query = "DELETE FROM Tram";  //delete a tram
                query += "WHERE TramID = " + tramId; //deletes tram with given tram id
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
 