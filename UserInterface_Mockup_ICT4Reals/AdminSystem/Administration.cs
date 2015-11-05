using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;
using UserInterface_Mockup_ICT4Reals.Service;
using UserInterface_Mockup_ICT4Reals.Remise;
using System.Windows.Forms;

namespace UserInterface_Mockup_ICT4Reals.AdminSystem
{
    public class Administration
    {   
        /// <summary>
        /// fields
        /// </summary>
        private ADdatabase addatabase = new ADdatabase();
        public List<Cleaningservice> GetSList { get; set; }
        public List<Repairservice> GetRList { get; set; }
        public static List<Rail> GetRailList { get; set; }
        public static List<Tram> GetTramList { get; set; }
        public static User LoggedInUser { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public Administration()
        {
            GetRailList = new List<Rail>();
            GetTramList = new List<Tram>();
            foreach(Dictionary<string, object> R in addatabase.GetAllRails())
            {
                bool status = false;
                if(Convert.ToInt32(R["blokkeer"]) == 0)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
                
                Rail r = new Rail(Convert.ToInt32(R["spoorid"]), status , false, Convert.ToInt32(R["remiseid"]));
                GetRailList.Add(r);
            }
            foreach (Dictionary<string, object> T in addatabase.GetAllTrams())
            {
                Rail rail = null;
                int status = 0;
                bool onRail = false;
                
                if ((string)T["status"] == "Ok")
                {
                    status = 1;
                }
                if ((string)T["status"] == "Vies")
                {
                    status = 2;
                }
                if ((string)T["status"] == "Defect")
                {
                    status = 3;
                }
                if ((string)T["status"] == "ViesEnDefect")
                {
                    status = 4;
                }
                if (Convert.ToInt32(T["aanwezigopspoor"]) == 0)
                {
                    onRail = false;
                }
                else
                {
                    onRail = true;
                }
                foreach(Rail R in Administration.GetRailList)
                {
                    if(R.Id == Convert.ToInt32(T["spoorid"]))
                    {
                        rail = R;
                    }
                }
                Tram t = new Tram(Convert.ToInt32(T["tramid"]), (string)T["type"], rail, LoggedInUser, status, onRail);
                GetTramList.Add(t);
            }
        }
        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public bool AddTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public bool DeleteTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public bool MoveTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="rail"></param>
        /// <returns></returns>
        public bool BlockRail(Rail rail)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// notimplemented
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public bool TramToDepartment(Tram tram)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// logs the user in
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">matching password</param>
        /// <returns>bool indicating succes</returns>
        public bool LogIn(string username, string password)
        {
            foreach(Dictionary<string, object> D in addatabase.Getuserpassword(username))
            {
                if((string)D["wachtwoord"] == password)
                {
                    LoggedInUser = new User(Convert.ToInt32(D["gebruikerid"]), (string)D["naam"], (string)D["email"], Convert.ToInt32(D["functieid"]));
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// addon for enabling tabs. not used anymore
        /// </summary>
        /// <param name="page"></param>
        /// <param name="boolean"></param>
        public void EnableTab(TabPage page, bool boolean)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = boolean;
        }
    }
}
