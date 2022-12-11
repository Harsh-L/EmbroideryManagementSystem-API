using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class PartyAccountTb
    {
        public PartyAccountTb()
        {
            InStockTb = new HashSet<InStockTb>();
            PurchaseBillTb = new HashSet<PurchaseBillTb>();
            SaleBillTb = new HashSet<SaleBillTb>();
        }

        public int PaId { get; set; }
        public string PName { get; set; }
        public string Gstno { get; set; }
        public string Aline1 { get; set; }
        public string Aline2 { get; set; }
        public string City { get; set; }
        public decimal? Pincode { get; set; }
        public string StateCountry { get; set; }
        public string Type { get; set; }

        public virtual ICollection<InStockTb> InStockTb { get; set; }
        public virtual ICollection<PurchaseBillTb> PurchaseBillTb { get; set; }
        public virtual ICollection<SaleBillTb> SaleBillTb { get; set; }
    }
}
