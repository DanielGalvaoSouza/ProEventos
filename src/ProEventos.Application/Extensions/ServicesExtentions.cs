using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProEventos.Persistence;
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
            services.AddScoped<IRepositoryQueryRS<DTOEvents>, EventsQueryRSContext<DTOEvents>>();
            services.AddSingleton<IRepositoryCommandRS<DTOEvents>, EventsCommandRSContext<DTOEvents>>();
            services.AddScoped<IRepositoryQueryRS<DTOAuditoriums>, AuditoriumsQueryRSContext<DTOAuditoriums>>();
            services.AddSingleton<IRepositoryCommandRS<DTOAuditoriums>, AuditoriumsCommandRSContext<DTOAuditoriums>>();
        }
    }
}
