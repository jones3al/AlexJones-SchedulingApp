using System;

namespace AlexJones_SchedulingApp.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }


        public User(int userId, string userName, string password, bool active, DateTime createdDate, string createdBy)
        {
            Id = userId;
            Username = userName;
            Password = password;
            IsActive = active;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            LastUpdated = createdDate;
            LastUpdatedBy = createdBy;
        }
    }
}


