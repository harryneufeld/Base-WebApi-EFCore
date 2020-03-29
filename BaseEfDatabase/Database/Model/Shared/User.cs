using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model.Shared
{
    public class User
    {
        private Guid _userId;
        private string _name;
        private string _lastName;
        private string _password;
        private DateTime? _birthday;
        private UserGroup _userGroup;
        private IList<UserRight> _userRightList;
        private string _mailAddress;
        private int _phoneNumberPrefix;
        private int _phoneNumberSuffix;
        private int _mobilePhonePrefix;
        private int _mobilePhoneSuffix;

        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime? Birthday { get => _birthday; set => _birthday = value; }
        public string MailAddress { get => _mailAddress; set => _mailAddress = value; }
        public int PhoneNumberPrefix { get => _phoneNumberPrefix; set => _phoneNumberPrefix = value; }
        public int PhoneNumberSuffix { get => _phoneNumberSuffix; set => _phoneNumberSuffix = value; }
        public int MobilePhonePrefix { get => _mobilePhonePrefix; set => _mobilePhonePrefix = value; }
        public int MobilePhoneSuffix { get => _mobilePhoneSuffix; set => _mobilePhoneSuffix = value; }
        public Guid UserId { get => _userId; set => _userId = value; }
        internal UserGroup UserGroup { get => _userGroup; set => _userGroup = value; }
        internal IList<UserRight> UserRightList { get => _userRightList; set => _userRightList = value; }
    }
}
