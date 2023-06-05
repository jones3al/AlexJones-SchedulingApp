using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class Country
    {
        private int countryId;
        private string country;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        public int ID
        {
            get { return countryId; }
        }
        public string Name
        {
            get { return country; }
            set { country = value; }
        }
        public int CountryID
        {
            get { return countryId; }
            set { countryId = value; }
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

        public Country(int countryId, string country, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            this.countryId = countryId;
            this.country = country;
            this.createdDate = createdDate;
            this.createdBy = createdBy;
            this.lastUpdated = lastUpdated;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
