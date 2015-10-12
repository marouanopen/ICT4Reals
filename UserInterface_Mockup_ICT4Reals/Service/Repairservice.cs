using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.Administration;
using UserInterface_Mockup_ICT4Reals.Remise;

namespace UserInterface_Mockup_ICT4Reals.Service
{
    public class Repairservice : Service
    {
        public Repairservice(int id, string name, DateTime date, User user, Tram tram) : base(id, name, date, _User, tram)
        {
        }

    }
}
