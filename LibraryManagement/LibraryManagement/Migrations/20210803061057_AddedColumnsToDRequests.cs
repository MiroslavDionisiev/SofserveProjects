using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class AddedColumnsToDRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80faa66b-c383-49c2-b0b0-fde62e668e3c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d28f0db-3727-4f9e-9d50-02637135fd68", "841cb2c8-9771-4e3b-bfce-485e9e834a71" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d28f0db-3727-4f9e-9d50-02637135fd68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "841cb2c8-9771-4e3b-bfce-485e9e834a71");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DeadlineRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6104ffbe-ded2-4990-9411-bf33ce5d81ab", "b0ed9343-1d40-43ad-a210-4e832fb56dfe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66573a59-f718-4a2e-830a-1c0e0a821f42", "2e05213e-6584-463d-8789-892970c84bb4", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7112c772-e971-4da8-b430-cfea624ac06e", 0, "3f2e05ee-c65c-4761-8325-7b287e08d859", "admin@email.com", true, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEJs6CyjEk+BdBP78uVxCnB7lBr0GsJua0/65sRJb/hXak6yk0NOfkPH6ik7qMDPiVQ==", null, false, "", false, "admin@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6104ffbe-ded2-4990-9411-bf33ce5d81ab", "7112c772-e971-4da8-b430-cfea624ac06e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66573a59-f718-4a2e-830a-1c0e0a821f42");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6104ffbe-ded2-4990-9411-bf33ce5d81ab", "7112c772-e971-4da8-b430-cfea624ac06e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6104ffbe-ded2-4990-9411-bf33ce5d81ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7112c772-e971-4da8-b430-cfea624ac06e");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DeadlineRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d28f0db-3727-4f9e-9d50-02637135fd68", "dcca12ad-528c-4875-90bd-005cd31080b8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80faa66b-c383-49c2-b0b0-fde62e668e3c", "be08d710-e5b0-4be6-bf5c-d4579eb65aba", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "841cb2c8-9771-4e3b-bfce-485e9e834a71", 0, "7ad70284-cf19-4a50-93b8-bb39e3b0a6f4", "admin@email.com", true, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAENLi4NvFKrEMMr7Ng/oR2mbvnM5HrVBI8Q+w7Of8lzMo626evxgFZG4znMK3L/MDKw==", null, false, "", false, "admin@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d28f0db-3727-4f9e-9d50-02637135fd68", "841cb2c8-9771-4e3b-bfce-485e9e834a71" });
        }
    }
}
