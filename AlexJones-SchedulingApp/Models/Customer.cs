using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }  

        public Customer(int customerId, string customerName, int addressId, bool active, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            Id = customerId;
            Name = customerName;
            AddressId = addressId;
            IsActive = active;
            DateCreated = createdDate;
            CreatedBy = createdBy;
            DateLastUpdated = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
