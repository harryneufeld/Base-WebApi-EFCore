using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Entity.MasterData
{
    public class Person
    {
        private Guid personId;
        private Company company;
        private string firstName;
        private string middleName;
        private string lastName;
        private Address address;
        private string mail;
        private string phoneNumber;

        public Guid PersonId{ get => personId; set => personId = value; }
        public Company Company { get => company; set => company = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Address Address { get => address; set => address = value; }
        public string Mail { get => mail; set => mail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
