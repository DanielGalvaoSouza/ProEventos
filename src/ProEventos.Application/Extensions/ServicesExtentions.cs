using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProEventos.Application.Interfaces;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Extensions
{
    public static class ServicesExtentions
    {
        public static void AddDependencyInjections(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddDbContext<AllDataContext>(
            //    context => context.UseSqlite("Data Source=db/ProEventos.db")
            //);

            AllDataContext allDataContext = new AllDataContext(InicializeBase());

            services.AddSingleton(allDataContext);
            services.AddSingleton<IEventService, EventsService>();

            services.AddSingleton<IEventsPersist, EventsPersist>();
            services.AddSingleton<IGeneralPersist, GeneralPersist>();
        }

        public static DbContextOptions InicializeBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AllDataContext>();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=DB/ProEventos.db");
            }

            return optionsBuilder.Options;

        }
    }
}
