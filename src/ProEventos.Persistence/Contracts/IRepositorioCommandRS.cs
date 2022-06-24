using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface IRepositoryCommandRS<T>
    {
        public Task<T> PostRegistry(T propertiesOfRepository);
        public Task<T> PutRegistry(T propertiesOfRepository);
        public Task<T> PatchRegistry(T propertiesOfRepository);
        public Task<int> DeleteRegistry(int idKeyInRepository);

    }
}
