using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class SeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "337e994a-6838-4fef-9aa3-92ccdb8893ce", "7b0e4e5e-d031-4b87-a5c5-295dd0ec7259", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bf860d8-7763-4f94-9437-20763a3c0601", "dab033cc-96cb-4fd7-93d3-b70c345be1b7", "Member", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "337e994a-6838-4fef-9aa3-92ccdb8893ce", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf860d8-7763-4f94-9437-20763a3c0601");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "337e994a-6838-4fef-9aa3-92ccdb8893ce", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "337e994a-6838-4fef-9aa3-92ccdb8893ce");
        }
    }
}
