﻿using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class ModifyCityForm : SaveableForm {
        private City currentCity;

        public ModifyCityForm(User user, City city) {
            InitializeComponent();

            formOwner = user;
            currentCity = city;
        }

        private void ModifyCityForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ValidateForm() {
            bool formIsValid = true;

            // Check City Name for empty/whitespace or invalid characters
            if(Validator.IsControlEmptyOrWhitespace(tboxCityName) || Validator.IsTextFreeOfSpecialCharacters(tboxCityName.Text) == false) {
                formIsValid = false;
            }

            // Enable/Disable Saving based on Validation
            if(formIsValid) {
                btnSave.Enabled = true;
            }
            else {
                btnSave.Enabled = false;
            }
        }
        private void ResetForm() {
            // Temporarily Unsubsribe to Control Events
            btnSave.Click -= OnSaveButtonClicked;
            btnCancel.Click -= OnCancelButtonClicked;
            tboxCityName.TextChanged -= OnFormUpdated;
            cmbCityCountryId.SelectedIndexChanged -= OnNewCountrySelected;

            // Clear any existing collections
            cmbCityCountryId.Items.Clear();

            // Set Default Values on TextBoxes and Labels
            tboxCityId.Text = currentCity.Id.ToString();
            tboxCityName.Text = currentCity.Name;

            // Fill CountryID ComboBox with most current data
            List<Country> allCountries = DBHelper.GetAllCountries();
            foreach(var country in allCountries) {
                cmbCityCountryId.Items.Add(country.Id);
            }

            // Enable / Disable Controls as needed
            btnSave.Enabled = false;

            // Subscribe to Control Events
            btnSave.Click += OnSaveButtonClicked;
            btnCancel.Click += OnCancelButtonClicked;
            tboxCityName.TextChanged += OnFormUpdated;
            cmbCityCountryId.SelectedIndexChanged += OnNewCountrySelected;

            // Set CountryID dropdown to first item in list
            cmbCityCountryId.SelectedItem = currentCity.CountryId;
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
        private void OnNewCountrySelected(object sender, EventArgs e) {
            Country selectedCountry = DBHelper.GetCountryById(int.Parse(cmbCityCountryId.SelectedItem.ToString()));
            lblCityCountryNameValue.Text = selectedCountry?.Name ?? "COUNTRY NOT FOUND";
        }

        private void OnSaveButtonClicked(object sender, EventArgs e) {
            // Create a New City object then parse it into an insertValues string to feed DBHelper and attempt to add to the CITY table
            City newCity = new City(int.Parse(tboxCityId.Text), tboxCityName.Text, int.Parse(cmbCityCountryId.SelectedItem.ToString()), currentCity.DateCreated, currentCity.CreatedBy, DateTime.Now, formOwner.Username);
            string insertValues = $"cityId = {newCity.Id}, city = \"{newCity.Name}\", countryId = {newCity.CountryId}, lastUpdate = \"{newCity.DateLastUpdated:yyyy-MM-dd HH:mm:ss}\", lastUpdateBy = \"{newCity.LastUpdatedBy}\"";

            // Use DBHelper to Attempt to Insert the new record
            int rowsAdded = DBHelper.UpdateRecord("city", insertValues, $"cityId = {int.Parse(tboxCityId.Text)}");

            // Check if any new rows were added
            if(rowsAdded > 0) {
                // Success! Fire off the OnFormSaved event to close the form properly
                MessageBox.Show("City Updated Successfully!");
                EventLogger.LogUnspecifiedEntry($"{formOwner} updated City with ID {newCity.Id}");
                OnFormSaved();
            }
            else {
                MessageBox.Show("Something went wrong. City not updated.");
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            Close();
        }
        #endregion
    }
}
