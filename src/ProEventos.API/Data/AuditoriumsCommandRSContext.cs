using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models.Contracts;
using System;
using System.Linq;
using ProEventos.API.Models.DTO;
using ProEventos.API.Models;
using System.Threading.Tasks;

namespace ProEventos.API.Data
{
    public class AuditoriumsCommandRSContext<T> : DataContext, IRepositoryCommandRS<T> where T : DTOAuditoriums
    {
        private readonly ILogger<AuditoriumsCommandRSContext<T>> _logger;
        
        public AuditoriumsCommandRSContext(ILogger<AuditoriumsCommandRSContext<T>> logger) 
        {
            _logger = logger;
        }

        public async Task<T> PostRegistry(T propertiesOfAuditoriums)
        {
            var transaction = await base.Database.BeginTransactionAsync();

            try
            {
                base.Auditoriums.Add(new Auditoriums(Convert.ToInt32(propertiesOfAuditoriums.IdAuditorium),
                    propertiesOfAuditoriums.Name,
                    propertiesOfAuditoriums.LocationAddress,
                    propertiesOfAuditoriums.Phone,
                    propertiesOfAuditoriums.Email,
                    Convert.ToInt32(propertiesOfAuditoriums.NumberOfSeats),
                    Convert.ToBoolean(propertiesOfAuditoriums.HasBusesToTransportVisitors)));

                await base.SaveChangesAsync();

                await transaction.CommitAsync();
                
                propertiesOfAuditoriums = ToThisClass<T>
                    .CastThisClass<Auditoriums>(base.Auditoriums.OrderBy(o => o.IdAuditorium).LastOrDefault());

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, ex.Message);
            }
            
            return propertiesOfAuditoriums;

        }

        public async Task<T> PutRegistry(T propertiesOfAuditoriums)
        {
            var transaction = await base.Database.BeginTransactionAsync();

            try
            {
                var auditorium = new Auditoriums(Convert.ToInt32(propertiesOfAuditoriums.IdAuditorium),
                    propertiesOfAuditoriums.Name,
                    propertiesOfAuditoriums.LocationAddress,
                    propertiesOfAuditoriums.Phone,
                    propertiesOfAuditoriums.Email,
                    Convert.ToInt32(propertiesOfAuditoriums.NumberOfSeats),
                    Convert.ToBoolean(propertiesOfAuditoriums.HasBusesToTransportVisitors));
                
                base.Entry(auditorium).State = EntityState.Modified;
                
                await base.SaveChangesAsync();

                await transaction.CommitAsync();

                propertiesOfAuditoriums = ToThisClass<T>
                    .CastThisClass<DTOAuditoriums>(base.Auditoriums.FirstOrDefault(f => f.IdAuditorium == propertiesOfAuditoriums.IdAuditorium));

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, ex.Message);
            }
            
            return propertiesOfAuditoriums;

        }

        public async Task<T> PatchRegistry(T propertiesOfAuditoriums)
        {
            var transaction = await base.Database.BeginTransactionAsync();

            try
            {
                var auditorium = base.Auditoriums.FirstOrDefault(f => f.IdAuditorium == propertiesOfAuditoriums.IdAuditorium);

                auditorium.EditAuditorium(Convert.ToInt32(propertiesOfAuditoriums.IdAuditorium),
                    propertiesOfAuditoriums.Name,
                    propertiesOfAuditoriums.LocationAddress,
                    propertiesOfAuditoriums.Phone,
                    propertiesOfAuditoriums.Email,
                    Convert.ToInt32(propertiesOfAuditoriums.NumberOfSeats),
                    Convert.ToBoolean(propertiesOfAuditoriums.HasBusesToTransportVisitors),
                    auditorium);

                base.Entry(auditorium).State = EntityState.Modified;
                
                await base.SaveChangesAsync();

                await transaction.CommitAsync();

                propertiesOfAuditoriums = ToThisClass<T>
                    .CastThisClass<Auditoriums>(base.Auditoriums.FirstOrDefault(f => f.IdAuditorium == propertiesOfAuditoriums.IdAuditorium));

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, ex.Message);
            }

            return propertiesOfAuditoriums;

        }

        public async Task<int> DeleteRegistry(int idAuditorium)
        {
            int NumberOfChanges = default;

            try
            {
                var auditorium = base.Auditoriums.FirstOrDefault(f => f.IdAuditorium == idAuditorium);
                base.Auditoriums.Remove(auditorium);
                NumberOfChanges = await base.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return NumberOfChanges;

        }

    }
}
