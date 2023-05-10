using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository.Models;

namespace Repositories.Repository;

public partial class HmoDbContext : DbContext
{
    public HmoDbContext()
    {
    }

    public HmoDbContext(DbContextOptions<HmoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<EmplVaccination> EmplVaccinations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7VCB93M\\SQLEXPRESS;Initial Catalog=HMO;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Disease__7AD04F11993E5BFC");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithOne(p => p.Disease)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Disease_Employee");
        });

        modelBuilder.Entity<EmplVaccination>(entity =>
        {
            entity.HasKey(e => e.EmplVaccinationId).HasName("PK__EmplVacc__6FC1BE809C9F7070");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmplVaccinations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmplVaccination_Employee");

            entity.HasOne(d => d.Vaccination).WithMany(p => p.EmplVaccinations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmplVaccination_Vaccination");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F116C70C04E");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.VaccinationId).HasName("PK__Vaccinat__4664304722BEF997");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
