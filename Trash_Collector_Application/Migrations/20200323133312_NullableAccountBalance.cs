using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector_Application.Migrations
{
    public partial class NullableAccountBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cc39695-7f62-4163-89b7-19f1789a2628");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d5bfe6-c08a-4807-a361-5f1436498dd3");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "700c7035-de13-452e-bd44-aad28996380f", "af241c01-964b-4085-9a8c-a707db4c08dc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5996cc99-c5c7-4718-bdd1-5c95657d73c8", "0ed18a69-87f8-421c-86cb-a3ef8b14e706", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5996cc99-c5c7-4718-bdd1-5c95657d73c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "700c7035-de13-452e-bd44-aad28996380f");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Accounts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3d5bfe6-c08a-4807-a361-5f1436498dd3", "468ad434-3861-468f-9518-b079aede2623", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cc39695-7f62-4163-89b7-19f1789a2628", "9702b796-b980-47b1-8242-3609375ed970", "Employee", "EMPLOYEE" });
        }
    }
}
