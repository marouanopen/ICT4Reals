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
        //status 1= OK 2= Dirty 3= Defect 4= DirtyAndDefect
        Status Status;
        public int _Status { get { return (int)Status; } set { Status = (Status)value;} }
        TRdatabase tramDatabase = new TRdatabase();
        public int Id { get; set; }
        public string Type { get; set; }
        public Rail Rail { get; set; }
        public User Driver { get; set; }
        public bool OnRail { get; set; }
        /// <summary>
        /// Creation of a new tram
        /// </summary>
        /// <param name="id">id of the tram</param>
        /// <param name="type">tram type</param>
        /// <param name="rail">rail on which the tram should be placed on</param>
        /// <param name="driver">the driver of the tram</param>
        /// <param name="status">1= OK 2= Dirty 3= Defect 4= DirtyAndDefect</param>
        public Tram(int id, string type, Rail rail, User driver, int status, bool onRail)
        {
            this.Id = id;
            this.Type = type;
            this.Rail = rail;
            this.Driver = driver;
            Status = (Status)status;
            OnRail = onRail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramId">ID of the tram</param>
        /// <param name="railId">ID of the rail it's moved to</param>
        /// <returns>true if succeed and false if it fails</returns>
        public bool MoveTram(int tramId, int railId, int statusID)
        {
            bool tramMoved = false;
            if (OnRail)
            {
                if (tramDatabase.MoveTram(tramId, railId, statusID))
                {
                    MessageBox.Show("Succeed!");
                    tramMoved = true;
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            return tramMoved;
        }

        /// <summary>
        /// adds a tram to the database with the provided variables
        /// </summary>
        /// <param name="tramId">ID of the new tram</param>
        /// <param name="spoorId">ID of the rail the tram is on</param>
        /// <param name="typeId">ID of the type of the tram</param>
        /// <returns>true if succeed and false if something went wrong</returns>
        public bool AddTram(int tramId, int spoorId, int typeId)
        {
            bool tramAdded = false;
            if (tramDatabase.AddTram(tramId, spoorId, typeId))
            {
                MessageBox.Show("Succeed!");
                tramAdded = true;
            }
            else
            {
                MessageBox.Show("Error!");
            }
            return tramAdded;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramId">Give the ID of the tram you want to delete</param>
        /// <returns>true if tram is deleted and false if something went wrong</returns>
        public bool DeleteTram(int tramId)
        {
            bool tramDeleted = false;
            if (tramDatabase.DeleteTram(tramId))
            {
                MessageBox.Show("Succeed!");
                tramDeleted = true;
            }
            else
            {
                MessageBox.Show("Error!");
            }
            return tramDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramID">id of the tram you want to update</param>
        /// <param name="statusID">1= OK 2= Dirty 3= Defect 4= DirtyAndDefect</param>
        /// <returns>true if tram status is updated else false</returns>
        public bool UpdateTramStatus(int tramID, int statusID)
        {
            bool statusUpdated = false;
            if (tramDatabase.UpdateTramStatus(tramID, statusID))
            {
                MessageBox.Show("Succeed!");
                statusUpdated = true;
            }
            else
            {
                MessageBox.Show("Error!");
            }
            return statusUpdated;
        }
    }
}

