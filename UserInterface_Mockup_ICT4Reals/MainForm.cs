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
                Control c = groupBox1.Controls.Find(id, true).FirstOrDefault();
                c.Text = Convert.ToString(t.Id);
                c.BackColor = Color.DimGray;
                /*
                switch (rail.Id)
                {
                    case 1201:
                        spoor1201.Text = Convert.ToString(t.Id);
                        spoor1201.BackColor = Color.DimGray;
                        break;
                    case 1301:
                        spoor1301.Text = Convert.ToString(t.Id);
                        spoor1301.BackColor = Color.DimGray;
                        break;
                    case 1401:
                        spoor1401.Text = Convert.ToString(t.Id);
                        spoor1401.BackColor = Color.DimGray;
                        break;
                    case 1501:
                        spoor1501.Text = Convert.ToString(t.Id);
                        spoor1501.BackColor = Color.DimGray;
                        break;
                    case 1601:
                        spoor1601.Text = Convert.ToString(t.Id);
                        spoor1601.BackColor = Color.DimGray;
                        break;
                    case 1701:
                        spoor1701.Text = Convert.ToString(t.Id);
                        spoor1701.BackColor = Color.DimGray;
                        break;
                    case 1801:
                        spoor1801.Text = Convert.ToString(t.Id);
                        spoor1801.BackColor = Color.DimGray;
                        break;
                    case 1901:
                        spoor1901.Text = Convert.ToString(t.Id);
                        spoor1901.BackColor = Color.DimGray;
                        break;
                    case 2001:
                        spoor2001.Text = Convert.ToString(t.Id);
                        spoor2001.BackColor = Color.DimGray;
                        break;
                    case 2101:
                        spoor2101.Text = Convert.ToString(t.Id);
                        spoor2101.BackColor = Color.DimGray;
                        break;
                    case 3001:
                        spoor3001.Text = Convert.ToString(t.Id);
                        spoor3001.BackColor = Color.DimGray;
                        break;
                    case 3002:
                        spoor3002.Text = Convert.ToString(t.Id);
                        spoor3002.BackColor = Color.DimGray;
                        break;
                    case 3003:
                        spoor3003.Text = Convert.ToString(t.Id);
                        spoor3003.BackColor = Color.DimGray;
                        break;
                    case 3101:
                        spoor3101.Text = Convert.ToString(t.Id);
                        spoor3101.BackColor = Color.DimGray;
                        break;
                    case 3102:
                        spoor3102.Text = Convert.ToString(t.Id);
                        spoor3102.BackColor = Color.DimGray;
                        break;
                    case 3103:
                        spoor3103.Text = Convert.ToString(t.Id);
                        spoor3103.BackColor = Color.DimGray;
                        break;
                    case 3201:
                        spoor1201.Text = Convert.ToString(t.Id);
                        spoor1201.BackColor = Color.DimGray;
                        break;
                    
                }*/
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
