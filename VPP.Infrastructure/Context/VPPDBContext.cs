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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                .HasMaxLength(255).HasColumnType("nvarchar");

                e.Property(e => e.BirthDay);

                e.Property(e => e.Gender);

                e.Property(e => e.DateCreated);
                e.Property(e => e.DateUpdated);

                e.Property(e => e.IsActive);
                e.Property(e => e.IsAdmin);

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
                e.Property(e => e.DateCreated);
                e.Property(e => e.DateUpdated);
            });
            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("UserRole");
                e.HasKey(e => e.UserRoleId);

                e.Property(e => e.UserRoleId)
                .IsRequired();          
               
            });
        }
    }
}
