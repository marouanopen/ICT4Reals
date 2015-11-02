using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;
using UserInterface_Mockup_ICT4Reals.AdminSystem;

namespace UserInterface_Mockup_ICT4Reals.Remise
{
    public class Parkingsystem
    {
        private DataBase.PAdatabase _PAdatabase = new PAdatabase();
        public Parkingsystem()
        {

        }
        public string ChangeTramStatus(Tram tram)
        {
            throw new NotImplementedException();
        }
        public Rail InsertTramNr(int nr, int status)
        {
            Rail R = null;
            foreach(Tram T in Administration.GetTramList)
            {
                if(T.Id == nr)
                {
                    T._Status = status;
                    foreach(Rail r in Administration.GetRailList)
                    {
                        if(T.Rail.Id == r.Id)
                        {
                            R = r;
                        }
                    }
                }
            }
            return R;
        }
    }
}
