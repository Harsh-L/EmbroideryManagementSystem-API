using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class SaleBillTb
    {
        public int SbId { get; set; }
        public int PaId { get; set; }
        public string BillNo { get; set; }
        public string Gstno { get; set; }
        public string ChallNo { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual PartyAccountTb Pa { get; set; }
    }
}
