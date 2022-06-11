using ProEventos.API.Models.DTO;
using System.Threading.Tasks;

namespace ProEventos.API.Models.Contracts
{
    public interface IRepositoryCommandRS<T>
    {
        public Task<T> PostRegistry(T propertiesOfRepository);
        public Task<T> PutRegistry(T propertiesOfRepository);
        public Task<T> PatchRegistry(T propertiesOfRepository);
        public Task<int> DeleteRegistry(int idKeyInRepository);

    }
}
