using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Dto.UserData
{
    public class UserDto
    {
        private string name;
        private string lastName;
        private string password;
        private DateTime? birthday;
        private UserGroupDto userGroup;
        private IList<UserRightDto> userRightList;
        private string mailAddress;
        private string phoneNumber;


        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set { password = value; }}
        public DateTime? Birthday { get => birthday; set => birthday = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        internal UserGroupDto UserGroup { get => userGroup; set => userGroup = value; }
        internal IList<UserRightDto> UserRightList { get => userRightList; set => userRightList = value; }
    }
}
