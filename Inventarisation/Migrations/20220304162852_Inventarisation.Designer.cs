﻿// <auto-generated />
using System;
using Inventarisation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventarisation.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20220304162852_Inventarisation")]
    partial class Inventarisation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inventarisation.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Departme__737584F677F295BE")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Inventarisation.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comments")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DataOfPurchace")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_of_purchace");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((10))");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int")
                        .HasColumnName("Producer_id");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Serial_number");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("Status_id");

                    b.Property<int>("TypeOfDevice")
                        .HasColumnType("int")
                        .HasColumnName("Type_of_device");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeOfDevice");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Inventarisation.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("Department_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("Position_Id");

                    b.Property<DateTime>("StartWorkingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Start_working_date");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.HasIndex(new[] { "Name" }, "index1")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Inventarisation.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Position__737584F635BBBC1B")
                        .IsUnique();

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Inventarisation.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__PRODUCER__737584F6BC005017")
                        .IsUnique();

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Inventarisation.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Statuses__737584F637E6CC9C")
                        .IsUnique();

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Inventarisation.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Test", (string)null);
                });

            modelBuilder.Entity("Inventarisation.Models.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CommentsEnd")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Comments_end");

                    b.Property<string>("CommentsStart")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Comments_start");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_end");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_start");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int")
                        .HasColumnName("Device_id");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Inventarisation.Models.TypesOfDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Type_of___737584F60565AD9F")
                        .IsUnique();

                    b.ToTable("Types_of_devices", (string)null);
                });

            modelBuilder.Entity("Inventarisation.Models.Device", b =>
                {
                    b.HasOne("Inventarisation.Models.Producer", "Producer")
                        .WithMany("Devices")
                        .HasForeignKey("ProducerId")
                        .IsRequired()
                        .HasConstraintName("FK_Devices_Producers");

                    b.HasOne("Inventarisation.Models.Status", "Status")
                        .WithMany("Devices")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Devices__Status___5629CD9C");

                    b.HasOne("Inventarisation.Models.TypesOfDevice", "TypeOfDeviceNavigation")
                        .WithMany("Devices")
                        .HasForeignKey("TypeOfDevice")
                        .IsRequired()
                        .HasConstraintName("FK_Device_types");

                    b.Navigation("Producer");

                    b.Navigation("Status");

                    b.Navigation("TypeOfDeviceNavigation");
                });

            modelBuilder.Entity("Inventarisation.Models.Employee", b =>
                {
                    b.HasOne("Inventarisation.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("FK_to_department");

                    b.HasOne("Inventarisation.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .IsRequired()
                        .HasConstraintName("FK_to_position");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Inventarisation.Models.Transfer", b =>
                {
                    b.HasOne("Inventarisation.Models.Device", "Device")
                        .WithMany("Transfers")
                        .HasForeignKey("DeviceId")
                        .IsRequired()
                        .HasConstraintName("FK_Transfers_Devices");

                    b.HasOne("Inventarisation.Models.Employee", "Employees")
                        .WithMany("Transfers")
                        .HasForeignKey("EmployeesId")
                        .IsRequired()
                        .HasConstraintName("FK_Transfers_Employees");

                    b.Navigation("Device");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Inventarisation.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Inventarisation.Models.Device", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("Inventarisation.Models.Employee", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("Inventarisation.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Inventarisation.Models.Producer", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Inventarisation.Models.Status", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Inventarisation.Models.TypesOfDevice", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
