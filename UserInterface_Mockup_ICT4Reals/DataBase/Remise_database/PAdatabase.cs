﻿using System;
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
<<<<<<< HEAD
            List<Dictionary<string, object>> TramInfo= getQuery("SELECT TramID, SpoorID, TypeID, AanwezigOpSpoor FROM Tram WHERE TramID = " + TramId);
=======
            List<Dictionary<string, object>> TramInfo= getQuery("SELECT TramID, SpoorID, TypeID FROM Tram WHERE TramID = " + TramId);
>>>>>>> origin/master
            return TramInfo;
        }
        public List<Dictionary<string, object>> GetRailInfo(int RailId)
        {
            List<Dictionary<string, object>> RailInfo = getQuery("SELECT SpoorID, Blokkeer, RemiseID FROM Tram WHERE SpoorID = " + RailId);
            return RailInfo;
        }
        
    }
}
