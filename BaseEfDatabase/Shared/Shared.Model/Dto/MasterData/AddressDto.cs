using System;

namespace Shared.Model.Dto.MasterData
{
    public class AddressDto
    {
        private string streetName;
        private string streetNumber;
        private string postalCode;
        private string city;

        public string StreetName { get => streetName; set => streetName = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
    }
}
