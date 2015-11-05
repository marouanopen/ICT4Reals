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
        /// <summary>
        /// fields
        /// </summary>
        private DataBase.PAdatabase _PAdatabase = new PAdatabase();
        /// <summary>
        /// constructor
        /// </summary>
        public Parkingsystem()
        {

        }
        /// <summary>
        /// notimplemented
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public string ChangeTramStatus(Tram tram)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// is used to determine the rail that a tram should be on
        /// </summary>
        /// <param name="nr">the tram number that you want to know the rail it should be allocated to</param>
        /// <param name="status">the status of the tram</param>
        /// <returns>an instance of the object Rail</returns>
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
