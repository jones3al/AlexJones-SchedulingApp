using AlexJones_SchedulingApp.Database;
using AlexJones_SchedulingApp.Events;
using AlexJones_SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace AlexJones_SchedulingApp
{
    public partial class SelectCustomerForm : Form {
        private User formOwner;

        public new event EventHandler<SelectFormEventArgs> FormClosing;

        public SelectCustomerForm(User user) {
            InitializeComponent();

            formOwner = user;
        }

        private void SelectCustomerForm_Load(object sender, EventArgs e) {
            ResetForm();
        }

        #region Form Functions
        private void ResetForm() {
            // Unsubscribe from all Control Events
            cmbCustomerId.SelectedIndexChanged -= OnNewCustomerSelected;
            btnCancel.Click -= OnCancelButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            btnModify.Click -= OnModifyButtonClicked;

            // Clear existing collections, if needed
            cmbCustomerId.Items.Clear();

            // Build new ComboBox list
            List<Customer> allCustomers = DBHelper.GetAllCustomers();
            foreach(var cust in allCustomers) {
                cmbCustomerId.Items.Add(cust.Id);
            }

            // Subscribe to Control Events
            cmbCustomerId.SelectedIndexChanged += OnNewCustomerSelected;
            btnCancel.Click += OnCancelButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            btnModify.Click += OnModifyButtonClicked;

            // Set CustomerId to first available value
            cmbCustomerId.SelectedIndex = 0;
        }
        private void SetDetailsWindow(Customer customer) {
            // Clear the Details textbox
            tboxDetails.Text = "";

            // Build the string entry
            StringBuilder entryBuilder = new StringBuilder();
            entryBuilder.Append($"Customer ID: {customer.Id}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Customer Name: {customer.Name}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Address ID: {customer.AddressId}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Created: {customer.DateCreated}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Created By: {customer.CreatedBy}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Date Last Updated: {customer.DateLastUpdated}");
            entryBuilder.Append($"\r\n");
            entryBuilder.Append($"Last Updated By: {customer.LastUpdatedBy}");

            // Enter the String once ready
            tboxDetails.Text = entryBuilder.ToString();
        }
        #endregion

        #region Event Functions
        private void OnNewCustomerSelected(object sender, EventArgs e) {
            Customer selectedCustomer = DBHelper.GetCustomerById(int.Parse(cmbCustomerId.SelectedItem.ToString()));
            SetDetailsWindow(selectedCustomer);
        }

        private void OnModifyButtonClicked(object sender, EventArgs e) {
            int customerId = int.Parse(cmbCustomerId.SelectedItem.ToString());
            Customer selectedCustomer = DBHelper.GetCustomerById(customerId);

            if(selectedCustomer != null) {
                // Create a Modify Form and pass the Customer in!
                ModifyCustomerForm modifyCustomerForm = new ModifyCustomerForm(formOwner, selectedCustomer);
                FormClosing?.Invoke(null, new SelectFormEventArgs(modifyCustomerForm));
                Close();
            }
            else {
                MessageBox.Show("Error loading customer from database.");
            }
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult confirmMessage = MessageBox.Show("Are you sure you want to delete this Customer?", "This delete is PERMANENT", MessageBoxButtons.YesNo);

            if(confirmMessage == DialogResult.Yes) {
                // Delete the Record and Reset the Form
                int rowsAffected = DBHelper.DeleteRecord("customer", $"customerId = {int.Parse(cmbCustomerId.SelectedItem.ToString())}");

                if(rowsAffected > 0) {
                    MessageBox.Show("Record deleted successfully!");
                    EventLogger.LogUnspecifiedEntry($"{formOwner} deleted Customer with ID {int.Parse(cmbCustomerId.SelectedItem.ToString())}");
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
