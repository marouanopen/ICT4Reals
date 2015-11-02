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
using UserInterface_Mockup_ICT4Reals.Remise;

namespace UserInterface_Mockup_ICT4Reals
{
    public partial class MainForm : Form
    {
        private Administration administration;
        private Parkingsystem parkingsystem;
        public MainForm(Administration administration)
        {
            //ophalen van alle info uit de database
            
            this.administration = administration;
            this.parkingsystem = new Parkingsystem();
            InitializeComponent();
            if(Administration.LoggedInUser.RoleId == 1)
            {

            }
            if (Administration.LoggedInUser.RoleId == 2)
            {
                tpBeheer.Enabled = false;
                TCLayout.TabPages.Remove(tpReparatie);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (Administration.LoggedInUser.RoleId == 3)
            {
                TCLayout.TabPages.Remove(tpInUitrij);
                TCLayout.TabPages.Remove(tpReparatie);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (Administration.LoggedInUser.RoleId == 4)
            {
                TCLayout.TabPages.Remove(tpInUitrij);
                TCLayout.TabPages.Remove(tpBeheer);
                TCLayout.TabPages.Remove(tpSchoonmaak);
            }
            if (Administration.LoggedInUser.RoleId == 5)
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
                //wegschrijven naar database van alle nuttige informatie
                this.Close();
            }
        }

        private void btnIncomingTram_Click(object sender, EventArgs e)
        {
            Rail rail = null;
            Tram tram = null;
            int status = 0;
            if(CbxClean.Checked && Cbxrepair.Checked == false)
            {
                status = 2;
            }
            if(Cbxrepair.Checked && CbxClean.Checked == false)
            {
                status = 3;
            }
            if(Cbxrepair.Checked && CbxClean.Checked)
            {
                status = 4;
            }
            else
            {
                status = 1;
            }
            int tramnr;
            bool exist = false;
            bool res = int.TryParse(tbTramIn.Text, out tramnr);
            if (res == false)
            {
                MessageBox.Show("The input should consist of numbers only!");
            }
            else
            {
                foreach(Tram t in Administration.GetTramList)
                {
                    if(t.Id == tramnr)
                    {
                        exist = true;
                        tram = t;
                    }
                }
                if (exist == true)
                {
                    rail = parkingsystem.InsertTramNr(Convert.ToInt32(tbTramIn.Text), status);
                    tram.OnRail = true;
                    tram._Status = status;
                    //beurt toeboegen met begindatum
                    //foreach label l  in mainform, if l.name == t.spoorid
                    //l.text = t.tramid
                    //refresh();
                }
                else
                {
                    MessageBox.Show("A Tram with that number doesn't exist! Input a valid tramnumber!");
                    
                }

                if(rail != null)
                {
                    lblNr.Text = Convert.ToString(rail.Id);
                    
                }
                else
                {
                    MessageBox.Show("This tram has no rail assigned..."); 
                }
            }

            
        }

    }
}
