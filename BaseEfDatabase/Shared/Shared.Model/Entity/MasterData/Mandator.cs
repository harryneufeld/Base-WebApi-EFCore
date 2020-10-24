using Shared.Model.Base;
using System;
using System.Collections.Generic;

namespace Shared.Model.Entity.MasterData
{
    public class Mandator : BaseModel
    {
        private Guid _mandatorId;
        private string _name;
        private Address _address;
        private List<BusinessItem> _businessItemList;

        public Guid MandatorId { get => _mandatorId; set => _mandatorId = value; }
        public string Name { get => Name; set => Name = value; }
        public Address Address { get => _address; set => _address = value; }
        public List<BusinessItem> BusinessItemList { get => _businessItemList; set => _businessItemList = value; }
    }
}