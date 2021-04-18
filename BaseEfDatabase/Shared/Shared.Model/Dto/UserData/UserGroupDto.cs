using System;
using System.Collections.Generic;

namespace Shared.Model.Dto.UserData
{
    public class UserGroupDto
    {
        private string name;
        private IList<UserGroupRightDto> groupRightList;

        public string UserGroupName { get => name; set => name = value; }
        public IList<UserGroupRightDto> GroupRightList { get => groupRightList; set => groupRightList = value; }
    }
}