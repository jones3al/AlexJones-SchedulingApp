using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class NewCustomerForm : SaveableForm {
        public NewCustomerForm(User user) {
            InitializeComponent();

            formOwner = user;
        }

        private void NewCustomerForm_Load(object sender, EventArgs e) {
            // Get New ID for Customer using DBHelper
            tboxCustomerId.Text = DBHelper.GetNewIdFromTable("customer", "customerId").ToString();

            // Get all Addresses and insert their ID's into the AddressID ComboBox
            List<Address> allAddresses = DBHelper.GetAllAddresses();
            foreach(var addr in allAddresses) {
                cmbAddressId.Items.Add(addr.Id);
            }

            // Set Specific Controls to Defaults
            lblCustomerNameWarning.Visible = false;

            // Subscribe to Control Events
            cmbAddressId.SelectedIndexChanged += OnNewAddressSelected;
            cmbAddressId.SelectedIndexChanged += OnFormUpdated;
            tboxCustomerName.TextChanged += OnFormUpdated;
            checkCustomerActive.CheckedChanged += OnFormUpdated;
            btnSave.Click += OnSaveButtonClicked;
            btnCancel.Click += OnCancelButtonClicked;

            // Set Address Dropdown to First Item
            cmbAddressId.SelectedIndex = 0;
        }

        #region Form Functions
        private void ValidateForm() {
            // Check Required Fields
            bool isFormValid = true;

            if(Validator.IsControlEmptyOrWhitespace(tboxCustomerName)) {
                lblCustomerNameWarning.Visible = false;
                isFormValid = false;
            }
            else {
                if(Validator.IsTextFreeOfSpecialCharacters(tboxCustomerName.Text) == false) {
                    lblCustomerNameWarning.Visible = true;
                    isFormValid = false;
                }
                else {
                    lblCustomerNameWarning.Visible = false;
                    isFormValid = true;
                }
            }

            // If form is still valid, enable the Save button
            if(isFormValid == true) {
                btnSave.Enabled = true;
            }
            else {
                btnSave.Enabled = false;
            }
        }
        #endregion

        #region Event Functions
        private void OnSaveButtonClicked(object sender, EventArgs e) {
            // Attempt to perform a Save to DB, if successful, fire off OnFormSaving so HomeForm knows to refresh its data, then Close
            Customer newCustomer = new Customer(int.Parse(tboxCustomerId.Text), tboxCustomerName.Text, int.Parse(cmbAddressId.SelectedItem.ToString()),
                checkCustomerActive.Checked, DateTime.Now, formOwner.Username, DateTime.Now, formOwner.Username);

            // Created a string to apply an INSERT INTO SQL command
            string insertValues = $"{newCustomer.Id}, \"{newCustomer.Name}\", {newCustomer.AddressId}, {newCustomer.IsActive}, \"{newCustomer.DateCreated:yyyy-MM-dd HH:mm:ss}\", " +
                $"\"{newCustomer.CreatedBy}\", \"{newCustomer.DateLastUpdated:yyyy-MM-dd HH:mm:ss}\", \"{newCustomer.LastUpdatedBy}\"";

            int rowsAffected = DBHelper.InsertNewRecord("customer", insertValues);

            // Check Rows Affected to see if the record saved correctly
            if(rowsAffected > 0) {
                // Success! Return to the HomeForm by triggering the FormSaved event (so HomeForm reloads its data from the Database)
                MessageBox.Show($"{rowsAffected} record(s) saved! Retuning to Home Form.");
                EventLogger.LogUnspecifiedEntry($"{formOwner} created new Customer with ID {newCustomer.Id}");
                OnFormSaved();
            }
            else {
                // Something went wrong, exit with a warning
                MessageBox.Show("Record did not insert into the database. This customer has not been saved.");
            }
        }
        private void OnCancelButtonClicked(object sender, EventArgs e) {
            Close();
        }

        private void OnNewAddressSelected(object sender, EventArgs e) {
            Address newAddress = DBHelper.GetAddressById(int.Parse(cmbAddressId.SelectedItem.ToString()));

            if(newAddress != null) {
                StringBuilder fullAddress = new StringBuilder();
                fullAddress.Append($"{newAddress.Address1}");
                if(newAddress.Address2 != "") { fullAddress.Append($", {newAddress.Address2}"); }
                fullAddress.Append($"\r\n");
                fullAddress.Append($"{DBHelper.GetCityById(newAddress.CityId).Name}, {newAddress.PostalCode}\r\n");
                fullAddress.Append($"{DBHelper.GetCountryById(DBHelper.GetCityById(newAddress.CityId).CountryId).Name}");
                lblCustomerAddressValue.Text = fullAddress.ToString();
                lblCustomerPhoneValue.Text = newAddress.Phone;
            }

            OnFormUpdated(null, EventArgs.Empty);
        }
        private void OnFormUpdated(object sender, EventArgs e) {
            ValidateForm();
        }
        protected override void OnFormSaved() {
            base.OnFormSaved();
            Close();
        }
        #endregion

        private void btnNewAddress_Click(object sender, EventArgs e)
        {

        }
    }
}
