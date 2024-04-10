using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class AdminAndClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "763bd550-2cae-468b-a768-83b18c9d9379", "AQAAAAEAACcQAAAAED8TzvlVLy9fZ3LYAjLUWpdc65M8yNxtmgEJzp3qkcl/WByLOZm7GV1F2e4YYbec2Q==", "7aaa5460-3425-490f-b2b8-1c55365e1001" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d84e7c10-e4f5-427d-b36e-8aff305c19be", "AQAAAAEAACcQAAAAEMiHcRONZ8mQP6iHiV04IrfUJrklTTpfo5LyhZrUFv2ElojJJvMtyEw2n3wRaxaQYw==", "c980a31a-5994-4a06-9815-94053dae8d04" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9", 0, "ab00155a-cdc1-4f77-a168-b89efb824cc7", "admin@mail.com", false, "Admin", "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAENJezCBrVkVw7CM8NWYc2dlf1dy6To217S5RR7xaFlMC7xe/u5keHQbcHhyGok7utg==", null, false, "a08131bc-5909-439f-ab27-b7d4f2244ec6", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359321321321", "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8a2956-bae7-4adb-8470-ab52a367b775", "AQAAAAEAACcQAAAAEKG2i4Tu2LWv+oL27bl38elmzKwvbmpJfH72DRO9z+06jr99H1DnvxOtQCgEJPjI1w==", "75941716-8e66-41a8-93f3-a389efeea30a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99a5d0de-c6df-4692-a1be-99d069d96225", "AQAAAAEAACcQAAAAEMeFPXedMm+U0zw0i89X3mOWm+VTv3pKj6qWCAI4QzgLFluVSzU1LpRiv1r0MHZxjQ==", "c9b5ccbd-f9b1-4f8a-bff1-28c3b35284e9" });
        }
    }
}
