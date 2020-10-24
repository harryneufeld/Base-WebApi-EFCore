using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Model.Entity.MasterData
{
    public class Person
    {
        private Guid _personId;
        private BusinessItem _businessItem;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private Address _address;
        private string _mail;
        private string _phoneNumber;

        public Guid PersonId{ get => _personId; set => _personId = value; }
        public BusinessItem BusinessItem { get => _businessItem; set => _businessItem = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string MiddleName { get => _middleName; set => _middleName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public Address Address { get => _address; set => _address = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}
