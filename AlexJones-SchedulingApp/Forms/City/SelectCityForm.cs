using AlexJones_SchedulingApp;
using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Events;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class SelectCityForm : Form {
        private User formOwner;

        public new event EventHandler<SelectFormEventArgs> FormClosing;

        public SelectCityForm(User user) {
            InitializeComponent();

            formOwner = user;
        }

        private void SelectCityForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ResetForm() {
            // Unsubscribe from all Control Events
            cmbCityId.SelectedIndexChanged -= OnNewCitySelected;
            btnCancel.Click -= OnCancelButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            btnModify.Click -= OnModifyButtonClicked;

            // Clear existing collections, if needed
            cmbCityId.Items.Clear();

            // Build new ComboBox list
            List<City> allCitys = DBHelper.GetAllCities();
            foreach(var city in allCitys) {
                cmbCityId.Items.Add(city.Id);
            }

            // Subscribe to Control Events
            cmbCityId.SelectedIndexChanged += OnNewCitySelected;
            btnCancel.Click += OnCancelButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            btnModify.Click += OnModifyButtonClicked;

            // Set CityId to first available value
            cmbCityId.SelectedIndex = 0;
        }
        private void SetDetailsWindow(City city) {
            // Clear the Details textbox
            tboxDetails.Text = "";

            // Build the string entry
            StringBuilder entryBuilder = new StringBuilder();
            entryBuilder.Append($"City ID: {city.Id}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"City: {city.Name}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Country ID: {city.CountryId}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Created: {city.DateCreated}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Created By: {city.CreatedBy}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Last Updated: {city.DateLastUpdated}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Last Updated By: {city.LastUpdatedBy}");

            // Enter the String once ready
            tboxDetails.Text = entryBuilder.ToString();
        }
        #endregion

        #region Event Functions
        private void OnNewCitySelected(object sender, EventArgs e) {
            City selectedCity = DBHelper.GetCityById(int.Parse(cmbCityId.SelectedItem.ToString()));
            SetDetailsWindow(selectedCity);
        }

        private void OnModifyButtonClicked(object sender, EventArgs e) {
            int cityId = int.Parse(cmbCityId.SelectedItem.ToString());
            City selectedCity = DBHelper.GetCityById(cityId);

            if(selectedCity != null) {
                // Create a Modify Form and pass the City in!
                ModifyCityForm modifyCityForm = new ModifyCityForm(formOwner, selectedCity);
                FormClosing?.Invoke(null, new SelectFormEventArgs(modifyCityForm));
                Close();
            }
            else {
                MessageBox.Show("Error loading city from database.");
            }
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult confirmMessage = MessageBox.Show("Are you sure you want to delete this City?", "This delete is PERMANENT", MessageBoxButtons.YesNo);

            if(confirmMessage == DialogResult.Yes) {
                // Delete the Record and Reset the Form
                int rowsAffected = DBHelper.DeleteRecord("city", $"cityId = {int.Parse(cmbCityId.SelectedItem.ToString())}");

                if(rowsAffected > 0) {
                    MessageBox.Show("Record deleted successfully!");
                    EventLogger.LogUnspecifiedEntry($"{formOwner} deleted City with ID {int.Parse(cmbCityId.SelectedItem.ToString())}");
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
