using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.DataBase
{
    class PAdatabase : Database
    {
        public List<Dictionary<string, object>> GetTramInfo(int TramId)
        {
            List<Dictionary<string, object>> TramInfo= getQuery("SELECT TramID, SpoorID, TypeID, AanwezigOpSpoor FROM Tram WHERE TramID = " + TramId);

            return TramInfo;
        }
        public List<Dictionary<string, object>> GetRailInfo(int RailId)
        {
            List<Dictionary<string, object>> RailInfo = getQuery("SELECT SpoorID, Blokkeer, RemiseID FROM Tram WHERE SpoorID = " + RailId);
            return RailInfo;
        }

        public bool MakeService(int tramid, string kind)
        {
            try
            {
                string query; // the query will end up in here
                query = "insert into beurt(BeurtID, Soort, BeginDatum, Einddatum, TramID, SuperBeurtID) Values(1, '" + kind + "', to_date('" + DateTime.Now.ToString("MM-dd-yyyy hh:mm") + "','MM-DD-YYYY hh24:MI'), null, " + tramid + ", null)";  //replace with INSERT if need
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
