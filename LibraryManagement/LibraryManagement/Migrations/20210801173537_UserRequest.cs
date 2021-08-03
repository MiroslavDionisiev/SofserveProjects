using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class UserRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c359ddcb-6c5f-4fd8-b9e6-32e6cd1f6065");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d8356b6-d169-4160-b4f4-f9bd8c961cee", "0256b097-f4b3-440d-9745-b3e88419a38c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d8356b6-d169-4160-b4f4-f9bd8c961cee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0256b097-f4b3-440d-9745-b3e88419a38c");

            migrationBuilder.CreateTable(
                name: "DeadlineRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowedId = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_DeadlineRequests_BorrowedBooks_BorrowedId",
                        column: x => x.BorrowedId,
                        principalTable: "BorrowedBooks",
                        principalColumn: "BorrowedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d28f0db-3727-4f9e-9d50-02637135fd68", "dcca12ad-528c-4875-90bd-005cd31080b8", "Admin", "ADMIN" },
                    { "80faa66b-c383-49c2-b0b0-fde62e668e3c", "be08d710-e5b0-4be6-bf5c-d4579eb65aba", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "841cb2c8-9771-4e3b-bfce-485e9e834a71", 0, "7ad70284-cf19-4a50-93b8-bb39e3b0a6f4", "admin@email.com", true, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAENLi4NvFKrEMMr7Ng/oR2mbvnM5HrVBI8Q+w7Of8lzMo626evxgFZG4znMK3L/MDKw==", null, false, "", false, "admin@email.com" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "Language" },
                values: new object[] { 0, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d28f0db-3727-4f9e-9d50-02637135fd68", "841cb2c8-9771-4e3b-bfce-485e9e834a71" });

            migrationBuilder.CreateIndex(
                name: "IX_DeadlineRequests_BorrowedId",
                table: "DeadlineRequests",
                column: "BorrowedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeadlineRequests");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d8356b6-d169-4160-b4f4-f9bd8c961cee", "0be1ff8a-cca9-45ba-883c-e7a11a1b5df1", "Admin", "ADMIN" },
                    { "c359ddcb-6c5f-4fd8-b9e6-32e6cd1f6065", "dd19f97c-31d1-45f8-bb47-05e0874154c2", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0256b097-f4b3-440d-9745-b3e88419a38c", 0, "6220120b-ceec-44d0-96ef-f7cd3edafb52", "admin@email.com", true, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAENAbcWIqAEN0qCk4XEZsq7pE9KA4M6u5GZuX5pzwGBCpIrmBqjIgjxS/qGsR+WcTuA==", null, false, "", false, "admin@email.com" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "Language" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d8356b6-d169-4160-b4f4-f9bd8c961cee", "0256b097-f4b3-440d-9745-b3e88419a38c" });
        }
    }
}
