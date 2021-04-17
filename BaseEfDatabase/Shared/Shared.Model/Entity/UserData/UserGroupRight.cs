using System;

namespace Shared.Model.Entity.UserData
{
    public class UserGroupRight
    {
        private Guid _userGroupRightId;
        private string _name;
        private int _fieldId;
        private bool _allow;

        public Guid UserGroupRightId { get => _userGroupRightId; set => _userGroupRightId = value; }
        public string Name { get => _name; set => _name = value; }
        public int FieldId { get => _fieldId; set => _fieldId = value; }
        public bool Allow { get => _allow; set => _allow = value; }
    }
}