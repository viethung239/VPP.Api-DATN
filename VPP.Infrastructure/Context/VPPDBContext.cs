using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Domain.Entities;

namespace VPP.Infrastructure.Context
{
    public class VPPDBContext : DbContext
    {
        public VPPDBContext() { }
        public VPPDBContext(DbContextOptions<VPPDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<CategoryGroup> CategoryGroups { get; set; }
        public virtual DbSet<CompanySupplier> CompanySuppliers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<UserRole> UserRoles { get; set; }  
        public virtual DbSet<WareHouse> WareHouses { get; set; }
        public virtual DbSet<WareHouseDetail> WareHouseDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(e => e.CategoryId);

                e.Property(e => e.CategoryId)
                .IsRequired();

                e.Property(e => e.CategoryName)
                .HasMaxLength(255).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

                e.HasOne(p => p.CategoryGroups)
                .WithMany(c => c.Categorys)
                .HasForeignKey(p => p.CategoryGroupId)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<CategoryGroup>(e =>
            {
                e.ToTable("CategoryGroup");
                e.HasKey(e => e.CategoryGroupId);

                e.Property(e => e.CategoryGroupId)
                .IsRequired();

                e.Property(e => e.CategoryGroupName)
                .HasMaxLength(255).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);
            });
            modelBuilder.Entity<CompanySupplier>(e =>
            {
                e.ToTable("CompanySupplier");
                e.HasKey(e => e.SupplierId);

                e.Property(e => e.SupplierId)
                .IsRequired();

                e.Property(e => e.SupplierName)
                .HasMaxLength(100).HasColumnType("nvarchar");

                e.Property(e => e.Phone)
                .HasMaxLength(15).HasColumnType("nvarchar");

                e.Property(e => e.Address)
                .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.Comune)
                .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.District)
               .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.City)
               .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.Email)
               .HasMaxLength(150).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);
            });
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(e => e.OrderId);

                e.Property(e => e.OrderId)
                .IsRequired();

                e.Property(e => e.TotalAmount);
              
                e.Property(e => e.OrderCode)
                .HasMaxLength(15).HasColumnType("nvarchar");

                e.Property(e => e.PaymentType);

                e.Property(e => e.Status);

                e.Property(e => e.Note)
                .HasMaxLength(500).HasColumnType("nvarchar");
              
                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

                e.HasOne(or => or.Users)
                .WithMany(u => u.Orders)
                .HasForeignKey(or => or.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            });
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => e.OrderDetailId);

                e.Property(e => e.OrderDetailId)
                .IsRequired();

                e.Property(e => e.Quantity);

                e.Property(e => e.Price);

                e.Property(e => e.Total);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

                e.HasOne(ord => ord.Orders)
                .WithMany(or => or.OrderDetails)
                .HasForeignKey(ord => ord.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

              

            });
            modelBuilder.Entity<Post>(e =>
            {
                e.ToTable("Post");
                e.HasKey(e => e.PostId);

                e.Property(e => e.PostId)
                .IsRequired();

                e.Property(e => e.PostName)
                .HasMaxLength(150).HasColumnType("nvarchar");

                e.Property(e => e.PostImg)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.SContent)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.LContent)
                .HasMaxLength(2000).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);
                e.Property(e => e.IsHot);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);


                e.HasOne(p => p.Users)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            });
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(e => e.ProductId);

                e.Property(e => e.ProductId)
                .IsRequired();

                e.Property(e => e.ProductName)
                .HasMaxLength(150).HasColumnType("nvarchar");

                e.Property(e => e.ProductPrice);
               
                e.Property(e => e.SDescription)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.LDescription)
                .HasMaxLength(2000).HasColumnType("nvarchar");

                e.Property(e => e.ProductImage)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.IsHot);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

                e.HasOne(p => p.Categorys) 
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId) 
                .OnDelete(DeleteBehavior.SetNull);


                
            });
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasKey(e => e.RoleId);

                e.Property(e => e.RoleId)
                .IsRequired();

                e.Property(e => e.RoleName)
                .HasMaxLength(100).HasColumnType("nvarchar");

                e.Property(e => e.RoleDescription)
                .HasMaxLength(255).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.UserId);

                e.Property(e => e.UserId)
                .IsRequired();                

                e.Property(e => e.UserName)
                .HasMaxLength(250).HasColumnType("nvarchar");

                e.Property(e => e.Password)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.Email)
                .HasMaxLength(300).HasColumnType("nvarchar");

                e.Property(e => e.Avartar)
                .HasMaxLength(500).HasColumnType("nvarchar");

                e.Property(e => e.FullName)
                .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.Phone)
                .HasMaxLength(12).HasColumnType("nvarchar");

                e.Property(e => e.Address)
                 .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.Comune)
                .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.District)
               .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.City)
               .HasMaxLength(50).HasColumnType("nvarchar");

                e.Property(e => e.BirthDay);

                e.Property(e => e.Gender);

                e.Property(e => e.IsAdmin);

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

            });         
            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("UserRole");
                e.HasKey(e => e.UserRoleId);

                e.Property(e => e.UserRoleId)
                .IsRequired();

                e.HasOne(ur => ur.Roles)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(); 

                e.HasOne(ur => ur.Users)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

           
            });
           
               
            modelBuilder.Entity<WareHouse>(e =>
            {
                e.ToTable("WareHouse");
                e.HasKey(e => e.WareHouseId);

                e.Property(e => e.WareHouseId)
                .IsRequired();

                e.Property(e => e.WareHouseName)
                .HasMaxLength(150).HasColumnType("nvarchar");

                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);
            });
            modelBuilder.Entity<WareHouseDetail>(e =>
            {
                e.ToTable("WareHouseDetail");
                e.HasKey(e => e.WareHouseDetailId);

                e.Property(e => e.WareHouseDetailId)
                .IsRequired();

                e.Property(e => e.Quantity);
               
                e.Property(e => e.IsActive);

                e.Property(e => e.DateCreated);

                e.Property(e => e.DateUpdated);

                e.HasOne(whd => whd.WareHouses)
                .WithMany(wh => wh.WareHouseDetails)
                .HasForeignKey(whd => whd.WareHouseId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

                e.HasOne(whd => whd.CompanySuppliers)
                .WithMany(cs => cs.WareHouseDetails)
                .HasForeignKey(whd => whd.SupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

                e.HasOne(whd => whd.Products)
                .WithMany(p => p.WareHouseDetails)
                .HasForeignKey(whd => whd.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            });
        }
    }
}
