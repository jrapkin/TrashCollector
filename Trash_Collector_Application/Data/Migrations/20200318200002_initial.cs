using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector_Application.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9132fa2f-ad14-425d-bcfb-4864d990c7e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cefcd840-73c2-4c60-84ac-9b55ef395eab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d44f84-237e-4196-b994-fc754aace3aa", "8b540abb-ab42-4ce9-8982-1dfc1f1e1f96", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbf8d174-3549-44e6-9ebd-9e1cc3ab2eff", "edc52f6d-f454-49d5-bbd3-dbc364b19309", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d44f84-237e-4196-b994-fc754aace3aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbf8d174-3549-44e6-9ebd-9e1cc3ab2eff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cefcd840-73c2-4c60-84ac-9b55ef395eab", "5eaba913-2e9f-4afe-92f4-235abb46e618", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9132fa2f-ad14-425d-bcfb-4864d990c7e1", "8a050629-48de-400e-b7c1-d1aaa9449cdb", "Employee", "EMPLOYEE" });
        }
    }
}
