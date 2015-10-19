using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface_Mockup_ICT4Reals.AdminSystem;

namespace UserInterface_Mockup_ICT4Reals
{
    public partial class MainForm : Form
    {
        private Administration administration;
        public MainForm(Administration administration)
        {
            this.administration = administration;
            InitializeComponent();
            if(administration.LoggedInUser.RoleId == 1)
            {

            }
            if (administration.LoggedInUser.RoleId == 2)
            {

            }
            if (administration.LoggedInUser.RoleId == 3)
            {

            }
            if (administration.LoggedInUser.RoleId == 4)
            {

            }
            if (administration.LoggedInUser.RoleId == 5)
            {

            }
        }
    }
}
