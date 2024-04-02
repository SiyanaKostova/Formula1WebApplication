using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class RaceAndEventUserIdNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Races",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User Id");

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
        }
    }
}
