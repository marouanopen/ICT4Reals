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
                TCLayout.TabPages.Remove(tpBeheer);
                TCLayout.TabPages.Remove(tpReparatie);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (administration.LoggedInUser.RoleId == 3)
            {
                TCLayout.TabPages.Remove(tpInUitrij);
                TCLayout.TabPages.Remove(tpReparatie);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (administration.LoggedInUser.RoleId == 4)
            {
                TCLayout.TabPages.Remove(tpInUitrij);
                TCLayout.TabPages.Remove(tpBeheer);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (administration.LoggedInUser.RoleId == 5)
            {
                TCLayout.TabPages.Remove(tpInUitrij);
                TCLayout.TabPages.Remove(tpBeheer);
                TCLayout.TabPages.Remove(tpReparatie);
            }
        }

        private void TCLayout_Selected(object sender, TabControlEventArgs e)
        {
            if (TCLayout.SelectedTab == TCLayout.TabPages["tpUitloggen"])
            {
                Login temp = new Login();
                temp.CreateControl();
                temp.Show();
                this.Close();
            }
        }

    }
}
