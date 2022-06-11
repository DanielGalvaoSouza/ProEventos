using Microsoft.EntityFrameworkCore.Migrations;
using ProEventos.API.Models.DTO;

namespace ProEventos.API.Data.Migrations
{
    public partial class SqliteContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditoriums",
                columns: table => new
                {
                    IdAuditorium = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LocationAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    HasBusesToTransportVisitors = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoriums", x => x.IdAuditorium);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressCity = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfTheEvent = table.Column<string>(type: "TEXT", nullable: true),
                    ThemeOfEvent = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    LotOfEvent = table.Column<string>(type: "TEXT", nullable: true),
                    FlyerPictureFile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            EventsQueryRSContext<DTOEvents>.DataSeedingEvents(ref migrationBuilder);
            AuditoriumsQueryRSContext<DTOAuditoriums>.DataSeedingAuditoriums(ref migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoriums");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
