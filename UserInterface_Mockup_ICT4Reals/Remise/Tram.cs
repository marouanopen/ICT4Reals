using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.Administration;

namespace UserInterface_Mockup_ICT4Reals.Remise
{
    public class Tram
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Rail Rail { get; set; }
        public User Driver { get; set; }
        public string Status { get; set; }
        public Tram(int id, string type, Rail rail, User driver, string status)
        {
            this.Id = id;
            this.Type = type;
            this.Rail = rail;
            this.Driver = driver;
            this.Status = status;
        }
    }
}
