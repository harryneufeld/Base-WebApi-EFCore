using System;

namespace Database.Model.Shared
{
    public class GroupRight
    {
        private Guid _groupRightId;
        private string _name;
        private int _fieldId;
        private bool _allow;

        public Guid GroupRightId { get => _groupRightId; set => _groupRightId = value; }
        public string Name { get => _name; set => _name = value; }
        public int FieldId { get => _fieldId; set => _fieldId = value; }
        public bool Allow { get => _allow; set => _allow = value; }
    }
}