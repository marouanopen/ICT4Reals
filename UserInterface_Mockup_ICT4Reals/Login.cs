﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface_Mockup_ICT4Reals.DataBase;
using UserInterface_Mockup_ICT4Reals.AdminSystem;


namespace UserInterface_Mockup_ICT4Reals
{
    public partial class Login : Form
    {
        /// <summary>
        /// fileds
        /// </summary>
        private string username;
        private string password;
        private Administration administration;
        /// <summary>
        /// constructor
        /// </summary>
        public Login()
        {
            InitializeComponent();
            administration = new Administration();
            this.CenterToScreen();
            
        }
        /// <summary>
        /// occurs when "btnlogin"is clicked
        /// </summary>
        /// <param name="sender">the control that was clicked</param>
        /// <param name="e"></param>
        private void btlogin_Click(object sender, EventArgs e)
        {
            username = tbusername.Text;
            password = (string)tbpassword.Text;

            //pseudo doquery met check of hij lines teruggeeft wanneer je naar password vraagt die bij ingevulde gebruikersnaam hoort
            //if so login met gebruiker met de data van die gebruiker uit de database //check in de administrationklasse
            if(administration.LogIn(username, password))
            {
                MessageBox.Show("You have succesfully logged in");
                MainForm temp = new MainForm(administration);
                temp.CreateControl();
                temp.Text = "Remise Beheer";
                temp.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Something went wrong when trying to login, please try again");
            }

        }
    }
}
