using AlexJones_SchedulingApp.Classes;
using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using AlexJones_SchedulingApp.Exceptions;
using AlexJones_SchedulingApp.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class LoginForm : Form
    {
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn;
        
        public LoginForm()
        {
            InitializeComponent();

            Loginbutton.Enabled = false;

            

        }

        #region Functions

        private void ValidateFields()
        {
            bool isFormValid = true;

            //check username and password fields
            string username = Usernametextbox.Text;
            string password = Passwordtextbox.Text;

            if (username.Replace(" ", "").Length == 0)
            {
                isFormValid = false;
            }

            if (password.Replace(" ", "").Length == 0)
            {
                isFormValid = false;
            }

            //if both text boxes have text enable login button
            if(isFormValid)
            {
                Loginbutton.Enabled = true;
            }
            else
            {
                Loginbutton.Enabled = false;
            }
        }
        private void SuccessfulLogin(User user)
        {
            MessageBox.Show("Login Successful");
            EventLogger.LogSuccessfulLogin(user);
            UserLoggedIn?.Invoke(null, new UserLoggedInEventArgs(user));
            Close();
        }

        #endregion


        #region Events
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            List<User> allUsers = DBHelper.GetAllUsers();

            try
            {
                foreach(User user in allUsers)
                {
                    if (user.Username == Usernametextbox.Text)
                    {
                        //Login success
                        SuccessfulLogin(user);
                        return;
                    }
                    else
                    {
                        //username matches but password doesnt. Throw exception
                        EventLogger.LogUnsuccessfulLogin(Usernametextbox.Text);
                        throw new InvalidLoginException("Password does not match.");
                    }
                }

                //no username found. Throw exception
                EventLogger.LogUnsuccessfulLogin(Usernametextbox.Text);
                throw new InvalidLoginException("User Account doe not exist.");
            }
            catch(InvalidLoginException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
