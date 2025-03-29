namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface IPassageiroRepository
    {
        Task<IEnumerable<Passageiro>> GetAllAsync();
        Task<Passageiro?> GetByIdAsync(int id);
        Task AddAsync(Passageiro passageiro);
        void Update(Passageiro passageiro);
        void Delete(int id);
    }

}
