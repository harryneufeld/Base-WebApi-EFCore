using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Model.Shared.UserManagement
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
        private string _phoneNumber;


        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Password { get => _password; set { _password = value; }}
        public DateTime? Birthday { get => _birthday; set => _birthday = value; }
        public string MailAddress { get => _mailAddress; set => _mailAddress = value; }
        public Guid UserId { get => _userId; set => _userId = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        internal UserGroup UserGroup { get => _userGroup; set => _userGroup = value; }
        internal IList<UserRight> UserRightList { get => _userRightList; set => _userRightList = value; }
    }
}
