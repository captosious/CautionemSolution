using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                entity.HasKey(e => new { e.BankId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("bank");

                entity.HasIndex(e => e.Account, "account_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId, "fk_bank_company_idx");

                entity.Property(e => e.BankId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("bank_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("account");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Banks)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bank_company");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(45)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(45)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.FiscalId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("fiscal_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(2)
                    .HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.CustomerId })
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.HasIndex(e => new { e.CompanyId, e.CustomerId }, "customer_address_customer");

                entity.HasIndex(e => e.CustomerId, "customer_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId, "fk_customer_company_idx");

                entity.HasIndex(e => e.CountryId, "fk_customer_country1_idx");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(75)
                    .HasColumnName("address");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("country_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.FiscalId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fiscal_id");

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");

                entity.Property(e => e.Town)
                    .HasMaxLength(45)
                    .HasColumnName("town");

                entity.Property(e => e.Web)
                    .HasMaxLength(75)
                    .HasColumnName("web");

                entity.Property(e => e.Zip)
                    .HasMaxLength(45)
                    .HasColumnName("zip");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_company");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_country1");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CompanyId, e.CustomerId })
                    .HasName("PRIMARY");

                entity.ToTable("customer_contacts");

                entity.HasIndex(e => new { e.CompanyId, e.CustomerId }, "fk_customer_contacts_customer_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(45)
                    .HasColumnName("address");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(45)
                    .HasColumnName("country_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");

                entity.Property(e => e.Town)
                    .HasMaxLength(45)
                    .HasColumnName("town");

                entity.Property(e => e.Zip)
                    .HasMaxLength(45)
                    .HasColumnName("zip");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => new { d.CompanyId, d.CustomerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_contacts_customer1");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => new { e.FileId, e.CompanyId, e.CustomerId })
                    .HasName("PRIMARY");

                entity.ToTable("file");

                entity.HasIndex(e => e.CompanyId, "fk_file_company_idx");

                entity.HasIndex(e => new { e.CompanyId, e.CustomerId }, "fk_file_customer_idx");

                entity.HasIndex(e => e.Reference, "reference_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FileId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("file_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Folder)
                    .HasMaxLength(245)
                    .HasColumnName("folder");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("reference");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_file_company");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => new { d.CompanyId, d.CustomerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_file_customer");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.OrderId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("invoice");

                entity.Property(e => e.InvoiceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("invoice_id");

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
                entity.ToTable("invoice_detail");

                entity.Property(e => e.InvoiceDetailId).HasColumnName("invoice_detail_id");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("item");

                entity.HasIndex(e => e.CompanyId, "fk_item_company_idx");

                entity.HasIndex(e => new { e.CompanyId, e.ItemTypeId }, "index_type");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("item_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("price");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(45)
                    .HasColumnName("tax_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_company");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("item_type");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.FileId, e.OrderId })
                    .HasName("PRIMARY");

                entity.ToTable("order");

                entity.HasIndex(e => e.FileId, "fk_order_file_idx");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(45)
                    .HasColumnName("item_description");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(45)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("item_price");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => new { e.PaymentId, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("payment_type");

                entity.HasIndex(e => e.CompanyId, "fk_payment_type_company1_idx");

                entity.HasIndex(e => e.PaymentId, "index2");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("payment_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Terms)
                    .HasMaxLength(255)
                    .HasColumnName("terms");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaymentTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_type_company");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("tax");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Tax1)
                    .HasColumnType("decimal(2,2)")
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Username, e.CompanyId })
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.CompanyId, "fk_users_company_idx");

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .HasColumnName("username");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(25)
                    .HasColumnName("family_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.SecurityId)
                    .HasColumnName("security_id");

                entity.Property(e => e.Picture)
                    .HasColumnType("blob")
                    .HasColumnName("picture");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_company1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
