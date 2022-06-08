using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ProEventos.API.Models;
using System.IO;

/*
 A partir do .NET Core 3.0 o Entity Framework não é mais parte do framework .NET e ele passa a ser um componente.
As versão para este exemplo funcionar são:
Orientações sobre instalação seria: https://docs.microsoft.com/pt-br/ef/core/cli/dotnet
Microsoft.EntitityFrameworkCore
Microsoft.EntitityFrameworkCore.Design
Microsoft.EntitityFrameworkCore.Tools

Microsoft.EntitityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore -v 5.0.17
dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.17
dotnet add package Microsoft.EntitityFrameworkCore.Tools -v 5.0.17

 */

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base(Inicialize()){}

        #region "Set Context Options"
        
        public static DbContextOptions<DataContext> Inicialize()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlite(connectionString);

            }
            
            return optionsBuilder.Options;

        }

        #endregion

        #region "DBSet With Domain Data"
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Auditorios> Auditorios { get; set; }
        #endregion

        #region "First Data To DB"

        public static void DataSeeding(ref MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 1, "Belo Horizonte", "09/08/2022", "Angular e EF 5.0.17 Migrations o Desafio da Atualidade", 160, "2º Lote", "foto.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 2, "Contagem", "07/6/2022", "Personalização de migração manual", 72, "1º lote", "foto1.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 3, "Sete Lagoas", "09/06/2022", "Lógica de inicialização personalizada", 60, "10º lote", "foto2.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 4, "Ouro Preto", "20/07/2022", "Limitações dos dados de semente do modelo", 80, "15º lote", "foto3.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 5, "Nova Lima", "21/07/2022", "Tipos de entidade com construtores", 100, "17º lote", "foto4.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 6, "Três Marias", "22/07/2022", "Associação a Propriedades mapeadas", 160, "19º lote", "foto5.png" }
                );

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "EventoId", "Local", "DataEvento", "Tema", "QtdPessoas", "Lote", "ImagemURL" },
                values: new object[] { 7, "Pedro Leopoldo", "09/07/2022", "Propriedades somente leitura", 150, "13º lote", "foto6.png" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { "raimundo_castro@riquefroes.com", "31050-138 - Rua Uarirá - Casa Branca - Belo Horizonte - MG", "Auditório Aline Isabel Marina Fernandes", "(17) 2585-5010", true, "185" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 2, "ayla_aparicio@greenschool.com.br", "30660-260 - Rua Matildes Augusta de Jesus - Diamante (Barreiro) - Belo Horizonte - MG", "Auditório Isabel e Teresinha", "(11) 2902-5720", false, "30" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 3, "ryan.luan.darocha@dyna.com.br", "31540-220 - Rua Conceição dos Ouros - Jardim Leblon - Belo Horizonte - MG", "Auditório Raul e Elias Consultoria", "(11) 2847-1124", true, "70" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 4, "augusto_marcelo_dasneves@iq.unesp.br", "31749-210 - Rua São Cosme - São Damião - Belo Horizonte - MG", "Auditório Igor e Joaquim Limpeza Ltda", "(15) 2806-7338", false, "190" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 5, "isisalanalopes@recatec.com.br", "30512-310 - Beco Better - Cabana do Pai Tomás - Belo Horizonte - MG", "Auditório Benjamin e Theo Informática ME", "(11) 3758-3789", true, "300" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 6, "marli.patricia.lopes@thacconstrutora.com.br", "31620-020 - Rua Noruega - Europa - Belo Horizonte - MG", "Auditório Bryan e Luiza Mudanças ME", "(19) 3986-5717", true, "500" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 7, "bernardovictorbarbosa@lubeka.com.br", "30390-290 - Rua Itaboraí - Pilar - Belo Horizonte - MG", "Auditório Teresinha e Pietro Eletrônica ME", "(11) 2507-0040", true, "240" }
                );

            migrationBuilder.InsertData(
                table: "auditorios",
                columns: new[] { "IdAuditorio", "Email", "Logradouro", "Nome", "Telefone", "possuiOnibusParaTransporte", "qdtAssentos" },
                values: new object[] { 8, "aline.isabel.fernandes@ssala.com.br", "31255-570 - Rua Sargento Pereira - Santa Rosa - Belo Horizonte - MG", "Auditório Marina e Heloise Esportes ME", "(12) 3984-7469", false, "60" }
                );
        }
        #endregion


    }
}
