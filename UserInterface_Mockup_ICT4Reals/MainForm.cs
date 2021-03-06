﻿using System;
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
using UserInterface_Mockup_ICT4Reals.Service;

namespace UserInterface_Mockup_ICT4Reals
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// fields
        /// </summary>
        private Administration administration;
        private Parkingsystem parkingsystem;
        private PAdatabase padatabase;
        private Cleaningservice clService = new Cleaningservice(1, "cleaning", DateTime.Today, DateTime.Today, 1, 1);
        private Repairservice rpService = new Repairservice(1, "repair", DateTime.Today, DateTime.Today, 1, 1);

        /// <summary>
        /// constructor of the mainform
        /// </summary>
        /// <param name="administration">the administration that was made when the login form was made</param>
        public MainForm(Administration administration)
        {
            //ophalen van alle info uit de database

            this.administration = administration;
            this.parkingsystem = new Parkingsystem();
            this.padatabase = new PAdatabase();
            InitializeComponent();
            if (Administration.LoggedInUser.RoleId == 1)
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
            remiseRefresh();
        }
        /// <summary>
        /// checks what tab is selected on the tablayout
        /// </summary>
        /// <param name="sender">the control that was clicked</param>
        /// <param name="e"></param>
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
        /// <summary>
        /// occurs when the button "btnIncomingTram" is pressed
        /// </summary>
        /// <param name="sender">the control that was clicked</param>
        /// <param name="e"></param>
        private void btnIncomingTram_Click(object sender, EventArgs e)
        {
            Rail rail = null;
            Tram tram = null;
            int status = 0;
            string soort = "";
            if (CbxClean.Checked && Cbxrepair.Checked == false)
            {
                status = 2;
            }
            if (Cbxrepair.Checked && CbxClean.Checked == false)
            {
                status = 3;
            }
            if (Cbxrepair.Checked && CbxClean.Checked)
            {
                status = 4;
            }
            if (!CbxClean.Checked && !Cbxrepair.Checked)
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
                foreach (Tram t in Administration.GetTramList)
                {
                    if (t.Id == tramnr)
                    {
                        exist = true;
                        tram = t;
                    }
                }
                if (exist == true)
                {
                    if (tram.OnRail)
                    {
                        MessageBox.Show("The tram is already parked and should be on its rail.");
                    }
                    else
                    {
                        if (tram.Rail.IsRailBlocked(tram.Rail.Id))
                        {
                            MessageBox.Show("This rail is blocked");
                        }
                        else
                        {
                            rail = parkingsystem.InsertTramNr(Convert.ToInt32(tbTramIn.Text), status);
                            tram._Status = status;
                            if (status == 2)
                            {
                                soort = "Schoonmaak";
                            }
                            else if (status == 3)
                            {
                                soort = "Reparatie";
                            }
                            else if (status == 4)
                            {
                                soort = "Beide";
                            }
                            if (soort != "")
                            {
                                padatabase.MakeService(tramnr, soort);
                            }
                            tram.OnRail = true;
                            if (!padatabase.RefreshTramdatabase(tramnr))
                            {
                                MessageBox.Show("The database wasn't updated.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("A Tram with that number doesn't exist! Input a valid tramnumber!");

                }

                if (rail != null)
                {
                    lblNr.Text = Convert.ToString(rail.Id);

                }
                else
                {
                    MessageBox.Show("The Assigned rail does not exist or is blocked");
                }
            }

            remiseRefresh();
        }

        /// <summary>
        /// refreshes the UI of the remise and allocates all the tram to their respective labels AKA rails
        /// </summary>
        private void remiseRefresh()
        {
            List<Tram> trams = Administration.GetTramList;

            foreach (Control c in groupBox1.Controls)
            {
                if (c.Name.StartsWith("spoor"))
                {
                    c.Text = "";
                    c.BackColor = Color.White;
                }

            }

            foreach (Tram t in trams)
            {
                if (t.OnRail)
                {
                    Rail rail = t.Rail;

                    string id = Convert.ToString(rail.Id);
                    Control c = groupBox1.Controls.Find("spoor" + id, true).FirstOrDefault();
                    c.Text = Convert.ToString(t.Id);
                    c.BackColor = Color.DimGray;
                }
            }

        }

        /// <summary>
        /// accurs when button "btnSpoorStatusAanpassen" is clicked
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void btnSpoorStatusAanpassen_Click(object sender, EventArgs e)
        {
            Rail rail = new Rail(Convert.ToInt32(cbSpoorStatusSpoor.SelectedValue), false, false, 1);
            int status = 0;
            if (cbSpoorStatusStatus.Text == "Blokkeer")
            {
                status = 1;
                Control c = groupBox1.Controls.Find("spoor" + Convert.ToInt32(cbSpoorStatusSpoor.Text), true).FirstOrDefault();
                if (c.BackColor != Color.DarkRed)
                {
                    if (rail.BlockRail(Convert.ToInt32(cbSpoorStatusSpoor.Text), status) == true)
                    {
                        c.BackColor = Color.DarkRed;
                    }
                }
                else if (c.BackColor == Color.DarkRed)
                {
                    MessageBox.Show("Rails is al geblokkeerd!");
                }
            }
            if (cbSpoorStatusStatus.Text == "Deblokkeer")
            {
                status = 0;
                Control c = groupBox1.Controls.Find("spoor" + Convert.ToInt32(cbSpoorStatusSpoor.Text), true).FirstOrDefault();
                if (c.BackColor != Color.White)
                {
                    if (rail.BlockRail(Convert.ToInt32(cbSpoorStatusSpoor.Text), status) == true)
                    {
                        c.BackColor = Color.White;
                    }
                }
                else if (c.BackColor == Color.White)
                {
                    MessageBox.Show("Rails is al gedeblokkeerd!");
                }
            }

        }
        /// <summary>
        /// occurs when the button toevoegen is clicked
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void btnToevoegenToevoegen_Click(object sender, EventArgs e)
        {
            int tramOnRail = 0;
            int status = 0;
            if (cbToevoegenStatus.Text == "Ok")
            {
                status = 1;
            }
            if (cbToevoegenStatus.Text == "Vies")
            {
                status = 2;
            }
            if (cbToevoegenStatus.Text == "Defect")
            {
                status = 3;
            }
            if (cbToevoegenStatus.Text == "Vies en defect")
            {
                status = 4;
            }
            if (cbTramOnRail.Checked)
            {
                tramOnRail = 1;
            }
            Tram tram = new Tram(1, "test", new Rail(1, true, false, 1), new User(2323, "test", "test", 1), 1, true);
            Control c = groupBox1.Controls.Find("spoor" + Convert.ToInt32(cbToevoegenLocatie.Text), true).FirstOrDefault();
            if (c.BackColor == Color.White)
            {
                if (tram.AddTram(Convert.ToInt32(tbToevoegenNaam.Text), Convert.ToInt32(cbToevoegenLocatie.Text),
                    status, tramOnRail) == true)
                {
                    if (tramOnRail == 1)
                    {
                        c.Text = tbToevoegenNaam.Text;
                        c.BackColor = Color.DimGray;
                        tram.OnRail = true;
                    }
                    administration.UpdateTramList();
                    //remiseRefresh();
                }
            }
            else
            {
                MessageBox.Show("Kan hier geen tram plaatsen!");
            }
        }
        /// <summary>
        /// occurs when the button btnDetailsAanpassen is clicked
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void btnDetailsAanpassen_Click(object sender, EventArgs e)
        {
            Tram tram = new Tram(1, "test", new Rail(1, true, false, 1), new User(2323, "test", "test", 1), 1, true);
            int status = 0;
            if (cbDetailsStatus.Text == "Ok")
            {
                status = 1;
            }
            if (cbDetailsStatus.Text == "Vies")
            {
                status = 2;
            }
            if (cbDetailsStatus.Text == "Defect")
            {
                status = 3;
            }
            if (cbDetailsStatus.Text == "Vies en defect")
            {
                status = 4;
            }
            if (tram.MoveTram(Convert.ToInt32(tbDetailsNaam.Text), Convert.ToInt32(cbDetailsLocatie.Text), status) == true)
            {
                foreach (Control control in groupBox1.Controls)
                {
                    if (control.Text == tbDetailsNaam.Text)
                    {
                        control.Text = "";
                        control.BackColor = Color.White;
                    }
                }
                Control c = groupBox1.Controls.Find("spoor" + Convert.ToInt32(cbDetailsLocatie.Text), true).FirstOrDefault();
                c.Text = tbDetailsNaam.Text;
                c.BackColor = Color.DimGray;
            }
        }
        /// <summary>
        /// occurs when the button btnDetailsVerwijderen is clicked
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void btnDetailsVerwijderen_Click(object sender, EventArgs e)
        {
            Tram tram = new Tram(1, "test", new Rail(1, true, false, 1), new User(2323, "test", "test", 1), 1, true);
            if (tram.DeleteTram(Convert.ToInt32(tbDetailsNaam.Text)) == true)
            {
                Control c = groupBox1.Controls.Find("spoor" + Convert.ToInt32(cbDetailsLocatie.Text), true).FirstOrDefault();
                c.Text = "";
                c.BackColor = Color.White;
            }
        }
        /// <summary>
        /// occurs when button btnUitrijden is clicked
        /// </summary>
        /// <param name="sender">the control that is clicked</param>
        /// <param name="e"></param>
        private void btnUitrijden_Click(object sender, EventArgs e)
        {
            bool exist = false;
            int tramnr;
            Tram tram = null;
            bool res = int.TryParse(tbtramout.Text, out tramnr);
            if (res == false)
            {
                MessageBox.Show("The input should consist of numbers only!");
            }
            else
            {
                foreach (Tram t in Administration.GetTramList)
                {
                    if (t.Id == tramnr)
                    {
                        exist = true;
                        tram = t;
                    }
                }
                if (exist == true && tram.OnRail == true)
                {
                    if (tram._Status == 1)
                    {
                        tram.OnRail = false;
                        MessageBox.Show("The tram is no longer parked");
                        padatabase.RefreshTramdatabase(tramnr);
                        administration.UpdateTramList();
                        remiseRefresh();
                    }
                    else
                    {
                        MessageBox.Show("The tram still needs cleaning or rapairs.");
                    }
                    remiseRefresh();
                }
                else
                {
                    MessageBox.Show("A Tram with that number isn't parked yet! Input a tramnumber of a parked tram!");
                }
            }
        }


        // cleaning 

        /// <summary>
        /// occurs when button 5 is clicked
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        //update cleaning
        {
            /*
            Tram seltram = (Tram)listBox1.SelectedItem;
            int status;
            if (statusClbox.Text == "Ok")
            {
                status = 1;
                clService.update(seltram.Id, status);
            }
            if (statusClbox.Text == "Defect")
            {
                status = 3;
                clService.update(seltram.Id, status);
            }
            else
            {
                MessageBox.Show("error");
            }
            updatecleaning();
             * */
            try
            {
                Tram trammetje = null;
                string sub = lbschoonmaak.SelectedItem.ToString().Substring(0, lbschoonmaak.SelectedItem.ToString().IndexOf(" "));
                administration.UpdateTramList();
                foreach (Tram t in Administration.GetTramList)
                {
                    if (t.Id == Convert.ToInt32(sub))
                    {
                        trammetje = t;
                    }
                    //cl
                }
                if (trammetje._Status == 4 && trammetje != null)
                {
                    trammetje._Status = 3;
                }
                else if (trammetje._Status == 2 && trammetje != null)
                {
                    trammetje._Status = 1;
                }
                else
                {
                    MessageBox.Show("Error");
                }
                //Tram seltram = (Tram)listBox2.SelectedItem;
                int status;
                if (statusClbox.Text == "ok")
                {
                    trammetje._Status = 1;
                    clService.update(trammetje.Id, trammetje._Status);
                }
                else if (statusClbox.Text == "defect")
                {
                    trammetje._Status = 3;
                    clService.update(trammetje.Id, trammetje._Status);
                }
                else
                {
                    MessageBox.Show("error");
                }
                updatecleaning();
            }
            catch
            {
                MessageBox.Show("error");
            }

        }
        /// <summary>
        /// occurs when button 6 is pressed
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Tram trammetje = null;
                string sub = lbReparatie.SelectedItem.ToString().Substring(0, lbReparatie.SelectedItem.ToString().IndexOf(" "));
                administration.UpdateTramList();
                foreach (Tram t in Administration.GetTramList)
                {
                    if (t.Id == Convert.ToInt32(sub))
                    {
                        trammetje = t;
                    }
                }
                if (trammetje._Status == 4 && trammetje != null)
                {
                    trammetje._Status = 2;
                }
                else if (trammetje._Status == 3 && trammetje != null)
                {
                    trammetje._Status = 1;
                }
                else
                {
                    MessageBox.Show("Error");
                }
                //Tram seltram = (Tram)listBox2.SelectedItem;
                int status;
                if (comboBoxrepair.Text == "ok")
                {
                    trammetje._Status = 1;
                    rpService.update(trammetje.Id, trammetje._Status);
                }
                else if (comboBoxrepair.Text == "vies")
                {
                    trammetje._Status = 2;
                    rpService.update(trammetje.Id, trammetje._Status);
                }
                else
                {
                    MessageBox.Show("error");
                }
                updaterepair();
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
        /// <summary>
        /// updates the cleaning logs
        /// </summary>
        public void updatecleaning()
        {
            lbschoonmaak.Items.Clear();
            lbCLlog.Items.Clear();
            List<string> statlist = new List<string>();

            foreach (string stat in clService.getAllStatus())
            {
                statlist.Add(stat);
                lbschoonmaak.Items.Add(stat);
            }

            List<Cleaningservice> loglist = new List<Cleaningservice>();

            foreach (Service.Service stat in clService.getAllLog())
            {
                loglist.Add(stat as Cleaningservice);
                lbCLlog.Items.Add(stat.ToString());
            }
        }
        public void updaterepair()
        {
            lbReparatie.Items.Clear();
            lbRELogboek.Items.Clear();
            List<string> statlist = new List<string>();

            foreach (string stat in rpService.getAllStatus())
            {
                statlist.Add(stat);
                lbReparatie.Items.Add(stat);
            }

            List<Repairservice> loglist = new List<Repairservice>();

            foreach (Service.Service stat in rpService.getAllLog())
            {
                loglist.Add(stat as Repairservice);
                lbRELogboek.Items.Add(stat.ToString());
            }
        }
        /// <summary>
        /// occurs when button 2 is pressed
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            updatecleaning();
        }
        /// <summary>
        /// occurs when button 1 is pressed
        /// </summary>
        /// <param name="sender">the control that was pressed</param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            updaterepair();
        }
    }
}
