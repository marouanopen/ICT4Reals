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
using UserInterface_Mockup_ICT4Reals.DataBase;

namespace UserInterface_Mockup_ICT4Reals
{
    public partial class MainForm : Form
    {
        private Administration administration;
        private Parkingsystem parkingsystem;
        private PAdatabase padatabase;
        public MainForm(Administration administration)
        {
            //ophalen van alle info uit de database

            this.administration = administration;
            this.parkingsystem = new Parkingsystem();
            this.padatabase = new PAdatabase();
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
            string soort = "";
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
            if(!CbxClean.Checked && !Cbxrepair.Checked)
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
                    if(status == 2)
                    {
                        soort = "Schoonmaak";
                    }
                    else if(status == 3)
                    {
                        soort = "Reparatie";
                    }
                    else if(status == 4)
                    {
                        soort = "Beide";
                    }
                    if(soort != "")
                    {
                        padatabase.MakeService(tramnr, soort);
                    }
                    remiseRefresh();
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

            if(!padatabase.RefreshTramdatabase(tramnr))
            {
                MessageBox.Show("We Failed to update the database...");
            }
        }
        #region refresh

        private void remiseRefresh()
        {
            List<Tram> trams = Administration.GetTramList;
            Rail rail;

            foreach (Tram t in trams)
            {
                rail = t.Rail;

                string id = Convert.ToString(rail.Id);
                Control c = groupBox1.Controls.Find("spoor" + id, true).FirstOrDefault();
                c.Text = Convert.ToString(t.Id);
                c.BackColor = Color.DimGray;
            }
            
        }
        #endregion

        private void btnSpoorStatusAanpassen_Click(object sender, EventArgs e)
        {
            int status = 0;
            if (cbSpoorStatusStatus.SelectedValue == "Blokkeer")
            {
                status = 1;
            }
            if (cbSpoorStatusStatus.SelectedValue == "Deblokkeer")
            {
                status = 0;
            }
            Rail rail = new Rail(Convert.ToInt32(cbSpoorStatusSpoor.SelectedValue), false, false, 1);
            rail.BlockRail(Convert.ToInt32(cbSpoorStatusSpoor.SelectedValue), status);
        }
    }
}
