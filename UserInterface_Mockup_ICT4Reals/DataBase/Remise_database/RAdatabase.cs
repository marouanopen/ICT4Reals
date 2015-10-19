using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class RAdatabase : Database
    {
        /// <summary>
        /// Is the rail blocked?
        /// </summary>
        /// <returns></returns>
        public string IsRailBlocked(int railNumber) //name of ur query
        {
            string ret = ""; //result of query will end up in here
            List<Dictionary<string, object>> RailQuery = getQuery("SELECT Blokkeer FROM Spoor WHERE SpoorID =" + railNumber); 
            foreach (Dictionary<string, object> results in RailQuery) //look for all possible results in the query result.
            {
                ret = ((Convert.ToString(results["blokkeer"]))); //add each result to the created list
            }

            return ret;     //this will return the list as result from the query
        }

        /// <summary>
        /// Block the rail or unblock the rail
        /// </summary>
        /// <param name="railNumber">Give the number of the rail you want to block/unblock</param>
        /// <param name="blokkeer">Give 0 to unblock or 1 to block</param>
        /// <returns></returns>
        public bool BlockRail(int railNumber, int blokkeer) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "UPDATE Spoor SET";  //replace with INSERT if needed
                query += " Blokkeer = '" + blokkeer + "' WHERE SpoorID = " + railNumber; //replace 'user.X' with the data u need.
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
