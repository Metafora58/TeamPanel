using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeamPanel.DAL.Models
{
    public partial class TeamPanelContext : DbContext
    {
        public TeamPanelContext()
        {
        }

        public TeamPanelContext(DbContextOptions<TeamPanelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TeamPanel;Trusted_Connection=True;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Activity_Name")
                    .IsUnique();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Activity_Images_ImageId");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasIndex(e => e.ImageName)
                    .HasName("UX_Gallery_ImageName")
                    .IsUnique();

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("GENDER");

                entity.HasIndex(e => e.Name)
                    .HasName("UX_Gender_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Participation>(entity =>
            {
                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => new { e.Username, e.Email, e.PhoneNumber })
                    .HasName("UX_Player_Username_Email_PhoneNumber")
                    .IsUnique();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Player_Gender_GenderId");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Player_Images_ImageId");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.Identifier)
                    .HasName("UX_Team_Identifier")
                    .IsUnique();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Captain)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.CaptainId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Team_Images_ImageId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
