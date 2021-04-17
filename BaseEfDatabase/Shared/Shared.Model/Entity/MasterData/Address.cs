using System;

namespace Shared.Model.Entity.MasterData
{
    public class Address
    {
        private Guid _addressId;
        private string _streetName;
        private string _streetNumber;
        private string _postalCode;
        private string _city;

        public Guid AddressId { get => _addressId; set => _addressId = value; }
        public string StreetName { get => _streetName; set => _streetName = value; }
        public string StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string City { get => _city; set => _city = value; }
    }
}
