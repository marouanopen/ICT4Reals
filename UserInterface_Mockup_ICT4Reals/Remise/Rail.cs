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

        /// <summary>
        /// See if the rail is blocked
        /// </summary>
        /// <param name="railNumber">Give the railnumber of which you want to look for</param>
        /// <returns>false if rail is free and return true if rail is blocked</returns>
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

        /// <summary>
        /// Block the rail
        /// </summary>
        /// <param name="railNumber">The railnumber you want to block</param>
        /// <param name="block">give 1 to block or 0 to unblock</param>
        /// <returns>true if succeed, false if failed</returns>
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
