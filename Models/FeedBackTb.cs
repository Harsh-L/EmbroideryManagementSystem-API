using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class FeedBackTb
    {
        public int FbId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public string Message { get; set; }
        public DateTime? Time { get; set; }
    }
}
