using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Inventarisation.Models;

namespace Inventarisation.Data
{
    public partial class MyAppContext : DbContext
    {
        public MyAppContext()
        {
        }

        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        //public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<Transfer> Transfers { get; set; } = null!;
        public virtual DbSet<TypesOfDevice> TypesOfDevices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-RP1UKF9\\SQLEXPRESS;Initial Catalog=Inventarisation;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Departme__737584F677F295BE")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
               entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });


            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.Property(e => e.DataOfPurchace).HasColumnName("Data_of_purchace");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((10))");

                entity.Property(e => e.ProducerId).HasColumnName("Producer_id");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Serial_number");

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.TypeOfDeviceId).HasColumnName("Type_of_device_Id");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_Producers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devices__Status___5629CD9C");

                entity.HasOne(d => d.TypeOfDevice)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.TypeOfDeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_types");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Name, "index1")
                    .IsUnique();

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("Position_Id");

                entity.Property(e => e.StartWorkingDate).HasColumnName("Start_working_date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_to_department");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_to_position");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Position__737584F635BBBC1B")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__PRODUCER__737584F6BC005017")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Statuses__737584F637E6CC9C")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            //modelBuilder.Entity<Test>(entity =>
            //{
            //    entity.ToTable("Test");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(10)
            //        .HasColumnName("name")
            //        .IsFixedLength();
            //});

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.Property(e => e.CommentsEnd)
                    .HasMaxLength(200)
                    .HasColumnName("Comments_end");

                entity.Property(e => e.CommentsStart)
                    .HasMaxLength(200)
                    .HasColumnName("Comments_start");

                entity.Property(e => e.DateEnd).HasColumnName("Date_end");

                entity.Property(e => e.DateStart).HasColumnName("Date_start");

                entity.Property(e => e.DeviceId).HasColumnName("Device_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transfers_Devices");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transfers_Employees");
            });

            modelBuilder.Entity<TypesOfDevice>(entity =>
            {
                entity.ToTable("Types_of_devices");

                entity.HasIndex(e => e.Name, "UQ__Type_of___737584F60565AD9F")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Inventarisation.Models.Login>? Login { get; set; }
    }
}
