using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class ImagePathsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a05f26-1182-43d6-807e-a4fb33ae5be3", "AQAAAAEAACcQAAAAEKXoTjkZFBgKvdf++g3SbII3RZ6cd4+AsU40gqI0SfInDLnj2b+0+fEOHO5vC/7SWA==", "fdb12c04-7cd0-456c-bdf5-3e06ddb93aa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70ed012d-ebe4-4014-b090-de7c691f3bc2", "AQAAAAEAACcQAAAAEOh2YNZzXnIb7vPs+BOxOYs9pzwVvooXHEMQ/jzVtjoSbRD8Q1r5Sw11BTLZRLvSUw==", "e289454a-f3d5-46b8-b3ea-f4248c51e135" });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/pilots/maxverstappen.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "/images/pilots/charlesleclerc.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "/images/pilots/sergioperez.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "/images/pilots/carlossainz.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "/images/pilots/oscarpiastri.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "/images/pilots/landonorris.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "/images/pilots/georgerussel.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "/images/pilots/fernandoalonso.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "/images/pilots/lancestroll.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "/images/pilots/lewishamilton.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "/images/pilots/yukitsunoda.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "/images/pilots/nicohulkenberg.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagePath",
                value: "/images/pilots/kevinmagnussen.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImagePath",
                value: "/images/pilots/alexalbon.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImagePath",
                value: "/images/pilots/guanyuzhou.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImagePath",
                value: "/images/pilots/danielricciardo.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImagePath",
                value: "/images/pilots/estebanocon.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImagePath",
                value: "/images/pilots/pierregasly.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImagePath",
                value: "/images/pilots/valtteribottas.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImagePath",
                value: "/images/pilots/logansargeant.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2daa778-2223-43c3-b7bc-eacf8c008b59", "AQAAAAEAACcQAAAAEAh3NH09bw4bqJYSKJ8QL2bpvA4yoADG6fElzg59g/vprRjEMS52YfeLEhCvbsWUuA==", "c4391048-353f-4129-aa19-fcf8551b2ec9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ecf8983-890a-42af-aa3f-1adb99a4b68b", "AQAAAAEAACcQAAAAELhYFf97FnRnDubWxvTwtd2A19oO19HKuFY/DH8Fvoy/1Nt48OBwMTIDHPffA9bHHw==", "1636cf4c-82ff-4c1e-80f8-ebdcd65239c8" });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\maxverstappen.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\charlesleclerc.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\sergioperez.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\carlossainz.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\oscarpiastri.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\landonorris.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\georgerussel.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\fernandoalonso.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\lancestroll.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\lewishamilton.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\yukitsunoda.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\nicohulkenberg.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\kevinmagnussen.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\alexalbon.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\guanyuzhou.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\danielricciardo.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\estebanocon.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\pierregasly.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\valtteribottas.png");

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImagePath",
                value: "\\wwwroot\\images\\pilots\\logansargeant.png");
        }
    }
}
