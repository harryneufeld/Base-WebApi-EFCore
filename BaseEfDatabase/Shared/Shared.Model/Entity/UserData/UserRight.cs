using System;

namespace Shared.Model.Entity.UserData
{
    public class UserRight
    {
        private Guid userRightId;
        private string name;
        private int fieldId;
        private bool allow;

        public Guid UserRightId { get => userRightId; set => userRightId = value; }
        public string Name { get => name; set => name = value; }
        public int FieldId { get => fieldId; set => fieldId = value; }
        public bool Allow { get => allow; set => allow = value; }
    }
}