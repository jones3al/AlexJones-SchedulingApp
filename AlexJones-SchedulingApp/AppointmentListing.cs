using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp
{
    public class AppointmentListing
    {
        public int AppointmentListingId { get; set; }
        public string Username { get; set; }
        public string CustomerName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AppointmentListing(int id, string userName, string customerName, string title, string description, string type, DateTime startDate, DateTime endDate) 
        {
            AppointmentListingId = id;
            Username = userName;
            CustomerName = customerName;
            Title = title;
            Description = description;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

}
