using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.Persistence
{
    public class AuditoriumsQueryRSContext<T> : DataContext, IRepositoryQueryRS<T> where T : DTOAuditoriums
    {
        private readonly ILogger<AuditoriumsQueryRSContext<T>> _logger;
        public IEnumerable<T> ListRepositoryOfDTO { get; set; }

        public AuditoriumsQueryRSContext(ILogger<AuditoriumsQueryRSContext<T>> logger)
        {
            _logger = logger;

            this.ListRepositoryOfDTO = base.Auditoriums.Select(s => new DTOAuditoriums()
                {
                    IdAuditorium = s.IdAuditorium,
                    Email = s.Email,
                    LocationAddress = s.LocationAddress,
                    Name = s.Name,
                    Phone = s.Phone,
                    HasBusesToTransportVisitors = s.HasBusesToTransportVisitors,
                    NumberOfSeats = s.NumberOfSeats
                }).Cast<T>();


            _logger.LogInformation("Auditoriums is loaded in Query Responsability Segregations.");

        }

        public static void DataSeedingAuditoriums(ref MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 1, "raimundo_castro@riquefroes.com", "31050-138 - Rua Uarirá - Casa Branca - Belo Horizonte - MG", "Auditório Aline Isabel Marina Fernandes", "(17) 2585-5010", true, "185" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 2, "ayla_aparicio@greenschool.com.br", "30660-260 - Rua Matildes Augusta de Jesus - Diamante (Barreiro) - Belo Horizonte - MG", "Auditório Isabel e Teresinha", "(11) 2902-5720", false, "30" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 3, "ryan.luan.darocha@dyna.com.br", "31540-220 - Rua Conceição dos Ouros - Jardim Leblon - Belo Horizonte - MG", "Auditório Raul e Elias Consultoria", "(11) 2847-1124", true, "70" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 4, "augusto_marcelo_dasneves@iq.unesp.br", "31749-210 - Rua São Cosme - São Damião - Belo Horizonte - MG", "Auditório Igor e Joaquim Limpeza Ltda", "(15) 2806-7338", false, "190" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 5, "isisalanalopes@recatec.com.br", "30512-310 - Beco Better - Cabana do Pai Tomás - Belo Horizonte - MG", "Auditório Benjamin e Theo Informática ME", "(11) 3758-3789", true, "300" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 6, "marli.patricia.lopes@thacconstrutora.com.br", "31620-020 - Rua Noruega - Europa - Belo Horizonte - MG", "Auditório Bryan e Luiza Mudanças ME", "(19) 3986-5717", true, "500" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 7, "bernardovictorbarbosa@lubeka.com.br", "30390-290 - Rua Itaboraí - Pilar - Belo Horizonte - MG", "Auditório Teresinha e Pietro Eletrônica ME", "(11) 2507-0040", true, "240" }
                );

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "IdAuditorium", "Email", "LocationAddress", "Name", "Phone", "HasBusesToTransportVisitors", "NumberOfSeats" },
                values: new object[] { 8, "aline.isabel.fernandes@ssala.com.br", "31255-570 - Rua Sargento Pereira - Santa Rosa - Belo Horizonte - MG", "Auditório Marina e Heloise Esportes ME", "(12) 3984-7469", false, "60" }
                );

        }

    }
}
