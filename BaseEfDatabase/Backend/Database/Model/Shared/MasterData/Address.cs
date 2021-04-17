using System;

namespace Backend.Database.Model.Shared.MasterData
{
    public class Address
    {
        private Guid addressId;
        private bool isMainAddress;
        private string streetName;
        private int streetNumber;
        private int postalCode;
        private string city;

        public Guid AddressId { get => addressId; set => addressId = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public int StreetNumber { get => streetNumber; set => streetNumber = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public bool IsMainAddress { get => isMainAddress; set => isMainAddress = value; }
        public string City { get => city; set => city = value; }
    }
}
