using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmbroidaryManagementSystem.Models
{
    public partial class EmbroidaryManagementSystemContext : DbContext
    {
        public EmbroidaryManagementSystemContext()
        {
        }

        public EmbroidaryManagementSystemContext(DbContextOptions<EmbroidaryManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DhagaCuttingTb> DhagaCuttingTb { get; set; }
        public virtual DbSet<EmployeeTb> EmployeeTb { get; set; }
        public virtual DbSet<FeedBackTb> FeedBackTb { get; set; }
        public virtual DbSet<InStockItemTb> InStockItemTb { get; set; }
        public virtual DbSet<InStockTb> InStockTb { get; set; }
        public virtual DbSet<ModuleMasterTb> ModuleMasterTb { get; set; }
        public virtual DbSet<PartyAccountTb> PartyAccountTb { get; set; }
        public virtual DbSet<ProductTb> ProductTb { get; set; }
        public virtual DbSet<PurchaseBillTb> PurchaseBillTb { get; set; }
        public virtual DbSet<PurchaseItemTb> PurchaseItemTb { get; set; }
        public virtual DbSet<RoleTb> RoleTb { get; set; }
        public virtual DbSet<SaleBillTb> SaleBillTb { get; set; }
        public virtual DbSet<SaleItemTb> SaleItemTb { get; set; }
        public virtual DbSet<UserRightsTb> UserRightsTb { get; set; }
        public virtual DbSet<UserTb> UserTb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HARSH;Initial Catalog=EmbroidaryManagementSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DhagaCuttingTb>(entity =>
            {
                entity.HasKey(e => e.DcId);

                entity.ToTable("dhagaCuttingTB");

                entity.Property(e => e.DcId)
                    .HasColumnName("dcID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Saree).HasColumnName("saree");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("money");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.DhagaCuttingTb)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_dhagaCuttingTB_employeeTB");
            });

            modelBuilder.Entity<EmployeeTb>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("employeeTB");

                entity.Property(e => e.EmpId)
                    .HasColumnName("empID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aadhar)
                    .HasColumnName("aadhar")
                    .HasColumnType("numeric(16, 0)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<FeedBackTb>(entity =>
            {
                entity.HasKey(e => e.FbId);

                entity.ToTable("feedBackTB");

                entity.Property(e => e.FbId)
                    .HasColumnName("fbID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<InStockItemTb>(entity =>
            {
                entity.HasKey(e => e.InStockItem);

                entity.ToTable("inStockItemTB");

                entity.Property(e => e.InStockItem)
                    .HasColumnName("inStockItem")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.ChallNo)
                    .IsRequired()
                    .HasColumnName("challNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<InStockTb>(entity =>
            {
                entity.HasKey(e => e.InStockId);

                entity.ToTable("inStockTB");

                entity.Property(e => e.InStockId)
                    .HasColumnName("inStockID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.ChallNo)
                    .HasColumnName("challNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("money");

                entity.Property(e => e.Gstno)
                    .HasColumnName("gstno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.PaId).HasColumnName("paID");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("money");

                entity.HasOne(d => d.Pa)
                    .WithMany(p => p.InStockTb)
                    .HasForeignKey(d => d.PaId)
                    .HasConstraintName("FK_inStockTB_partyAccountTB");
            });

            modelBuilder.Entity<ModuleMasterTb>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("moduleMasterTB");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("moduleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delete).HasColumnName("delete");

                entity.Property(e => e.Insert).HasColumnName("insert");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Update).HasColumnName("update");

                entity.Property(e => e.View).HasColumnName("view");
            });

            modelBuilder.Entity<PartyAccountTb>(entity =>
            {
                entity.HasKey(e => e.PaId);

                entity.ToTable("partyAccountTB");

                entity.Property(e => e.PaId)
                    .HasColumnName("paID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aline1)
                    .HasColumnName("aline-1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aline2)
                    .HasColumnName("aline-2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gstno)
                    .HasColumnName("gstno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PName)
                    .HasColumnName("pName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasColumnName("pincode")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.StateCountry)
                    .HasColumnName("state/country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductTb>(entity =>
            {
                entity.HasKey(e => e.PdId);

                entity.ToTable("productTB");

                entity.Property(e => e.PdId)
                    .HasColumnName("pdID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseBillTb>(entity =>
            {
                entity.HasKey(e => e.PbId);

                entity.ToTable("purchaseBillTB");

                entity.Property(e => e.PbId)
                    .HasColumnName("pbID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.ChallNo)
                    .IsRequired()
                    .HasColumnName("challNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("money");

                entity.Property(e => e.Gstno)
                    .HasColumnName("gstno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.PaId).HasColumnName("paID");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("money");

                entity.HasOne(d => d.Pa)
                    .WithMany(p => p.PurchaseBillTb)
                    .HasForeignKey(d => d.PaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchaseBillTB_partyAccountTB");
            });

            modelBuilder.Entity<PurchaseItemTb>(entity =>
            {
                entity.HasKey(e => e.PiId);

                entity.ToTable("purchaseItemTB");

                entity.Property(e => e.PiId)
                    .HasColumnName("piID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.ChallNo)
                    .HasColumnName("challNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Design)
                    .HasColumnName("design")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<RoleTb>(entity =>
            {
                entity.HasKey(e => e.RId);

                entity.ToTable("roleTB");

                entity.Property(e => e.RId)
                    .HasColumnName("rID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SaleBillTb>(entity =>
            {
                entity.HasKey(e => e.SbId);

                entity.ToTable("saleBillTB");

                entity.Property(e => e.SbId)
                    .HasColumnName("sbID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.BillNo)
                    .IsRequired()
                    .HasColumnName("billNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.ChallNo)
                    .HasColumnName("challNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("money");

                entity.Property(e => e.Gstno)
                    .HasColumnName("gstno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.PaId).HasColumnName("paID");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("money");

                entity.HasOne(d => d.Pa)
                    .WithMany(p => p.SaleBillTb)
                    .HasForeignKey(d => d.PaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_saleBillTB_partyAccountTB");
            });

            modelBuilder.Entity<SaleItemTb>(entity =>
            {
                entity.HasKey(e => e.SiId);

                entity.ToTable("saleItemTB");

                entity.Property(e => e.SiId)
                    .HasColumnName("siID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.BillNo)
                    .IsRequired()
                    .HasColumnName("billNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("money");

                entity.Property(e => e.Design)
                    .HasColumnName("design")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plain).HasColumnName("plain");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("money");

                entity.Property(e => e.Work).HasColumnName("work");
            });

            modelBuilder.Entity<UserRightsTb>(entity =>
            {
                entity.HasKey(e => e.UserRightsId);

                entity.ToTable("userRightsTB");

                entity.Property(e => e.UserRightsId)
                    .HasColumnName("userRightsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModuleId).HasColumnName("moduleID");

                entity.Property(e => e.RId).HasColumnName("rID");
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UId);

                entity.ToTable("userTB");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contactNo")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Dtstamp)
                    .HasColumnName("dtstamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRightsId).HasColumnName("userRightsID");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserRights)
                    .WithMany(p => p.UserTb)
                    .HasForeignKey(d => d.UserRightsId)
                    .HasConstraintName("FK_userTB_userRightsTB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
