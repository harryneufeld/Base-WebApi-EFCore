using Shared.Model.Base;
using System;
using System.Collections.Generic;

namespace Shared.Model.Entity.MasterData
{
    public class Mandator : BaseModel
    {
        private Guid mandatorId;
        private string name;
        private Address address;
        private List<Company> companyList;

        public Guid MandatorId { get => mandatorId; set => mandatorId = value; }
        public string Name { get => Name; set => Name = value; }
        public Address Address { get => address; set => address = value; }
        public List<Company> CompanyList { get => companyList; set => companyList = value; }
    }
}