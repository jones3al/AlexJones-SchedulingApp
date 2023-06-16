using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Models
{
    public class City
    {

        public int Id { get; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public DateTime DateCreated { get; }
        public string CreatedBy { get; }
        public DateTime DateLastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        
        

        public City(int cityId, string city, int countryId, DateTime createdDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            Id = cityId;
            Name = city;
            CountryId = countryId;
            DateCreated = createdDate;
            CreatedBy = createdBy;
            DateLastUpdated = lastUpdate;
            LastUpdatedBy = lastUpdateBy;
        }
    }
}
