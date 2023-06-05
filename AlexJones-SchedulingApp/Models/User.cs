using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class User
    {
        private int userId;
        private string userName;
        private string password;
        private bool active;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        public int ID
        {
            get { return userId; }
        }
        public string Username
        {
            get { return userName; }
        }
        public string Password
        {
            get { return password; }
        }
        public bool IsActive
        {
            get { return active; }
        }
        public DateTime DateCreated
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
        }
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
        }

        public User(int userId, string userName, string password, bool active, DateTime createdDate, string createdBy)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.active = active;
            this.createdDate = createdDate;
            this.createdBy = createdBy;

            lastUpdated = createdDate;
            lastUpdatedBy = createdBy;
        }

        public User(int userId, string userName, string password, bool active, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.active = active;
            this.createdDate = createdDate;
            this.createdBy = createdBy;

            this.lastUpdated = lastUpdated;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
