using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ProEventos.Domain.Entities;
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

namespace ProEventos.Persistence.Contexts
{
    public class AllDataContext : DbContext
    {
        public AllDataContext() : base(InicializeBase()) { 
        
        }

        public static DbContextOptions InicializeBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=ProEventos.db");
            }

            return optionsBuilder.Options;

        }

        #region "DBSet With Domain Data"
        public DbSet<Events> Events { get; set; }
        public DbSet<Auditoriums> Auditoriums { get; set; }
        public DbSet<EventsAndSpeakerOfEvent> EventsAndSpeakerOfEvents { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SpeakerOfEvent> SpeakerOfEvents { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventsAndSpeakerOfEvent>()
                .HasKey(ES => new { ES.EventId, ES.SpeakerOfEventId });
        }

    }
}
