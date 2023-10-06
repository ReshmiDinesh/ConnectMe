using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConnectMe.UserMicroService.Data;

public partial class ConnectMeContext : DbContext
{
    public ConnectMeContext()
    {
    }

    public ConnectMeContext(DbContextOptions<ConnectMeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserProfileDetail> UserProfileDetails { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ConnectMe;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("UserProfile", "users");

            entity.Property(e => e.UserProfileId).HasColumnName("UserProfile_Id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.StatusId).HasColumnName("status_Id");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserTypeId).HasColumnName("UserType_Id");

            entity.HasOne(d => d.UserType).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_UserType_UserProfile");
        });

        modelBuilder.Entity<UserProfileDetail>(entity =>
        {
            entity.HasKey(e => e.UserProfileDetailsId);

            entity.ToTable("UserProfileDetails", "users");

            entity.Property(e => e.UserProfileDetailsId).HasColumnName("UserProfileDetails_Id");
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserProfileId).HasColumnName("UserProfile_Id");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserProfileDetails)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserProfile_UserProfileDetails");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType", "users");

            entity.Property(e => e.UserTypeId).HasColumnName("UserType_Id");
            entity.Property(e => e.UserType1)
                .HasMaxLength(30)
                .HasColumnName("UserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
