using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditorioController : Controller
    {
        private readonly ILogger<AuditorioController> _logger;
        private readonly IAuditoriosDisplay _auditoriosDisplay;

        public AuditorioController(ILogger<AuditorioController> logger, IAuditoriosDisplay auditoriosDisplay)
        {
            _logger = logger;
            _auditoriosDisplay = auditoriosDisplay;
        }

        [HttpGet]
        public IEnumerable<Auditorios> Get()
        {
            return _auditoriosDisplay.Auditorios;
        }

        [HttpGet("{id}")]
        public Auditorios Get(int id)
        {
            return _auditoriosDisplay.Auditorios.FirstOrDefault(x => x.IdAuditorio == id);
        }




    }
}
