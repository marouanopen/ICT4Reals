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

                /* string id = rail.Id + "";
                id.Replace("0", "V");

                Control c = Controls.Find("", true).FirstOrDefault();
                c.Text = Convert.ToString(t.Id);
                c.BackColor = Color.DimGray;
                */
                switch (rail.Id)
                {

                        

                    case 1201:
                        spoor12v1.Text = Convert.ToString(t.Id);
                        spoor12v1.BackColor = Color.DimGray;
                        break;
                    case 1301:
                        spoor13v1.Text = Convert.ToString(t.Id);
                        spoor13v1.BackColor = Color.DimGray;
                        break;
                    case 1401:
                        spoor14v1.Text = Convert.ToString(t.Id);
                        spoor14v1.BackColor = Color.DimGray;
                        break;
                    case 1501:
                        spoor15v1.Text = Convert.ToString(t.Id);
                        spoor15v1.BackColor = Color.DimGray;
                        break;
                    case 1601:
                        spoor16v1.Text = Convert.ToString(t.Id);
                        spoor16v1.BackColor = Color.DimGray;
                        break;
                    case 1701:
                        spoor17v1.Text = Convert.ToString(t.Id);
                        spoor17v1.BackColor = Color.DimGray;
                        break;
                    case 1801:
                        spoor18v1.Text = Convert.ToString(t.Id);
                        spoor18v1.BackColor = Color.DimGray;
                        break;
                    case 1901:
                        spoor19v1.Text = Convert.ToString(t.Id);
                        spoor19v1.BackColor = Color.DimGray;
                        break;
                    case 2001:
                        spoor20v1.Text = Convert.ToString(t.Id);
                        spoor20v1.BackColor = Color.DimGray;
                        break;
                    case 2101:
                        spoor21v1.Text = Convert.ToString(t.Id);
                        spoor21v1.BackColor = Color.DimGray;
                        break;
                    case 3001:
                        spoor30v1.Text = Convert.ToString(t.Id);
                        spoor30v1.BackColor = Color.DimGray;
                        break;
                    case 3002:
                        spoor30v2.Text = Convert.ToString(t.Id);
                        spoor30v2.BackColor = Color.DimGray;
                        break;
                    case 3003:
                        spoor30v3.Text = Convert.ToString(t.Id);
                        spoor30v3.BackColor = Color.DimGray;
                        break;
                    case 3101:
                        spoor31v1.Text = Convert.ToString(t.Id);
                        spoor31v1.BackColor = Color.DimGray;
                        break;
                    case 3102:
                        spoor31v2.Text = Convert.ToString(t.Id);
                        spoor31v2.BackColor = Color.DimGray;
                        break;
                    case 3103:
                        spoor31v3.Text = Convert.ToString(t.Id);
                        spoor31v3.BackColor = Color.DimGray;
                        break;
                    case 3201:
                        spoor12v1.Text = Convert.ToString(t.Id);
                        spoor12v1.BackColor = Color.DimGray;
                        break;
                    
                }
            }
        }
        #endregion
    }
}
