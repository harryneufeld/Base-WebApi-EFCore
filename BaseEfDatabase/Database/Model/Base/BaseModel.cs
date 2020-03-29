using System;

namespace Database.Model.Base
{
    public class BaseModel
    {
        private DateTime? _createDate;
        private DateTime? _editDate;

        public DateTime? CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? EditDate { get => _editDate; set => _editDate = value; }
    }
}
