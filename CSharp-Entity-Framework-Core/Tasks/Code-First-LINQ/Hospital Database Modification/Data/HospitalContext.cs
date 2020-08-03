using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .HasKey(p => p.PatientId);

                entity
                    .Property(p => p.FirstName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(p => p.LastName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(p => p.Address)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                entity
                    .Property(p => p.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(80);

                entity
                    .Property(p => p.HasInsurance)
                    .IsRequired();      
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .HasKey(k => k.DoctorId);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity                    
                    .Property(p => p.Specialty)
                    .HasMaxLength(100)
                    .IsUnicode();
            });
                

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity
                    .HasKey(v => v.VisitationId);

                entity
                    .Property(v => v.Date)
                    .IsRequired();

                entity
                    .Property(v => v.Comments)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                entity
                    .HasOne(v => v.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(v => v.PatientId);                
            });


            modelBuilder.Entity<Diagnose>(entity => 
            {
                entity
                    .HasKey(d => d.DiagnoseId);

                entity
                    .Property(n => n.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(n => n.Comments)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                entity
                    .HasOne(d => d.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientId);
            });


            modelBuilder.Entity<Medicament > (entity =>
            {
                entity
                    .HasKey(m => m.MedicamentId);

                entity
                    .Property(m => m.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);                
            });

            modelBuilder.Entity<PatientMedicament > (entity =>
            {
                entity
                    .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity
                    .HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId);

                entity
                    .HasOne(pm => pm.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(pm => pm.MedicamentId);
            });
        }
    }
}
