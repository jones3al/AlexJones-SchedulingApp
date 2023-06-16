using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class Appointment
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }


        public Appointment(int appointmentId, int customerId, int userId, string title, string description, string location, string contact, string type, string url,
            DateTime start, DateTime end, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            Id = appointmentId;
            CustomerId = customerId;
            UserId = userId;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            URL = url;
            StartTime = start;
            EndTime = end;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            LastUpdatedDate = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
