using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class Example_database : Database
    {


        // if u want to use get/do add using UserInterface_Mockup_ICT4Reals.DataBase;
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

        /* 
         * 

        public bool DoQueryExample(user user) // replace user with the data u want to add/ change to the table
        {
            try
            {
                string query; // the query will end up in here
                query = "INSERT INTO LOCATIE VALUES("; //replace with update if needed
                query += user.id + ", '" + user.name + "', '" + user.straat + "', '" + user.nr + "', '" + user.postcode + "', '" + user.plaats + "')"; //replace 'user.X' with the data u need.
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }
        */
    }
}
