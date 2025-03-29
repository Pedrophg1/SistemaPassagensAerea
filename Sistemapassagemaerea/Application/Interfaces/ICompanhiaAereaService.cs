using Sistemapassagemaerea.Application.DTOs;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface ICompanhiaAereaService
    {
        Task<IEnumerable<CompanhiaAereaDto>> GetAllAsync();
        Task<CompanhiaAereaDto> GetByIdAsync(int id);
        Task<CadastroResponse> AddAsync(CadastrarCompanhiaAereaDto companhia);
        Task Update(int id, CadastrarCompanhiaAereaDto companhia);
        Task DeleteAsync(int id);
    }
}
