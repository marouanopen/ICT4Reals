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
        public User LoggedInUser { get; set; }

        public Administration()
        {

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
