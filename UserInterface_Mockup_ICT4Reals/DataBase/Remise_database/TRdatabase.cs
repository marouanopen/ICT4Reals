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
    }
}
 