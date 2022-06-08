using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;
using System.Collections.Generic;

namespace ProEventos.API.Data
{
    public class DataContextAuditorio : IAuditoriosDisplay
    {
        public List<Auditorios> Auditorios { get; set; }
        private DataContext _dataContext;

        public DataContextAuditorio()
        {
            _dataContext = new DataContext();
            Auditorios = _dataContext.Auditorios.ToListAsync().GetAwaiter().GetResult();
            _dataContext.Dispose();
        }
    }
}
