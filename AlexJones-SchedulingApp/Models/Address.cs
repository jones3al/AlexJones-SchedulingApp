using System;

namespace AlexJones_SchedulingApp.Models
{
    public class Address
    {

        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }


        public Address(int addressId, string address, string address2, int cityId, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            Id = addressId;
            Address1 = address;
            Address2 = address2;
            CityId = cityId;
            PostalCode = postalCode;
            Phone = phone;
            CreatedDate = createDate;
            CreatedBy = createdBy;
            LastUpdatedDate = lastUpdate;
            LastUpdatedBy = lastUpdateBy;
        }

    }
}
