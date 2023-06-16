using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using System;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class NewCountryForm : SaveableForm {
        public NewCountryForm(User user) {
            InitializeComponent();

            formOwner = user;
        }

        private void NewCountryForm_Load(object sender, EventArgs e) {
            // Set up Form with Default Information
            tboxCountryId.Text = DBHelper.GetNewIdFromTable("country", "countryId").ToString();
            tboxCountryName.Text = "";

            // Disable Save Button until proper Validation has occurred
            btnSave.Enabled = false;

            // Subscribe to Control Events
            tboxCountryName.TextChanged += OnFormUpdated;
            btnSave.Click += OnSaveButtonClicked;
            btnCancel.Click += OnCancelButtonClicked;
        }

        #region Form Functions
        private void ValidateForm() {
            bool formIsValid = true;

            // Check if Country Name field is empty or contains invalid characters
            if(Validator.IsControlEmptyOrWhitespace(tboxCountryName) || Validator.IsTextFreeOfSpecialCharacters(tboxCountryName.Text) == false) {
                formIsValid = false;
            }

            // Enable or Disable the Save Button, depending on if the form's fields are all valid
            if(formIsValid) {
                btnSave.Enabled = true;
            }
            else {
                btnSave.Enabled = false;
            }
        }
        #endregion

        #region Event Functions
        protected override void OnFormSaved() {
            base.OnFormSaved();
            Close();
        }
        private void OnFormUpdated(object sender, EventArgs e) {
            ValidateForm();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e) {
            // Create New Country Object, then build an insertValues string to push to the Database
            Country newCountry = new Country(int.Parse(tboxCountryId.Text), tboxCountryName.Text, DateTime.Now, formOwner.Username, DateTime.Now, formOwner.Username);
            string insertValues = $"{newCountry.Id}, \"{newCountry.Name}\", \"{newCountry.DateCreated:yyyy-MM-dd HH:mm:ss}\", \"{newCountry.CreatedBy}\", \"{newCountry.DateLastUpdated:yyyy-MM-dd HH:mm:ss}\", \"{newCountry.LastUpdatedBy}\"";

            // Attempt to Add new Record
            int rowsAdded = DBHelper.InsertNewRecord("country", insertValues);

            // Check if Rows were added
            if(rowsAdded > 0) {
                // Success! Push the OnFormSaved event to close the form
                MessageBox.Show("Success! New Country Added.");
                EventLogger.LogUnspecifiedEntry($"{formOwner} created new Country with ID {newCountry.Id}");
                OnFormSaved();
            }
            else {
                // Something went wrong! Stop the insertion process and handle the error from the DBHelper's Insert method
                MessageBox.Show("Something went wrong! New Country was not added");
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            Close();
        }
        #endregion
    }
}
