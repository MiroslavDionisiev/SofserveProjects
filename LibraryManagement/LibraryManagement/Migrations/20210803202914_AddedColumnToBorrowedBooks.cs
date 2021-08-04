using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class AddedColumnToBorrowedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BorrowedBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fa74221-5dcf-48a9-b5a0-cb31a79e1d57", "f41ff473-4a23-45ee-a4b2-480943442bb4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80f635ef-f083-4969-baa0-feec2e1d23da", "9f2cb1a6-fd8a-4805-8a7e-0534c09542be", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d4bff86-38b5-4416-8e87-f9583bfb4fcd", 0, "b96aa3e9-9ff7-42ea-bb6a-07f4c4e47802", "admin@email.com", true, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEE0iRYiPBoe2NY/nPjS7OdhrIp8XVmgMQ+9LNMH366/aStesx7t7dc4fJKl6VIChCQ==", null, false, "", false, "admin@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5fa74221-5dcf-48a9-b5a0-cb31a79e1d57", "5d4bff86-38b5-4416-8e87-f9583bfb4fcd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f635ef-f083-4969-baa0-feec2e1d23da");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5fa74221-5dcf-48a9-b5a0-cb31a79e1d57", "5d4bff86-38b5-4416-8e87-f9583bfb4fcd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fa74221-5dcf-48a9-b5a0-cb31a79e1d57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4bff86-38b5-4416-8e87-f9583bfb4fcd");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BorrowedBooks");

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
    }
}
