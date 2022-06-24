using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventsQueryRSContext<T> : DataContext, IRepositoryQueryRS<T> where T : DTOEvents
    {
        private readonly ILogger<EventsQueryRSContext<T>> _logger;
        public IEnumerable<T> ListRepositoryOfDTO { get; set; }
        
        public EventsQueryRSContext(ILogger<EventsQueryRSContext<T>> logger)
        {
            _logger = logger;

            ListRepositoryOfDTO = base.Events.Select(s => new DTOEvents 
                {
                    IdEvent = s.IdEvent,
                    AddressCity = s.AddressCity,
                    DateOfTheEvent = s.DateOfTheEvent,
                    ThemeOfEvent = s.ThemeOfEvent,
                    NumberOfPeople = s.NumberOfPeople,
                    LotOfEvent = s.LotOfEvent,
                    FlyerPictureFile = s.FlyerPictureFile
                }).Cast<T>();

            _logger.LogInformation("Events is loaded in Query Responsability Segregations.");
        }

        public static void DataSeedingEvents(ref MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 1, "Belo Horizonte", "09/08/2022", "Angular e EF 5.0.17 Migrations o Desafio da Atualidade", 160, "2º Lote", "foto.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 2, "Contagem", "07/6/2022", "Personalização de migração manual", 72, "1º lote", "foto1.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 3, "Sete Lagoas", "09/06/2022", "Lógica de inicialização personalizada", 60, "10º lote", "foto2.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 4, "Ouro Preto", "20/07/2022", "Limitações dos dados de semente do modelo", 80, "15º lote", "foto3.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 5, "Nova Lima", "21/07/2022", "Tipos de entidade com construtores", 100, "17º lote", "foto4.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 6, "Três Marias", "22/07/2022", "Associação a Propriedades mapeadas", 160, "19º lote", "foto5.png" }
                );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "AddressCity", "DateOfTheEvent", "ThemeOfEvent", "NumberOfPeople", "LotOfEvent", "FlyerPictureFile" },
                values: new object[] { 7, "Pedro Leopoldo", "09/07/2022", "Propriedades somente leitura", 150, "13º lote", "foto6.png" }
                );

        }

    }

}
