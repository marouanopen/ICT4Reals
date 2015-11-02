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
    public class Cleaningservice : Service
    {

         public Cleaningservice(int id, string soort, DateTime startdate, DateTime enddate, int tramid, int superbeurtID) : base(id, soort, tramid, startdate ,enddate ,superbeurtID)
        { }
        CLdatabase database = new CLdatabase();

        public bool update(int tramID, int StatusID)
        {
            if (database.controleMax())
            {
                if (database.updatecleaning(tramID, StatusID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        public List<string> getAllStatus()
        {
            List<string> Allbroken = new List<string>();
            List<Dictionary<string, object>> results = database.GetAllStatus();
            foreach (Dictionary<string, object> tramLink in results)
            {

                string text = Convert.ToString(tramLink["TramTramID"]) + " - need repairs";
            }

            return null;
        }
        public List<Service> getAllLog()
        {
            List<Service> allService = new List<Service>();

            List<Dictionary<string, object>> results = database.GetAlllogs();

            foreach (Dictionary<string, object> log in results)
            {
                Service newservice = new Service(Convert.ToInt32(Convert.ToInt32(log["beurtID"])), Convert.ToString(log["soort"]), Convert.ToInt32(log["tramID"]), Convert.ToDateTime(log["beginDatum"]), Convert.ToDateTime(log["eindDatum"]), Convert.ToInt32(log["superbeurtID"]));

                allService.Add(newservice);
            }
            return allService;
        }


        public bool addlog(int tramID, int superbeurt)
        {
            DateTime date = DateTime.Now;
            if (database.updateLog(tramID, date, superbeurt))
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
