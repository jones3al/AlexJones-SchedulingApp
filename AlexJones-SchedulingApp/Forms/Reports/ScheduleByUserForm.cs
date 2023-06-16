using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp
{
    public partial class ScheduleByUserForm : Form {
        public ScheduleByUserForm() {
            InitializeComponent();
        }

        private void ScheduleByUserForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ResetForm() {
            // Unsubscribe from Control Events, if needed
            btnCancel.Click -= OnCancelButtonClicked;
            btnGenerate.Click -= OnGenerateButtonClicked;
            cmbUserId.SelectedIndexChanged -= OnNewUserSelected;

            // Get Data for User DropDown
            List<User> allUsers = DBHelper.GetAllUsers();
            foreach(var user in allUsers) {
                cmbUserId.Items.Add(user.Id);
            }

            // Subsribe to Control Events
            btnCancel.Click += OnCancelButtonClicked;
            btnGenerate.Click += OnGenerateButtonClicked;
            cmbUserId.SelectedIndexChanged += OnNewUserSelected;

            // Select first option for UserId
            cmbUserId.SelectedIndex = 0;
        }
        private void OrderAppointments(List<Appointment> appointments) {

        }
        #endregion

        #region Event Functions
        private void OnNewUserSelected(object sender, EventArgs e) {
            int id = int.Parse(cmbUserId.SelectedItem.ToString());
            User user = DBHelper.GetUserById(id);
            lblUsername.Text = $"User: {user.Username}";
        }

        private void OnGenerateButtonClicked(object sender, EventArgs e) {
            // First, get a list of all appointments
            List<Appointment> allAppointments = DBHelper.GetAllAppointments();

            // Filter through all Appointments and grab only those for specified user, sorting by StartTime in ascending order
            IEnumerable<Appointment> sortedAppointments =
                from appt in allAppointments
                orderby appt.StartTime ascending
                where appt.UserId == int.Parse(cmbUserId.SelectedItem.ToString())
                select appt;

            // Display the list!
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.Append($"Ordered Appointments for User {DBHelper.GetUserById(int.Parse(cmbUserId.SelectedItem.ToString())).Username}\r\n\r\n");
            foreach(var appt in sortedAppointments) {
                reportBuilder.Append($"[{appt.Id}] {appt.Title} Contact: {appt.Contact} Start: {appt.StartTime.ToString("MMM dd yyyy HH:mm tt")}\r\n");
            }

            MessageBox.Show(reportBuilder.ToString());
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            Close();
        }
        #endregion
    }
}
