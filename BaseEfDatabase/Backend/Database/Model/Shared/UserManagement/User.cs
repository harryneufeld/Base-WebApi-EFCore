using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Model.Shared.UserManagement
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
        private int phoneNumberPrefix;
        private int phoneNumberSuffix;
        private int mobilePhonePrefix;
        private int mobilePhoneSuffix;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set { password = value; }}
        public DateTime? Birthday { get => birthday; set => birthday = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public int PhoneNumberPrefix { get => phoneNumberPrefix; set => phoneNumberPrefix = value; }
        public int PhoneNumberSuffix { get => phoneNumberSuffix; set => phoneNumberSuffix = value; }
        public int MobilePhonePrefix { get => mobilePhonePrefix; set => mobilePhonePrefix = value; }
        public int MobilePhoneSuffix { get => mobilePhoneSuffix; set => mobilePhoneSuffix = value; }
        public Guid UserId { get => userId; set => userId = value; }
        internal UserGroup UserGroup { get => userGroup; set => userGroup = value; }
        internal IList<UserRight> UserRightList { get => userRightList; set => userRightList = value; }
    }
}
