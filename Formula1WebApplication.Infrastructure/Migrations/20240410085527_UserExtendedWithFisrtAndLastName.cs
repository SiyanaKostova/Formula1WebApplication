using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class UserExtendedWithFisrtAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8a2956-bae7-4adb-8470-ab52a367b775", "Guest", "Guestov", "AQAAAAEAACcQAAAAEKG2i4Tu2LWv+oL27bl38elmzKwvbmpJfH72DRO9z+06jr99H1DnvxOtQCgEJPjI1w==", "75941716-8e66-41a8-93f3-a389efeea30a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99a5d0de-c6df-4692-a1be-99d069d96225", "Organizer", "Organizerov", "AQAAAAEAACcQAAAAEMeFPXedMm+U0zw0i89X3mOWm+VTv3pKj6qWCAI4QzgLFluVSzU1LpRiv1r0MHZxjQ==", "c9b5ccbd-f9b1-4f8a-bff1-28c3b35284e9" });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c2fd08c-7990-467a-9e48-50c91a6d35ab", "AQAAAAEAACcQAAAAELTbkMxSsHZhTQFX9nPHxJWlM2YyDa9QWoKyE60hOPqM8EFm3KTLk8AUVcSyCN514w==", "94070f4c-857d-4331-ad49-8ff609de5187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "205fa96b-c0fe-47c7-8b15-0084333017a0", "AQAAAAEAACcQAAAAEA70pHRt/XynjMhxBztOyq+xJjHibXcOuHVTk4N4McagXUwKwIkq39kR2bHFLSYFnQ==", "83c3bba6-b5bb-4cc3-a5b1-14550660158a" });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId");
        }
    }
}
