using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProEventos.API.Models
{
    //por convenção os nomes de interface são escritos em PascalCase.
    //https://docs.microsoft.com/pt-br/dotnet/csharp/fundamentals/coding-style/coding-conventions
    public interface IEventosDisplay
    {
        List<Evento> Eventos { get; set; }
    }
}
