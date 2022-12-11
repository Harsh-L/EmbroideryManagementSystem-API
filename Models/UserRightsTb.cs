using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class UserRightsTb
    {
        public UserRightsTb()
        {
            UserTb = new HashSet<UserTb>();
        }

        public int UserRightsId { get; set; }
        public int RId { get; set; }
        public int ModuleId { get; set; }

        public virtual ICollection<UserTb> UserTb { get; set; }
    }
}
