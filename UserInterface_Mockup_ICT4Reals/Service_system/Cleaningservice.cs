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
        CLdatabase database = new CLdatabase();
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="soort"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="tramid"></param>
        /// <param name="superbeurtID"></param>
        public Cleaningservice(int id, string soort, DateTime startdate, DateTime enddate, int tramid, int superbeurtID)
            : base(id, soort, tramid, startdate, enddate, superbeurtID)
        {
            this.Id = id;
            this.soort = soort;
            this.startDate = startdate;
            this.endDate = enddate;
            this.tramID = tramid;
            this.superbeurtID = superbeurtID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramID"></param>
        /// <param name="StatusID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// gets all statusses from the database
        /// </summary>
        /// <returns>returns a list with all the statusses</returns>
        public List<string> getAllStatus()
        {
            List<string> Allbroken = new List<string>();
            List<Dictionary<string, object>> results = database.GetAllStatus();
            foreach (Dictionary<string, object> tramLink in results)
            {
                string text = Convert.ToString(tramLink["tramtramid"]) + " - need cleaning";
                Allbroken.Add(text);
            }

            return Allbroken;
        }
        /// <summary>
        /// gets all the logs from the database
        /// </summary>
        /// <returns>a list of services compiled from data known in the database</returns>
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
        /// <summary>
        /// add a log 
        /// </summary>
        /// <param name="tramID">id of the tram</param>
        /// <param name="superbeurt">id of the superservice</param>
        /// <returns>bool respresenting succes</returns>
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
