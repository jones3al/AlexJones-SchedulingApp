using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class Appointment
    {
        private int appointmentId;
        private int customerId;
        private int userId;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string type;
        private string url;
        private DateTime start;
        private DateTime end;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        public int ID
        {
            get { return appointmentId; }
        }
        public int CustomerID
        {
            get { return customerId; }
        }
        public int UserID
        {
            get { return userId; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        public DateTime StartTime
        {
            get { return start; }
            set { start = value; }
        }
        public DateTime EndTime
        {
            get { return end; }
            set { end = value; }
        }
        public DateTime CreatedDate
        {
            get { return createdDate; }
        }
        public string CreatedBy
        {
            get { return createdBy; }
        }
        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
            set { lastUpdatedBy = value; }
        }

        public Appointment(int appointmentId, int customerId, int userId, string title, string description, string location, string contact, string type, string url,
            DateTime start, DateTime end, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.contact = contact;
            this.type = type;
            this.url = url;
            this.start = start;
            this.end = end;
            this.createdDate = createdDate;
            this.createdBy = createdBy;
            this.lastUpdated = lastUpdated;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
