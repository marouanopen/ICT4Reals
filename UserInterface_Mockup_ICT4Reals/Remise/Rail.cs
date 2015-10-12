using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.Remise
{
    public class Rail
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool Taken { get; set; }
        public Rail(int id, string status, bool taken)
        {
            this.Id = id;
            this.Status = status;
            this.Taken = taken;
        }
    }
}
