using System.Collections.Generic;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Entities
{
    public class Role
    {
        public string Id { get; protected set; } = Utils.Id();
        public RoleType RoleType { get; protected set; } = RoleType.User;
        public string RoleName { get; protected set; }

        public virtual ICollection<UserRole> UserRoles { get; protected set; } = new HashSet<UserRole>();

        public static Role Create(RoleType roleType) => new Role
        {
            RoleType = roleType,
            RoleName = Utils.EnumToString<RoleType>(roleType)
        };
    }
}