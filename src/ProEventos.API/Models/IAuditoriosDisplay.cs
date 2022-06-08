using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProEventos.API.Models
{
    public interface IAuditoriosDisplay
    {
        public List<Auditorios> Auditorios { get; set; }
    }
}
