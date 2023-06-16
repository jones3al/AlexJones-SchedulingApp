using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using AlexJones_SchedulingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp
{
    public partial class LoginForm : Form
    {
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn;
        public string loginSuccess = "Login Successful";
        public string wrongPassword = "Password does not match.";
        public string wrongUsername = "User Account does not exist.";


        public LoginForm()
        {
            InitializeComponent();

            //supports English or Spanish (LCID == 1034)
            SetFormTextByLanguage(CultureInfo.CurrentUICulture.LCID);
            //SetFormTextByLanguage(1033);

            Loginbutton.Enabled = false;

            Usernametextbox.TextChanged += LoginFieldsUpdated;
            Passwordtextbox.TextChanged += LoginFieldsUpdated;

            

        }


        #region Functions

        private void SetFormTextByLanguage(int LCId)
        {
            if (LCId == 1034)
            {
                Text= "Formulario de Inicio de Sesión";
                Usernametextbox.Text = "Nombre de Usuario";
                Passwordtextbox.Text = "Contraseña";
                Loginbutton.Text = "Acceso";
                LoginPageTitle.Text = "Acceso";
                loginSuccess = "Acceso Exitoso";
                wrongPassword = "La contraseña no coinciden.";
                wrongUsername = "La cuenta de usuario no existe.";


            }
        }

        private void ValidateLoginFields()
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
            MessageBox.Show(loginSuccess);
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
                        throw new InvalidLoginException(wrongPassword);
                    }
                }

                //no username found. Throw exception
                EventLogger.LogUnsuccessfulLogin(Usernametextbox.Text);
                throw new InvalidLoginException(wrongUsername);
            }
            catch(InvalidLoginException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginFieldsUpdated(object sender, EventArgs e)
        {
            ValidateLoginFields();
        }

        #endregion
    }
}
