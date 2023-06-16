using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Events;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp
{
    public partial class SelectAppointmentForm : Form {
        private User formOwner;

        public new event EventHandler<SelectFormEventArgs> FormClosing;

        public SelectAppointmentForm(User user) {
            InitializeComponent();

            formOwner = user;
        }

        private void SelectAppointmentForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ResetForm() {
            // Unsubscribe from all Control Events
            cmbAppointmentId.SelectedIndexChanged -= OnNewAppointmentSelected;
            btnCancel.Click -= OnCancelButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            btnModify.Click -= OnModifyButtonClicked;

            // Clear existing collections, if needed
            cmbAppointmentId.Items.Clear();

            // Build new ComboBox list
            List<Appointment> allAppointments = DBHelper.GetAllAppointments();
            foreach(var appointment in allAppointments) {
                cmbAppointmentId.Items.Add(appointment.Id);
            }

            // Subscribe to Control Events
            cmbAppointmentId.SelectedIndexChanged += OnNewAppointmentSelected;
            btnCancel.Click += OnCancelButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            btnModify.Click += OnModifyButtonClicked;

            // Set AppointmentId to first available value
            cmbAppointmentId.SelectedIndex = 0;
        }
        private void SetDetailsWindow(Appointment appointment) {
            // Clear the Details textbox
            tboxDetails.Text = "";

            // Build the string entry
            StringBuilder entryBuilder = new StringBuilder();
            entryBuilder.Append($"Appointment Id: {appointment.Id}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Customer Id: {appointment.CustomerId}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"User Id: {appointment.UserId}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Title: {appointment.Title}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Description: {appointment.Description}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Location: {appointment.Location}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Contact: {appointment.Contact}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Type: {appointment.Type}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"URL: {appointment.URL}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Created: {appointment.CreatedDate}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Created By: {appointment.CreatedBy}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Last Updated: {appointment.LastUpdatedDate}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Last Updated By: {appointment.LastUpdatedBy}");

            // Enter the String once ready
            tboxDetails.Text = entryBuilder.ToString();
        }
        #endregion

        #region Event Functions
        private void OnNewAppointmentSelected(object sender, EventArgs e) {
            Appointment selectedAppointment = DBHelper.GetAppointmentById(int.Parse(cmbAppointmentId.SelectedItem.ToString()));
            SetDetailsWindow(selectedAppointment);
        }

        private void OnModifyButtonClicked(object sender, EventArgs e) {
            int appointmentId = int.Parse(cmbAppointmentId.SelectedItem.ToString());
            Appointment selectedAppointment = DBHelper.GetAppointmentById(appointmentId);

            if(selectedAppointment != null) {
                // Create a Modify Form and pass the Appointment in!
                ModifyAppointmentForm modifyAppointmentForm = new ModifyAppointmentForm(formOwner, selectedAppointment);
                FormClosing?.Invoke(null, new SelectFormEventArgs(modifyAppointmentForm));
                Close();
            }
            else {
                MessageBox.Show("Error loading appointment from database.");
            }
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult confirmMessage = MessageBox.Show("Are you sure you want to delete this Appointment?", "This delete is PERMANENT", MessageBoxButtons.YesNo);

            if(confirmMessage == DialogResult.Yes) {
                // Delete the Record and Reset the Form
                int rowsAffected = DBHelper.DeleteRecord("appointment", $"appointmentId = {int.Parse(cmbAppointmentId.SelectedItem.ToString())}");

                if(rowsAffected > 0) {
                    MessageBox.Show("Record deleted successfully!");
                    EventLogger.LogUnspecifiedEntry($"{formOwner} deleted Appointment with Id {int.Parse(cmbAppointmentId.SelectedItem.ToString())}");
                    ResetForm();
                }
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            FormClosing?.Invoke(null, new SelectFormEventArgs());
            Close();
        }
        #endregion
    }
}
