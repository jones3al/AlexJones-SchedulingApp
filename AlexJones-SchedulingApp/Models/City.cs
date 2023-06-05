using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class City
    {
        private int cityId;
        private string city;
        private int countryId;
        private DateTime createdDate;
        private string createdBy;
        private DateTime lastUpdated;
        private string lastUpdatedBy;

        public int ID
        {
            get { return cityId; }
        }
        public string Name
        {
            get { return city; }
            set { city = value; }
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

        public City(int cityId, string city, int countryId, DateTime createdDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            this.cityId = cityId;
            this.city = city;
            this.countryId = countryId;
            this.createdDate = createdDate;
            this.createdBy = createdBy;
            this.lastUpdated = lastUpdate;
            this.lastUpdatedBy = lastUpdateBy;
        }
    }
}
