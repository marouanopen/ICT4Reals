﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class ADdatabase : Database
    {
        public List<Dictionary<string, object>> Getuserpassword(string username) //name of ur query
        {
            //List<string> ret = new List<string>(); //result of query will end up in here
            List<Dictionary<string, object>> user= getQuery("SELECT GebruikerID, Email, Naam, Achternaam, Wachtwoord, FunctieID, RemiseID FROM Gebruiker WHERE Email = '" + username + "'"); //replace your query with te example query, replace 'QueryX' with a clear name.
            /*foreach (Dictionary<string, object> results in user) //look for all posseble results in the query result.
            {
                ret.Add((Convert.ToString(results["gebruikerid"]),Convert.ToString(results["email"]),Convert.ToString(results["naam"]),Convert.ToString(results["achternaam"]),Convert.ToString(results["functieid"]),Convert.ToString(results["remiseid"])); //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }*/

            return user;     //this will return the list as result from the query.
        }
    }
}

