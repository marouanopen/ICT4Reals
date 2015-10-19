using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Mockup_ICT4Reals.DataBase;
using UserInterface_Mockup_ICT4Reals.AdminSystem;
using UserInterface_Mockup_ICT4Reals.Remise;
namespace UserInterface_Mockup_ICT4Reals.Service
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public static User _User { get; set; }
        public Tram Tram { get; set; }
        public Service(int id, string name, DateTime date, User _User, Tram tram)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.Tram = tram;
        }

     
    }
}
