using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<MapJobUser> MapJobUser { get; set; }
        public virtual DbSet<MapSkill> MapSkill { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Task_Job> Task_Job { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P62412M;Database=Ticket;user=sa;password=B@sebs1234%;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.Property(e => e.modify_time).HasColumnType("datetime");

                entity.Property(e => e.state).HasMaxLength(200);

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_Certificate_User");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.HasOne(d => d.company_)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.company_id)
                    .HasConstraintName("FK_Comment_Company");

                entity.HasOne(d => d.create_byNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.create_by)
                    .HasConstraintName("FK_Comment_User");

                entity.HasOne(d => d.job_)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.job_id)
                    .HasConstraintName("FK_Comment_Job");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.start_time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.HasOne(d => d.create_byNavigation)
                    .WithMany(p => p.Conversationcreate_byNavigation)
                    .HasForeignKey(d => d.create_by)
                    .HasConstraintName("FK_Conversation_User1");

                entity.HasOne(d => d.to_user_)
                    .WithMany(p => p.Conversationto_user_)
                    .HasForeignKey(d => d.to_user_id)
                    .HasConstraintName("FK_Conversation_User");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.end_time).HasColumnType("datetime");

                entity.Property(e => e.school_name).HasMaxLength(200);

                entity.Property(e => e.start_time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.end_time).HasColumnType("datetime");

                entity.Property(e => e.position).HasMaxLength(200);

                entity.Property(e => e.project_name).HasMaxLength(500);

                entity.Property(e => e.start_time).HasColumnType("datetime");

                entity.HasOne(d => d.company_)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.company_id)
                    .HasConstraintName("FK_Experience_Company");

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_Experience_User");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.city).HasMaxLength(500);

                entity.Property(e => e.contact_info).HasMaxLength(500);

                entity.Property(e => e.create_by).HasMaxLength(50);

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.Property(e => e.end_time).HasColumnType("datetime");

                entity.Property(e => e.language_code).HasMaxLength(50);

                entity.Property(e => e.language_communicate).HasMaxLength(50);

                entity.Property(e => e.level).HasMaxLength(50);

                entity.Property(e => e.modify_by).HasMaxLength(50);

                entity.Property(e => e.modify_time).HasColumnType("datetime");

                entity.Property(e => e.position).HasMaxLength(500);

                entity.Property(e => e.salary).HasMaxLength(500);

                entity.Property(e => e.stat_time).HasColumnType("datetime");

                entity.Property(e => e.state)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.type_job)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("(from_hr,from_candidate)");

                entity.HasOne(d => d.company_)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.company_id)
                    .HasConstraintName("FK_Job_Company");
            });

            modelBuilder.Entity<MapJobUser>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.MapJobUser)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_MapJobUser_Job");

                entity.HasOne(d => d.user_Navigation)
                    .WithMany(p => p.MapJobUser)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_MapJobUser_User");
            });

            modelBuilder.Entity<MapSkill>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.HasOne(d => d.job_)
                    .WithMany(p => p.MapSkill)
                    .HasForeignKey(d => d.job_id)
                    .HasConstraintName("FK_MapSkill_Job");

                entity.HasOne(d => d.skill_)
                    .WithMany(p => p.MapSkill)
                    .HasForeignKey(d => d.skill_id)
                    .HasConstraintName("FK_MapSkill_Skill");

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.MapSkill)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_MapSkill_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(100);
            });

            modelBuilder.Entity<Task_Job>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.Property(e => e.description).HasMaxLength(1000);

                entity.Property(e => e.name).HasMaxLength(500);

                entity.HasOne(d => d.job_)
                    .WithMany(p => p.Task_Job)
                    .HasForeignKey(d => d.job_id)
                    .HasConstraintName("FK_Task_Job_Job");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.address).HasMaxLength(1000);

                entity.Property(e => e.code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.create_by)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.create_time).HasColumnType("datetime");

                entity.Property(e => e.email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.link_cv).HasMaxLength(500);

                entity.Property(e => e.modify_by)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.modify_time).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.note).HasMaxLength(1000);

                entity.Property(e => e.open_job_time).HasColumnType("datetime");

                entity.Property(e => e.password).HasMaxLength(1000);

                entity.Property(e => e.phone).HasMaxLength(50);

                entity.Property(e => e.state)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.company_)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.company_id)
                    .HasConstraintName("FK_User_Company");

                entity.HasOne(d => d.education_)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.education_id)
                    .HasConstraintName("FK_User_Education");

                entity.HasOne(d => d.role_)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.role_id)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
