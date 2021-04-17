using System;

namespace Backend.Database.Model.Shared.UserManagement
{
    public class UserGroupRight
    {
        private Guid userGroupRightId;
        private string name;
        private int fieldId;
        private bool allow;

        public Guid UserGroupRightId { get => userGroupRightId; set => userGroupRightId = value; }
        public string Name { get => name; set => name = value; }
        public int FieldId { get => fieldId; set => fieldId = value; }
        public bool Allow { get => allow; set => allow = value; }
    }
}