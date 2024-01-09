using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Data;

public partial class Teat2Context : DbContext
{
    public Teat2Context()
    {
    }

    public Teat2Context(DbContextOptions<Teat2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetNavigationMenu> AspNetNavigationMenus { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoleMenuPermission> AspNetRoleMenuPermissions { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<ECourse> ECourses { get; set; }

    public virtual DbSet<EJob> EJobs { get; set; }

    public virtual DbSet<EMedel> EMedels { get; set; }

    public virtual DbSet<ETransfer> ETransfers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Jop> Jops { get; set; }

    public virtual DbSet<Medel> Medels { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<Tranfer> Tranfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=teat2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetNavigationMenu>(entity =>
        {
            entity.ToTable("AspNetNavigationMenu");

            entity.HasIndex(e => e.ParentMenuId, "IX_AspNetNavigationMenu_ParentMenuId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu).HasForeignKey(d => d.ParentMenuId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.RoleId).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetRoleMenuPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.NavigationMenuId });

            entity.ToTable("AspNetRoleMenuPermission");

            entity.HasIndex(e => e.NavigationMenuId, "IX_AspNetRoleMenuPermission_NavigationMenuId");

            entity.HasOne(d => d.NavigationMenu).WithMany(p => p.AspNetRoleMenuPermissions)
                .HasForeignKey(d => d.NavigationMenuId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).IsRequired();
        });

        modelBuilder.Entity<ECourse>(entity =>
        {
            entity.HasKey(e => e.IdemployeesCourses);

            entity.ToTable("E_Courses");

            entity.Property(e => e.IdemployeesCourses).HasColumnName("IDEmployeesCourses");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Idemployees).HasColumnName("IDEmployees");
            entity.Property(e => e.Rating)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("rating");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Course).WithMany(p => p.ECourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Courses_Course");

            entity.HasOne(d => d.IdemployeesNavigation).WithMany(p => p.ECourses)
                .HasForeignKey(d => d.Idemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Courses_employees");
        });

        modelBuilder.Entity<EJob>(entity =>
        {
            entity.HasKey(e => e.EJobsId);

            entity.ToTable("E_Jobs");

            entity.Property(e => e.EJobsId).HasColumnName("E_JobsID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.JobId).HasColumnName("JobID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EJobs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Jobs_employees");

            entity.HasOne(d => d.Job).WithMany(p => p.EJobs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Jobs_Jops");
        });

        modelBuilder.Entity<EMedel>(entity =>
        {
            entity.HasKey(e => e.IdeMedals).HasName("PK_Medals");

            entity.ToTable("E_Medels");

            entity.Property(e => e.IdeMedals).HasColumnName("IDE_Medals");
            entity.Property(e => e.DateMedals).HasColumnType("date");
            entity.Property(e => e.Idemployees).HasColumnName("IDEmployees");
            entity.Property(e => e.MedalsId).HasColumnName("MedalsID");

            entity.HasOne(d => d.IdemployeesNavigation).WithMany(p => p.EMedels)
                .HasForeignKey(d => d.Idemployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medals_employees");

            entity.HasOne(d => d.Medals).WithMany(p => p.EMedels)
                .HasForeignKey(d => d.MedalsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Medels_Medels");
        });

        modelBuilder.Entity<ETransfer>(entity =>
        {
            entity.HasKey(e => e.IdTransfer).HasName("PK_Transfer");

            entity.ToTable("E_Transfer");

            entity.Property(e => e.IdTransfer).ValueGeneratedOnAdd();
            entity.Property(e => e.TransferDate).HasColumnType("date");
            entity.Property(e => e.TransferId).HasColumnName("TransferID");

            entity.HasOne(d => d.IdEmployeesNavigation).WithMany(p => p.ETransfers)
                .HasForeignKey(d => d.IdEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transfer_employees");

            entity.HasOne(d => d.IdTransferNavigation).WithOne(p => p.ETransfer)
                .HasForeignKey<ETransfer>(d => d.IdTransfer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E_Transfer_Tranfer");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployees);

            entity.ToTable("employees");

            entity.Property(e => e.Employeenumber).HasColumnName("EMPLOYEENUMBER");
            entity.Property(e => e.Enterd).HasColumnName("enterd");
            entity.Property(e => e.Identitynumber).HasColumnName("IDENTITYNUMBER");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.RankId).HasColumnName("RankID");

            entity.HasOne(d => d.JopTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JopType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_Jops");

            entity.HasOne(d => d.Rank).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_Rank");
        });

        modelBuilder.Entity<Jop>(entity =>
        {
            entity.HasKey(e => e.Idjops);

            entity.Property(e => e.Idjops).HasColumnName("IDJops");
            entity.Property(e => e.JopName).IsRequired();
        });

        modelBuilder.Entity<Medel>(entity =>
        {
            entity.HasKey(e => e.Idmedels);

            entity.Property(e => e.Idmedels).HasColumnName("IDMedels");
            entity.Property(e => e.MedelsName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.Idrank);

            entity.ToTable("Rank");

            entity.Property(e => e.Idrank).HasColumnName("IDRank");
            entity.Property(e => e.Rankname)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Tranfer>(entity =>
        {
            entity.HasKey(e => e.TransferId);

            entity.ToTable("Tranfer");

            entity.Property(e => e.TransferId).HasColumnName("transferID");
            entity.Property(e => e.TransferName)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
