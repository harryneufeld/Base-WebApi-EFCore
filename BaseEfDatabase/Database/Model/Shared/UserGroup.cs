using System;
using System.Collections.Generic;

namespace Database.Model.Shared
{
    public class UserGroup
    {
        private Guid _userGroupId;
        private string _name;
        private IList<GroupRight> _groupRightList;

        public Guid UserGroupId { get => _userGroupId; set => _userGroupId = value; }
        public string UserGroupName { get => _name; set => _name = value; }
        public IList<GroupRight> GroupRightList { get => _groupRightList; set => _groupRightList = value; }
    }
}