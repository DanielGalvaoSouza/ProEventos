using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProEventos.API.Data;
using ProEventos.API.Models.Contracts;
using ProEventos.API.Models.DTO;

namespace ProEventos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DataContext>(
            //    context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            //);
            services.AddControllers();

            services.AddCors();

            //Explicações sobre Container de Injeção de Dependência
            //https://pt.stackoverflow.com/questions/528196/quais-s%C3%A3o-as-diferen%C3%A7as-entre-os-m%C3%A9todos-addtransient-addscoped-e-addsingleton
            services.AddScoped<IRepositoryQueryRS<DTOEvents>, EventsQueryRSContext<DTOEvents>>();
            services.AddSingleton<IRepositoryCommandRS<DTOEvents>, EventsCommandRSContext<DTOEvents>>();
            services.AddScoped<IRepositoryQueryRS<DTOAuditoriums>, AuditoriumsQueryRSContext<DTOAuditoriums>>();
            services.AddSingleton<IRepositoryCommandRS<DTOAuditoriums>, AuditoriumsCommandRSContext<DTOAuditoriums>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });



            //Authentication With JWT Json Web Token
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Authentication With JWT Json Web Token
            app.UseAuthentication();


            app.UseAuthorization();

            //app.UseCors(x => x.WithOrigins("http://localhost:4200")
            //    .AllowAnyMethod()
            //    .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static string GetConnectionStrings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            
            return configuration.GetConnectionString("Default");

        }

    }
}
