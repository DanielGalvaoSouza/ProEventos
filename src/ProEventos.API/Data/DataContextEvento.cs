using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;
using System.Collections.Generic;

namespace ProEventos.API.Data
{
    public class DataContextEvento : IEventosDisplay
    {
        public List<Evento> Eventos { get; set; }
        private DataContext _dataContext;

        public DataContextEvento()
        {
            _dataContext = new DataContext();
            Eventos = _dataContext.Eventos.ToListAsync().GetAwaiter().GetResult();
            _dataContext.Dispose();
        }

    }
}
