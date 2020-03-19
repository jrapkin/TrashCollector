using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector_Application.Data.Migrations
{
    public partial class EmployeeWithZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ff99cff-32d7-49ef-9e50-0e49d6538721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df8ac4d4-78ae-4c96-8b17-d5e024d47809");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2233b655-579f-4214-bc45-8ee62d7ffa3d", "90ff49d9-f020-4a44-8913-5aaf87af5fc5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f86fbc99-9db2-4197-9a37-44753e6c411b", "3f9012a6-0d92-4080-908d-b92c4e7e051c", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2233b655-579f-4214-bc45-8ee62d7ffa3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f86fbc99-9db2-4197-9a37-44753e6c411b");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df8ac4d4-78ae-4c96-8b17-d5e024d47809", "8bbc0ca7-6cc6-4e5f-a776-845989ffc40e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ff99cff-32d7-49ef-9e50-0e49d6538721", "c565b5c5-c66f-4b23-8093-29ff63f9e027", "Employee", "EMPLOYEE" });
        }
    }
}
