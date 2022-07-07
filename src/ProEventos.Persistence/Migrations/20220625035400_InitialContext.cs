using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class InitialContext : Migration
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
                    FlyerPictureFile = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    IdLot = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.IdLot);
                    table.ForeignKey(
                        name: "FK_Lots_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerOfEvents",
                columns: table => new
                {
                    IdSpeakerOfEvent = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SmallCurriculum = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EventsIdEvent = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerOfEvents", x => x.IdSpeakerOfEvent);
                    table.ForeignKey(
                        name: "FK_SpeakerOfEvents_Events_EventsIdEvent",
                        column: x => x.EventsIdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventsAndSpeakerOfEvents",
                columns: table => new
                {
                    SpeakerOfEventId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsAndSpeakerOfEvents", x => new { x.EventId, x.SpeakerOfEventId });
                    table.ForeignKey(
                        name: "FK_EventsAndSpeakerOfEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsAndSpeakerOfEvents_SpeakerOfEvents_SpeakerOfEventId",
                        column: x => x.SpeakerOfEventId,
                        principalTable: "SpeakerOfEvents",
                        principalColumn: "IdSpeakerOfEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: true),
                    SpeakerOfEventId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialMedias_SpeakerOfEvents_SpeakerOfEventId",
                        column: x => x.SpeakerOfEventId,
                        principalTable: "SpeakerOfEvents",
                        principalColumn: "IdSpeakerOfEvent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsAndSpeakerOfEvents_SpeakerOfEventId",
                table: "EventsAndSpeakerOfEvents",
                column: "SpeakerOfEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_EventId",
                table: "Lots",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_EventId",
                table: "SocialMedias",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SpeakerOfEventId",
                table: "SocialMedias",
                column: "SpeakerOfEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerOfEvents_EventsIdEvent",
                table: "SpeakerOfEvents",
                column: "EventsIdEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoriums");

            migrationBuilder.DropTable(
                name: "EventsAndSpeakerOfEvents");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "SpeakerOfEvents");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
