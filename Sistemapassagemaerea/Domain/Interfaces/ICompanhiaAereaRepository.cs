namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface ICompanhiaAereaRepository
    {
        Task<IEnumerable<CompanhiaAerea>> GetAllAsync();
        Task<CompanhiaAerea?> GetByIdAsync(int id);
        Task AddAsync(CompanhiaAerea companhia);
        void Update(CompanhiaAerea companhia);
        void Delete(CompanhiaAerea companhia);
    }

}
