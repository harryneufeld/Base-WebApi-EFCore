using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model.Entity.UserData
{
    public class User
    {
        private Guid userId;
        private string name;
        private string lastName;
        private string password;
        private DateTime? birthday;
        private UserGroup userGroup;
        private IList<UserRight> userRightList;
        private string mailAddress;
        private string phoneNumber;


        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set { password = value; }}
        public DateTime? Birthday { get => birthday; set => birthday = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        internal UserGroup UserGroup { get => userGroup; set => userGroup = value; }
        internal IList<UserRight> UserRightList { get => userRightList; set => userRightList = value; }
    }
}
