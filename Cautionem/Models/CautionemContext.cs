using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cautionem.Models
{
    public partial class CautionemContext : DbContext
    {
        public CautionemContext()
        {
        }

        public CautionemContext(DbContextOptions<CautionemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank", "Cautionem");

                entity.HasIndex(e => e.Account)
                    .HasName("account_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_bank_company_idx");

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Bank)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bank_company");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company", "Cautionem");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.FiscalId)
                    .IsRequired()
                    .HasColumnName("fiscal_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("customer", "Cautionem");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_customer_company_idx");

                entity.HasIndex(e => new { e.CompanyId, e.CustomerId })
                    .HasName("customer_address_customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .HasColumnName("tax_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_company");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("customer_address", "Cautionem");

                entity.HasIndex(e => new { e.CompanyId, e.CustomerId })
                    .HasName("fk_customer_address_customer_idx");

                entity.HasIndex(e => new { e.CustomerId, e.CompanyId })
                    .HasName("fk_customer_address_customer");

                entity.Property(e => e.CustomerAddressId).HasColumnName("customer_address_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contact_email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasColumnName("contact_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ContactSurname)
                    .HasColumnName("contact_surname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => new { d.CustomerId, d.CompanyId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_address_customer");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.OrderId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("invoice", "Cautionem");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IssuedOn).HasColumnName("issued_on");

                entity.Property(e => e.PaidOn).HasColumnName("paid_on");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("invoice_detail", "Cautionem");

                entity.Property(e => e.InvoiceDetailId).HasColumnName("invoice_detail_id");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.ItemId })
                    .HasName("PRIMARY");

                entity.ToTable("item", "Cautionem");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_item_company_idx");

                entity.HasIndex(e => new { e.CompanyId, e.ItemTypeId })
                    .HasName("index_type");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_company");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("item_type", "Cautionem");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CustomerId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("order", "Cautionem");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_order_company_idx");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_company");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.OrderId, e.OrderDetailId })
                    .HasName("PRIMARY");

                entity.ToTable("order_detail", "Cautionem");

                entity.HasIndex(e => new { e.CompanyId, e.OrderId })
                    .HasName("fk_order_detail_order1_idx");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("item_description")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PRIMARY");

                entity.ToTable("payment_type", "Cautionem");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_payment_type_company1_idx");

                entity.HasIndex(e => e.PaymentId)
                    .HasName("index2");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaymentType)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_type_company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
