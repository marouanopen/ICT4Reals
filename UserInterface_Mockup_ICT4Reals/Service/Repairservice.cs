using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.AdminSystem;
using UserInterface_Mockup_ICT4Reals.Remise;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.Service
{
    public class Repairservice : Service
    {
        REdatabase database = new REdatabase();
        public Repairservice(int id, string name, DateTime date, User user, Tram tram) : base(id, name, date, _User, tram)
        {
        
        }

        public bool update(int tramID, int StatusID)
        {
            if(database.updateRepair(tramID, StatusID))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<string> getAllStatus()
        {
            List<string> AllStatus = new List<string>();
            List<Dictionary<string, object>> results = database.GetAllStatus();
            foreach(Dictionary<string, object> tramLink in results)
            {

                string text = Convert.ToString(tramLink["TramTramID"]) + Convert.ToString(tramLink["StatusStatusID"]);
                AllStatus.Add(text);
            }

            return null;
        }

        public bool addlog(int tramID)
        {
            DateTime date = DateTime.Now;
            if (database.updateLog(tramID, date))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
    }
}
