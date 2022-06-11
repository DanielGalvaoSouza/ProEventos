using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.API.Models.Contracts
{
    //por convenção os nomes de interface são escritos em PascalCase.
    //https://docs.microsoft.com/pt-br/dotnet/csharp/fundamentals/coding-style/coding-conventions
    public interface IRepositoryQueryRS<T>
    {
        IEnumerable<T> ListRepositoryOfDTO { get; set; }
    }
}
