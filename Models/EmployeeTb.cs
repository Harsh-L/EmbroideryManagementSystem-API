using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class EmployeeTb
    {
        public EmployeeTb()
        {
            DhagaCuttingTb = new HashSet<DhagaCuttingTb>();
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public decimal? Aadhar { get; set; }
        public string Category { get; set; }
        public decimal? Phone { get; set; }

        public virtual ICollection<DhagaCuttingTb> DhagaCuttingTb { get; set; }
    }
}
