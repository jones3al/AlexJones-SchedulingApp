﻿using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class ModifyAddressForm : SaveableForm {
        private Address currentAddress;

        public ModifyAddressForm(User user, Address address) {
            InitializeComponent();

            formOwner = user;
            currentAddress = address;
        }

        private void ModifyAddressForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ValidateForm() {
            bool isFormValid = true;

            if(Validator.IsControlEmptyOrWhitespace(tboxAddressAddress1)) {
                isFormValid = false;
            }

            if(PhoneFieldValidation() == false || Validator.IsControlEmptyOrWhitespace(tboxAddressPhone)) {
                isFormValid = false;
            }

            if(PostalCodeFieldValidation() == false || Validator.IsControlEmptyOrWhitespace(tboxAddressPostalCode)) {
                isFormValid = false;
            }

            if(isFormValid == true) {
                btnSave.Enabled = true;
            }
            else {
                btnSave.Enabled = false;
            }
        }
        private bool PhoneFieldValidation() {
            char[] phoneChars = tboxAddressPhone.Text.ToCharArray();

            // Check if field is too long (xxx-xxx-xxxx should be 12 chars)
            if(phoneChars.Length != 12) {
                return false;
            }

            // Check for dashes in correct places
            if(phoneChars[3] != '-' || phoneChars[7] != '-') {
                return false;
            }

            // Check that all other characters are only digits
            IEnumerable<char> phoneNoDashes =
                from c in phoneChars
                where c != '-'
                select c;

            foreach(char c in phoneNoDashes) {
                if(c < '0' || c > '9') {
                    return false;
                }
            }

            // Validation Passed!
            return true;
        }
        private bool PostalCodeFieldValidation() {
            char[] postalChars = tboxAddressPostalCode.Text.ToCharArray();

            // Postal Code is too long
            if(postalChars.Length != 5) {
                return false;
            }

            // Check if PostalCode contains non-numbers
            foreach(char c in postalChars) {
                if(c < '0' || c > '9') {
                    return false;
                }
            }

            return true;
        }
        private void ResetForm() {
            // Temporarily Unsubscribe from Control Events
            tboxAddressAddress1.TextChanged -= OnFormUpdated;
            tboxAddressPhone.TextChanged -= OnFormUpdated;
            tboxAddressPostalCode.TextChanged -= OnFormUpdated;
            cmbAddressCityId.SelectedIndexChanged -= OnCityChanged;
            btnSave.Click -= OnSaveButtonClicked;
            btnCancel.Click -= OnCancelButtonClicked;

            // Clear Out Collections, as needed
            cmbAddressCityId.Items.Clear();

            // Set Defaults for Form
            tboxAddressId.Text = currentAddress.Id.ToString();
            tboxAddressAddress1.Text = currentAddress.Address1;
            tboxAddressAddress2.Text = currentAddress.Address2;
            tboxAddressPhone.Text = currentAddress.Phone;
            tboxAddressPostalCode.Text = currentAddress.PostalCode;

            // Fill ComboBoxes
            List<City> allCities = DBHelper.GetAllCities();
            foreach(City city in allCities) {
                cmbAddressCityId.Items.Add(city.Id);
            }

            // Disable Default Buttons
            btnSave.Enabled = false;

            // Subscribe to Control Events
            tboxAddressAddress1.TextChanged += OnFormUpdated;
            tboxAddressPhone.TextChanged += OnFormUpdated;
            tboxAddressPostalCode.TextChanged += OnFormUpdated;
            cmbAddressCityId.SelectedIndexChanged += OnCityChanged;
            btnSave.Click += OnSaveButtonClicked;
            btnCancel.Click += OnCancelButtonClicked;

            // Set City to First Index
            cmbAddressCityId.SelectedItem = currentAddress.CityId;
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
        private void OnCityChanged(object sender, EventArgs e) {
            int cityId = int.Parse(cmbAddressCityId.SelectedItem.ToString());
            City selectedCity = DBHelper.GetCityById(cityId);
            lblAddressCityName.Text = selectedCity.Name;
        }

        private void OnSaveButtonClicked(object sender, EventArgs e) {
            // Create a New Address and Parse it into an insertValues string to send to DBHelper for INSERT INTO SQL statement
            int addressId = int.Parse(tboxAddressId.Text);
            int cityId = int.Parse(cmbAddressCityId.SelectedItem.ToString());

            Address newAddress = new Address(addressId, tboxAddressAddress1.Text, tboxAddressAddress2.Text, cityId, tboxAddressPostalCode.Text, tboxAddressPhone.Text, DateTime.Now, formOwner.Username, DateTime.Now, formOwner.Username);
            string insertValues = $"addressId = {newAddress.Id}, address = \"{newAddress.Address1}\", address2 = \"{newAddress.Address2}\", cityId = {newAddress.CityId}, postalCode = \"{newAddress.PostalCode}\", " +
                $"phone = \"{newAddress.Phone}\", createDate = \"{newAddress.CreatedDate:yyyy-MM-dd HH:mm:ss}\", createdBy = \"{newAddress.CreatedBy}\", " +
                $"lastUpdate = \"{newAddress.LastUpdatedDate:yyyy-MM-dd HH:mm:ss}\", lastUpdateBy = \"{newAddress.LastUpdatedBy}\"";

            // Use DBHelper to attempt to Insert new record
            int rowsAdded = DBHelper.UpdateRecord("address", insertValues, $"addressId = {int.Parse(tboxAddressId.Text)}");

            // Check if new rows were successfully added
            if(rowsAdded > 0) {
                // Success!
                MessageBox.Show("Address Successfully Updated!");
                EventLogger.LogUnspecifiedEntry($"{formOwner} updated Address with ID {newAddress.Id}");
                OnFormSaved();
            }
            else {
                MessageBox.Show("Something went wrong.");
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            Close();
        }
        #endregion
    }
}
