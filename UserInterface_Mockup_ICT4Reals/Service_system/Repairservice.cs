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
        /// <summary>
        /// fields
        /// </summary>
        REdatabase database = new REdatabase();

        public Repairservice(int id, string soort, DateTime startdate, DateTime enddate, int tramid, int superbeurtID)
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
        /// <param name="tramID">tram id</param>
        /// <param name="StatusID">status id</param>
        /// <returns></returns>
        public bool update(int tramID, int StatusID)
        {
            if (database.controleMax())
            {
                if (database.updateRepair(tramID, StatusID))
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
        /// returns al status from active trains
        /// </summary>
        /// <returns></returns>
        public List<String> getAllStatus()
        {
            List<String> Allbroken = new List<String>();
            List<Dictionary<string, object>> results = database.GetAllStatus();
            foreach(Dictionary<string, object> tramLink in results)
            {
                string text = Convert.ToString(tramLink["tramtramid"]) + " - need repairs";
                Allbroken.Add(text);
            }
            return Allbroken;
        }
        /// <summary>
        /// returns all log of past repairservices
        /// </summary>
        /// <returns></returns>
        public List<Service> getAllLog()
        {
            List<Service> allService = new List<Service>();

            List<Dictionary<string, object>> results = database.GetAlllogs();
           
            foreach (Dictionary<string, object> log in results)
            {
                Service newservice = new Service(Convert.ToInt32(Convert.ToInt32(log["beurtid"])), Convert.ToString(log["soort"]), Convert.ToInt32(log["tramid"]),Convert.ToDateTime(log["begindatum"]),DateTime.Today, 0);

                allService.Add(newservice);
            }
            return allService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramID">tram id</param>
        /// <param name="superbeurt">super beurt id</param>
        /// <returns></returns>
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
