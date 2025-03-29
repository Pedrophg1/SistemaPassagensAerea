namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface IPassagemAereaRepository
    {
        Task<IEnumerable<PassagemAerea>> GetAllAsync();
        Task AddAsync(PassagemAerea passagemAerea);
        Task Delete(int id);
    }

}
