using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector_Application.Migrations
{
    public partial class ServiceWithConfirmPickupProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e1408c6-34b4-488a-aa18-2ad15e94e6f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd222b73-33df-41a6-b1a2-02cfb01ca0c6");

            migrationBuilder.AddColumn<bool>(
                name: "ServiceIsCompleted",
                table: "Services",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4dd49f4c-342a-4a5a-9275-68a77b13534e", "f7dd0fa3-3b5b-4b0b-bb24-6e324faf61fb", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "387f13b1-c20c-40ce-abf4-c6da1dd6597d", "aa3c0ca5-e660-4ee1-9f8b-944563bac519", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "387f13b1-c20c-40ce-abf4-c6da1dd6597d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd49f4c-342a-4a5a-9275-68a77b13534e");

            migrationBuilder.DropColumn(
                name: "ServiceIsCompleted",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e1408c6-34b4-488a-aa18-2ad15e94e6f5", "f371cc0b-6802-4fb7-b96e-6d3ab7e53a04", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd222b73-33df-41a6-b1a2-02cfb01ca0c6", "f787429d-791d-42a1-a7e8-321abf0c4923", "Employee", "EMPLOYEE" });
        }
    }
}
