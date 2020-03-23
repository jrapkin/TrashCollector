using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector_Application.Migrations
{
    public partial class RemovePickupDayFromAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5996cc99-c5c7-4718-bdd1-5c95657d73c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "700c7035-de13-452e-bd44-aad28996380f");

            migrationBuilder.DropColumn(
                name: "PickupDay",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b269f42d-9897-44c9-8f35-601b5f2265db", "62052641-c40d-4aba-99a9-034595499731", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f1c6d31-37f1-48a2-be4f-b4287c83e990", "8abd9b1a-3d0d-4c63-9974-d36ca6673549", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f1c6d31-37f1-48a2-be4f-b4287c83e990");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b269f42d-9897-44c9-8f35-601b5f2265db");

            migrationBuilder.AddColumn<string>(
                name: "PickupDay",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "700c7035-de13-452e-bd44-aad28996380f", "af241c01-964b-4085-9a8c-a707db4c08dc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5996cc99-c5c7-4718-bdd1-5c95657d73c8", "0ed18a69-87f8-421c-86cb-a3ef8b14e706", "Employee", "EMPLOYEE" });
        }
    }
}
