using System;
using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Repository.EF
{
    public partial class ticketContext : DbContext
    {
        public ticketContext()
        {
        }

        public ticketContext(DbContextOptions<ticketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFunction> RoleFunctions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.CurrentPosition)
                    .HasColumnName("current_position")
                    .HasMaxLength(20);

                entity.Property(e => e.ExpectPosition)
                    .HasColumnName("expect_position")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.University)
                    .HasColumnName("university")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profile_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RoleFunction>(entity =>
            {
                entity.ToTable("Role_function");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FunctionId).HasColumnName("functionID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.RoleFunction)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_function_Function");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFunction)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_function_Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
