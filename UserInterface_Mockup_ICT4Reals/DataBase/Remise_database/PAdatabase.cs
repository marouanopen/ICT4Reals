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
            List<Dictionary<string, object>> TramInfo= getQuery("SELECT TramID, Lengte, SpoorID, TypeID FROM Tram WHERE TramID = " + TramId);
            return TramInfo;
        }
        public List<Dictionary<string, object>> GetRailInfo(int RailId)
        {
            List<Dictionary<string, object>> RailInfo = getQuery("SELECT SpoorID, Lengte, Blokkeer, RemiseID FROM Tram WHERE SpoorID = " + RailId);
            return RailInfo;
        }
        
    }
}
