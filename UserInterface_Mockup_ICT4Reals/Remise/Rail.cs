using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals.Remise
{
    public class Rail
    {
        RAdatabase railDatabase = new RAdatabase();
        public int Id { get; set; }
        public string Status { get; set; }
        public bool Taken { get; set; }
        public Rail(int id, string status, bool taken)
        {
            this.Id = id;
            this.Status = status;
            this.Taken = taken;
        }

        public bool IsRailBlocked(int railNumber)
        {
            bool isRailBlocked = false;
            if (Convert.ToInt32(railDatabase.IsRailBlocked(railNumber)) == 0)
            {
                isRailBlocked = false;
            }
            else if (Convert.ToInt32(railDatabase.IsRailBlocked(railNumber)) == 1)
            {
                isRailBlocked = true;
            }
            return isRailBlocked;
        }

        public bool BlockRail(int railNumber, int block)
        {
            bool blockRail = false;
            if (railDatabase.BlockRail(railNumber, block))
            {
                MessageBox.Show("Succeed!");
                blockRail = true;
            }
            else
            {
                MessageBox.Show("Error!");
                blockRail = false;
            }
            return blockRail;
        }
    }
}
