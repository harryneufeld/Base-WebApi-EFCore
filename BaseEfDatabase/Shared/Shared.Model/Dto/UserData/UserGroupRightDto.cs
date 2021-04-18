using System;

namespace Shared.Model.Dto.UserData
{
    public class UserGroupRightDto
    {
        private string name;
        private int fieldId;
        private bool allow;

        public string Name { get => name; set => name = value; }
        public int FieldId { get => fieldId; set => fieldId = value; }
        public bool Allow { get => allow; set => allow = value; }
    }
}