using System;

namespace Backend.Database.Model.Shared.MasterData
{
    public class Address
    {
        private Guid _addressId;
        private bool _IsMainAddress;
        private string _streetName;
        private int _streetNumber;
        private int _postalCode;
        private string _city;

        public Guid AddressId { get => _addressId; set => _addressId = value; }
        public string StreetName { get => _streetName; set => _streetName = value; }
        public int StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public bool IsMainAddress { get => _IsMainAddress; set => _IsMainAddress = value; }
        public string City { get => _city; set => _city = value; }
    }
}
