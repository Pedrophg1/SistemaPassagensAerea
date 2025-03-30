using Sistemapassagemaerea.Application.DTOs;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassageiroService
    {
        Task<IEnumerable<PassageiroDto>> GetAllAsync();
        Task<PassageiroDto> GetByIdAsync(int id);
        Task<CadastroResponse> AddAsync(CadastrarPassageiroDto passageiro);
        Task UpdatePassageiroAsync(int id, CadastrarPassageiroDto passageiro);
        Task DeletePassageiroAsync(int id);
       
    }
}
