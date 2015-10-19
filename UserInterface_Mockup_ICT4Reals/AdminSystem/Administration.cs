using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;
using UserInterface_Mockup_ICT4Reals.Service;
using UserInterface_Mockup_ICT4Reals.Remise;

namespace UserInterface_Mockup_ICT4Reals.AdminSystem
{
    public class Administration
    {
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
            return true;
        }
    }
}
