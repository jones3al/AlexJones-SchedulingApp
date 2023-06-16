using System;

namespace AlexJones_SchedulingApp.Models
{
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }

        public Country(int countryId, string country, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            Id = countryId;
            Name = country;
            DateCreated = createdDate;
            CreatedBy = createdBy;
            DateLastUpdated = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
