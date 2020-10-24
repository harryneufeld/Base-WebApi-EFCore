using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Entity.MasterData
{
    public class BusinessItem
    {
        private Guid _businessItemId;
        private Mandator _mandator;
        private Address _address;
        private string _businessName;
        private List<Person> _personList;
        private string _phoneNumber;

        public Guid BusinessItemId { get => _businessItemId; set => _businessItemId = value; }
        public Mandator Mandator { get => _mandator; set => _mandator = value; }
        public Address Address { get => _address; set => _address = value; }
        public string Name { get => _businessName; set => _businessName = value; }
        public List<Person> PersonList { get => _personList; set => _personList = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}
