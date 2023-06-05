using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class Customer
    {
        private int customerId;
        private string customerName;
        private int addressId;
        private bool active;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        public int CustomerID
        {
            get { return customerId; }
        }
        public string Name
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public int AddressID
        {
            get { return addressId; }
            set { addressId = value; }
        }
        public bool IsActive
        {
            get { return active; }
            set { active = value; }
        }
        public DateTime DateCreated
        {
            get { return createdDate; }
        }
        public string CreatedBy
        {
            get { return createdBy; }
        }
        public DateTime DateLastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
            set { lastUpdatedBy = value; }
        }

        public Customer(int customerId, string customerName, int addressId, bool active, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            this.customerId = customerId;
            this.customerName = customerName;
            this.addressId = addressId;
            this.active = active;
            this.createdDate = createdDate;
            this.createdBy = createdBy;
            this.lastUpdated = lastUpdated;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
