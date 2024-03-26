using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class DomainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for organizer")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Contact phone number for organizer"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Organizer User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for pilot")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pilot's first name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pilot's last name"),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pilot's nationality"),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the team the pilot is associated with"),
                    Biography = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Short biography of the pilot"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Path to the pilot's image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for event")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the event"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Detailed description of the event"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "URL to an image representing the event"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The location where the event is held"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time of the event"),
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "Event Organizer Id"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for news article")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The title of the article"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Detailed description or content of the article"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "URL to an image related to the news article"),
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "News Article Organizer Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsArticles_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for race")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the race"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The location where the race is held"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time of the race"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "URL to an image representing the race"),
                    Laps = table.Column<int>(type: "int", nullable: false, comment: "The number of laps in the race"),
                    CircuitInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Information about the race circuit"),
                    OrganizerId = table.Column<int>(type: "int", nullable: false, comment: "Race Organizer Id"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticles_OrganizerId",
                table: "NewsArticles",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_OrganizerId",
                table: "Races",
                column: "OrganizerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "NewsArticles");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Organizers");
        }
    }
}
