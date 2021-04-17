using System;

namespace Shared.Model.Entity.UserData
{
    public class UserRight
    {
        private Guid _userRightId;
        private string _name;
        private int _fieldId;
        private bool _allow;

        public Guid UserRightId { get => _userRightId; set => _userRightId = value; }
        public string Name { get => _name; set => _name = value; }
        public int FieldId { get => _fieldId; set => _fieldId = value; }
        public bool Allow { get => _allow; set => _allow = value; }
    }
}