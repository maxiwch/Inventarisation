using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventarisation.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "Transfers",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_EmployeesId",
                table: "Transfers",
                newName: "IX_Transfers_EmployeeId");

           
            migrationBuilder.RenameIndex(
                name: "IX_Devices_Type_of_device",
                table: "Devices",
                newName: "IX_Devices_Type_of_device_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Transfers",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_EmployeeId",
                table: "Transfers",
                newName: "IX_Transfers_EmployeesId");

        

            migrationBuilder.RenameIndex(
                name: "IX_Devices_Type_of_device_Id",
                table: "Devices",
                newName: "IX_Devices_Type_of_device");

          
               
        }
    }
}
