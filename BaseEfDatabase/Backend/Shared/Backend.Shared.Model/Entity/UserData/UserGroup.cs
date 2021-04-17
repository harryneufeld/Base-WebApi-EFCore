using System;
using System.Collections.Generic;

namespace Backend.Database.Model.Shared.UserManagement
{
    public class UserGroup
    {
        private Guid userGroupId;
        private string name;
        private IList<UserGroupRight> groupRightList;

        public Guid UserGroupId { get => userGroupId; set => userGroupId = value; }
        public string UserGroupName { get => name; set => name = value; }
        public IList<UserGroupRight> GroupRightList { get => groupRightList; set => groupRightList = value; }
    }
}