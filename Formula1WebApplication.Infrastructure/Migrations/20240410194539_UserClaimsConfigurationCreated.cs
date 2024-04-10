using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class UserClaimsConfigurationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 3, "user:fullname", "Organizer Organizerov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 4, "user:fullname", "Guest Guestov", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 5, "user:fullname", "Admin Adminov", "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fe1e6ba-13f5-435b-a146-f756c1e7a274", "AQAAAAEAACcQAAAAEDxVzSY1xUN+8cG1Q81eqjmueqpuAf8MyV8/QM3nnBZBBWXArNjeBTzwFmLcB2DBAA==", "b5197083-eafd-4a58-9fe2-598f974d9f2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dfd3144-5e15-4d45-9318-932e821bac27", "AQAAAAEAACcQAAAAECZwhrL3YvSIQ1+x93yCdvSG/pZhIDCv0SP7OwfWfUmmJ7hFtkzbLIdEiIUwonG2yw==", "8732ecc7-f3fc-4b4a-a278-8f894fd628b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "467fbf77-a911-48c3-9eb5-31b6547a6fa9", "AQAAAAEAACcQAAAAENngDifDGvPTfHzkd53N/Nd97A2vuthxmSmiHSFjkg+C3usm/j5IXSeo6pffypi4iA==", "d56d8b5b-9aed-4e11-b523-3b926035f77c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab00155a-cdc1-4f77-a168-b89efb824cc7", "AQAAAAEAACcQAAAAENJezCBrVkVw7CM8NWYc2dlf1dy6To217S5RR7xaFlMC7xe/u5keHQbcHhyGok7utg==", "a08131bc-5909-439f-ab27-b7d4f2244ec6" });
        }
    }
}
