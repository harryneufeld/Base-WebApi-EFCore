using System.Collections.Generic;

namespace Shared.Model.Dto.MasterData
{
    public class BusinessItemDto
    {
        private MandatorDto mandator;
        private AddressDto address;
        private string businessName;
        private List<PersonDto> personList;
        private string phoneNumber;

        public MandatorDto Mandator { get => mandator; set => mandator = value; }
        public AddressDto Address { get => address; set => address = value; }
        public string Name { get => businessName; set => businessName = value; }
        public List<PersonDto> PersonList { get => personList; set => personList = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
