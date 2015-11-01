using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface_Mockup_ICT4Reals.AdminSystem;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.Remise
{
    public class Tram
    {
        TRdatabase tramDatabase = new TRdatabase();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramId">ID of the tram</param>
        /// <param name="railId">ID of the rail it's moved to</param>
        /// <returns>true if succeed and false if it fails</returns>
        public bool MoveTram(int tramId, int railId)
        {
            bool tramMoved = false;
            if (tramDatabase.MoveTram(tramId, railId))
            {
                MessageBox.Show("Succeed!");
                tramMoved = true;
            }
            else
            {
                MessageBox.Show("Error!");
            }
            return tramMoved;
        }
    }
}
