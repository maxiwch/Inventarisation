using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventarisation.Migrations
{
    public partial class Inventarisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            

            migrationBuilder.CreateTable(
                name: "Types_of_devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types_of_devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Start_working_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Position_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_to_department",
                        column: x => x.Department_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_to_position",
                        column: x => x.Position_Id,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((10))"),
                    Type_of_device_Id = table.Column<int>(type: "int", nullable: false),
                    Producer_id = table.Column<int>(type: "int", nullable: false),
                    Data_of_purchace = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_id = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Serial_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Devices__Status___5629CD9C",
                        column: x => x.Status_id,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Device_types",
                        column: x => x.Type_of_device_Id,
                        principalTable: "Types_of_devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devices_Producers",
                        column: x => x.Producer_id,
                        principalTable: "Producers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    Device_id = table.Column<int>(type: "int", nullable: false),
                    Date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments_start = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date_end = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments_end = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Devices",
                        column: x => x.Device_id,
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfers_Employees",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__737584F677F295BE",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Producer_id",
                table: "Devices",
                column: "Producer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Status_id",
                table: "Devices",
                column: "Status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Type_of_device",
                table: "Devices",
                column: "Type_of_device_Id");

            migrationBuilder.CreateIndex(
                name: "index1",
                table: "Employees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_id",
                table: "Employees",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Position_Id",
                table: "Employees",
                column: "Position_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Position__737584F635BBBC1B",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PRODUCER__737584F6BC005017",
                table: "Producers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Statuses__737584F637E6CC9C",
                table: "Statuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_Device_id",
                table: "Transfers",
                column: "Device_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_EmployeesId",
                table: "Transfers",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "UQ__Type_of___737584F60565AD9F",
                table: "Types_of_devices",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types_of_devices");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
