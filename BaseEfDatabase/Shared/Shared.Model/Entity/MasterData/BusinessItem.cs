using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Entity.MasterData
{
    public class BusinessItem
    {
        private Guid businessItemId;
        private Mandator mandator;
        private Address address;
        private string businessName;
        private List<Person> personList;
        private string phoneNumber;

        public Guid BusinessItemId { get => businessItemId; set => businessItemId = value; }
        public Mandator Mandator { get => mandator; set => mandator = value; }
        public Address Address { get => address; set => address = value; }
        public string Name { get => businessName; set => businessName = value; }
        public List<Person> PersonList { get => personList; set => personList = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
