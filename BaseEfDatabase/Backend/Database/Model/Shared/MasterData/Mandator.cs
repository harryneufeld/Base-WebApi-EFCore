using Backend.Database.Model.Base;
using System;
using System.Collections.Generic;

namespace Backend.Database.Model.Shared.MasterData
{
    public class Mandator : BaseModel
    {
        private Guid mandatorId;
        private string name;
        private Address address;
        private List<BusinessItem> businessItemList;

        public Guid MandatorId { get => mandatorId; set => mandatorId = value; }
        public string Name { get => Name; set => Name = value; }
        public Address Address { get => address; set => address = value; }
        public List<BusinessItem> BusinessItemList { get => businessItemList; set => businessItemList = value; }
    }
}