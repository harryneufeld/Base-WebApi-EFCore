using Shared.Model.Base;
using System;
using System.Collections.Generic;

namespace Shared.Model.Dto.MasterData
{
    public class MandatorDto : BaseModel
    {
        private string name;
        private AddressDto address;
        private List<BusinessItemDto> businessItemList;

        public string Name { get => Name; set => Name = value; }
        public AddressDto Address { get => address; set => address = value; }
        public List<BusinessItemDto> BusinessItemList { get => businessItemList; set => businessItemList = value; }
    }
}