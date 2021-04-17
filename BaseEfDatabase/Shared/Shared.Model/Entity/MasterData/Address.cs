using System;

namespace Shared.Model.Entity.MasterData
{
    public class Address
    {
        private Guid addressId;
        private string streetName;
        private string streetNumber;
        private string postalCode;
        private string city;

        public Guid AddressId { get => addressId; set => addressId = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
    }
}
