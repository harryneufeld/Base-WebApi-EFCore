using System;

namespace Backend.Database.Model.Base
{
    public class BaseModel
    {
        private DateTime? createDate;
        private DateTime? editDate;

        public DateTime? CreateDate { get => createDate; set => createDate = value; }
        public DateTime? EditDate { get => editDate; set => editDate = value; }
    }
}
