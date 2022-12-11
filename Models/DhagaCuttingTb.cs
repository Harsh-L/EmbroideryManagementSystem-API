using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class DhagaCuttingTb
    {
        public int DcId { get; set; }
        public string Name { get; set; }
        public int? EmpId { get; set; }
        public DateTime? Date { get; set; }
        public int? Saree { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }

        public virtual EmployeeTb Emp { get; set; }
    }
}
