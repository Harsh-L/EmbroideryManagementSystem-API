using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class UserTb
    {
        public int UId { get; set; }
        public string Name { get; set; }
        public decimal? ContactNo { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Dtstamp { get; set; }
        public int? UserRightsId { get; set; }

        public virtual UserRightsTb UserRights { get; set; }
    }
}
