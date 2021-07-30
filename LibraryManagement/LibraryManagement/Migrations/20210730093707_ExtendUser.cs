using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class ExtendUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e55bf5c4-0c26-4991-97df-ae9c5c53ca65");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "13a8ba92-24f2-4c9c-9566-4de93d0687e6", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13a8ba92-24f2-4c9c-9566-4de93d0687e6");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4d94cab-cb5b-4468-a844-71416b7b9f05", "50b2f66f-7cfd-4276-bd78-f21481952112", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "309f50b2-7f02-4e01-b0a2-358c744f5d31", "13e0fd90-1a4f-4c46-91a8-c6f5b09b4fa0", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c4d94cab-cb5b-4468-a844-71416b7b9f05", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "309f50b2-7f02-4e01-b0a2-358c744f5d31");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c4d94cab-cb5b-4468-a844-71416b7b9f05", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d94cab-cb5b-4468-a844-71416b7b9f05");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13a8ba92-24f2-4c9c-9566-4de93d0687e6", "13d28f23-c96e-4fd7-9eee-cfb9999bdc39", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e55bf5c4-0c26-4991-97df-ae9c5c53ca65", "523f236f-f950-41e6-8337-b1e169eb1165", "Member", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "13a8ba92-24f2-4c9c-9566-4de93d0687e6", "a93e1c24-46c2-4219-ae74-9c0dc009316e" });
        }
    }
}
