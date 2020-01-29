using System;

namespace Database.Model.Shared
{
    public class Address
    {
        private Guid _addressId;
        private string _streetName;
        private int _streetNumber;
        private City _city;
        private int _postalCode;

        public Guid AddressId { get => _addressId; set => _addressId = value; }
        public string StreetName { get => _streetName; set => _streetName = value; }
        public int StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public City City { get => _city; set => _city = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
    }
}
