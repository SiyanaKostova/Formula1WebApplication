using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class EventUserEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsUsers",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Event Id"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUsers", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_EventsUsers_UserId",
                table: "EventsUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b92f906-aa40-4043-a49b-7a65ddf892e7", "AQAAAAEAACcQAAAAED0mHx59AFnV1arO9zVhMXbAAXXDMt4TiVnQBNaIRycqtKYGWrDsFaVGFV1r/uWGeQ==", "18415434-4786-47f5-95c5-5b756cd04d3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99c63f6b-4aba-4b30-8248-f95c9728e0bd", "AQAAAAEAACcQAAAAEHpmU4Gc6xhAxHWpxI4CjVbEOpLEcXegoOWTiVPbsinhobZgX+o4ee+PkFdKE7gqPQ==", "538798fe-4eb1-420d-a732-36c98c59c478" });
        }
    }
}
