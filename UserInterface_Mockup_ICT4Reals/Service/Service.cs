﻿using System;
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
        public string soort { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int tramID { get; set; }
        public int superbeurtID { get; set; }
        public Service(int id, string soort, int tramid, DateTime startdate, DateTime enddate, int superbeurtID)
        {
            this.Id = id;
            this.soort = soort;
            this.startDate = enddate;
            this.startDate = startDate;
            this.tramID = tramID;
            this.superbeurtID = superbeurtID;
        }

     
    }
}
