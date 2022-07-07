using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contexts
{
    public class EventsPersist : IEventsPersist
    {
        private readonly AllDataContext _dataContext;

        public EventsPersist(AllDataContext dataContext)
        {
            this._dataContext = dataContext;
            //COMO ESTA CLASSE CONTÉM SOMENTE RESGATE DE INFORMAÇÃO
            //this._dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Events> GetEventByIdAsync(int IdEvent, bool includeSpeakerOfEvents = false)
        {
            IQueryable<Events> query = _dataContext.Events
                .Include( e => e.Lots)
                .Include( s => s.SocialMedias);

            if(includeSpeakerOfEvents)
            {
                query = query.Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(se => se.SpeakerOfEvent);
            }

            return await query.AsNoTracking()
                .FirstOrDefaultAsync(f => f.IdEvent == IdEvent);

        }

        public async Task<Events[]> GetAllEventsAsync(bool includeSpeakerOfEvents = false)
        {
            IQueryable<Events> query = _dataContext.Events
                .Include(e => e.Lots)
                .Include(s => s.SocialMedias);

            if (includeSpeakerOfEvents)
            {
                query = query.Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(se => se.SpeakerOfEvent);
            }

            return await query.AsNoTracking().ToArrayAsync();

        }

        public async Task<Events[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakerOfEvents = false)
        {
            IQueryable<Events> query = _dataContext.Events
                .Include(e => e.Lots)
                .Include(s => s.SocialMedias);

            if (includeSpeakerOfEvents)
            {
                query = query.Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(se => se.SpeakerOfEvent);
            }

            query = query.OrderBy(o => o.IdEvent)
                .Where(e => e.ThemeOfEvent.ToLower().Contains(theme.ToLower())).AsNoTracking();

            return await query.ToArrayAsync();
        }

    }
}
