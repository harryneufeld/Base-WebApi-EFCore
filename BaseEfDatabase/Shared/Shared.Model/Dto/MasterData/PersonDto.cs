using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Dto.MasterData
{
    public class PersonDto
    {
        private BusinessItemDto businessItem;
        private string firstName;
        private string middleName;
        private string lastName;
        private AddressDto address;
        private string mail;
        private string phoneNumber;

        public BusinessItemDto BusinessItem { get => businessItem; set => businessItem = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public AddressDto Address { get => address; set => address = value; }
        public string Mail { get => mail; set => mail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
