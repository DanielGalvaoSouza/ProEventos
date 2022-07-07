using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventsCommandRSContext<T> : DataContext, IRepositoryCommandRS<T> where T : DTOEvents
    {
        private readonly ILogger<EventsCommandRSContext<T>> _logger;

        public EventsCommandRSContext(ILogger<EventsCommandRSContext<T>> logger)
        {
            _logger = logger;
        }

        public async Task<T> PostRegistry(T propertiesOfevent)
        {
            var transaction = await base.Database.BeginTransactionAsync();
            var entityGenerated = new object();

            try
            {
                base.Events.Add(new Events(default,
                    propertiesOfevent.AddressCity,
                    propertiesOfevent.DateOfTheEvent,
                    propertiesOfevent.ThemeOfEvent,
                    propertiesOfevent.NumberOfPeople,
                    propertiesOfevent.LotOfEvent,
                    propertiesOfevent.FlyerPictureFile));

                await base.SaveChangesAsync();
                
                await transaction.CommitAsync();

                propertiesOfevent = ToThisClass<T>
                    .CastThisClass<Events>(base.Events.OrderBy(o => o.IdEvent).LastOrDefault());

            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, ex.Message);
                throw new ArgumentException(ex.Message);
            }

            return propertiesOfevent;

        }

        public async Task<T> PutRegistry(T propertiesEvent)
        {
            var transaction = await base.Database.BeginTransactionAsync();

            try
            {
                var eventItem = new Events(propertiesEvent.IdEvent,
                    propertiesEvent.AddressCity,
                    propertiesEvent.DateOfTheEvent,
                    propertiesEvent.ThemeOfEvent,
                    propertiesEvent.NumberOfPeople,
                    propertiesEvent.LotOfEvent,
                    propertiesEvent.FlyerPictureFile);

                base.Entry(eventItem).State = EntityState.Modified;
                await base.SaveChangesAsync();

                await transaction.CommitAsync();

                propertiesEvent = ToThisClass<T>
                    .CastThisClass<Events>(base.Events.FirstOrDefault(f => f.IdEvent == propertiesEvent.IdEvent));

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, ex.Message);
            }

            return propertiesEvent;

        }

        public async Task<T> PatchRegistry(T propertiesEvent)
        {
            var transaction = base.Database.BeginTransaction();

            try
            {
                var eventItem = base.Events.FirstOrDefault(f => f.IdEvent == propertiesEvent.IdEvent);

                eventItem.EditEvent(propertiesEvent.IdEvent,
                    propertiesEvent.AddressCity,
                    propertiesEvent.DateOfTheEvent,
                    propertiesEvent.ThemeOfEvent,
                    propertiesEvent.NumberOfPeople,
                    propertiesEvent.LotOfEvent,
                    propertiesEvent.FlyerPictureFile,
                    eventItem);

                base.Entry(eventItem).State = EntityState.Modified;
                await base.SaveChangesAsync();

                await transaction.CommitAsync();

                propertiesEvent = ToThisClass<T>
                    .CastThisClass<Events>(base.Events.FirstOrDefault(f => f.IdEvent == propertiesEvent.IdEvent));

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, ex.Message);
            }

            return propertiesEvent;

        }

        public async Task<int> DeleteRegistry(int idEvent)
        {
            var transaction = base.Database.BeginTransaction();
            int NumberOfChanges = default;

            try
            {
                var eventItem = base.Events.FirstOrDefault(f => f.IdEvent == idEvent);
                base.Events.Remove(eventItem);

                NumberOfChanges = await base.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, ex.Message);
            }

            return NumberOfChanges;

        }

    }
}
