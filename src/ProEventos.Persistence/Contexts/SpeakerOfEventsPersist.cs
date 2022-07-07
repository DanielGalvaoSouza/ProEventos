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
    public class SpeakerOfEventsPersist : ISpeakerOfEventPersist
    {
        private readonly AllDataContext _dataContext;

        public SpeakerOfEventsPersist(AllDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<SpeakerOfEvent[]> GetAllSpeakerOfEventsByNameAsync(string Name, bool includeEvents = false)
        {
            IQueryable<SpeakerOfEvent> query = _dataContext.SpeakerOfEvents
                .Include(e => e.SocialMedias);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(s => s.Event);
            }

            query = query.OrderBy(o => o.IdSpeakerOfEvent)
                .Where(w => w.Name.ToLower().Contains(Name.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<SpeakerOfEvent> GetAllSpeakerOfEventByIdAsync(int IdSpeakerOfEvent, bool includeEvents = false)
        {
            IQueryable<SpeakerOfEvent> query = _dataContext.SpeakerOfEvents
                .Include(e => e.SocialMedias);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(s => s.Event);
            }

            query = query.OrderBy(o => o.IdSpeakerOfEvent);

            return await query.FirstOrDefaultAsync(f => f.IdSpeakerOfEvent == IdSpeakerOfEvent);

        }

        public async Task<SpeakerOfEvent[]> GetAllSpeakerOfEvents(bool includeEvents = false)
        {
            IQueryable<SpeakerOfEvent> query = _dataContext.SpeakerOfEvents
                .Include(e => e.SocialMedias);

            if (includeEvents)
            {
                query = query
                    .Include(s => s.EventsAndSpeakerOfEvents)
                    .ThenInclude(s => s.Event);
            }

            query = query.OrderBy(o => o.IdSpeakerOfEvent);

            return await query.ToArrayAsync();

        }

    }
}
