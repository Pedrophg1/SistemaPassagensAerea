using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface IPassagemAereaRepository
    {
        Task<IEnumerable<PassagemAerea>> GetAllAsync();
        Task<PassagemAerea?> GetByIdAsync(int id);
        Task AddAsync(PassagemAerea passagemAerea);

        void Delete(PassagemAerea passagemAerea);
        void Update(PassagemAerea passagemAerea);
    }
}
