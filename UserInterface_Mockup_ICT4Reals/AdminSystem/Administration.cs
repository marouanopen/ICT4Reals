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
        private ADdatabase addatabase = new ADdatabase();
        public List<Cleaningservice> GetSList { get; set; }
        public List<Repairservice> GetRList { get; set; }
        public static List<Rail> GetRailList { get; set; }
        public static List<Tram> GetTramList { get; set; }
        public static User LoggedInUser { get; set; }

        public Administration()
        {
            foreach(Dictionary<string, object> R in addatabase.GetAllRails())
            {
                bool status = false;
                if((int)R["blokkeer"] == 0)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
                Rail r = new Rail((int)R["spoorid"], status , false, (int)R["remiseid"]);
                GetRailList.Add(r);
            }
            foreach (Dictionary<string, object> T in addatabase.GetAllTrams())
            {
                Rail rail = null;
                int status = 0;
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
                foreach(Rail R in GetRailList)
                {
                    if(R.Id == (int)T["spoorid"])
                    {
                        rail = R;
                    }
                }
                Tram t = new Tram(Convert.ToInt32(T["tramid"]), (string)T["type"], rail, LoggedInUser, status);
                GetTramList.Add(t);
            }
        }
        public bool AddTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        public bool DeleteTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        public bool MoveTram(Tram tram)
        {
            throw new NotImplementedException();
        }
        public bool BlockRail(Rail rail)
        {
            throw new NotImplementedException();
        }
        public bool TramToDepartment(Tram tram)
        {
            throw new NotImplementedException();
        }
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

        public void EnableTab(TabPage page, bool boolean)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = boolean;
        }
    }
}
