using Sistemapassagemaerea.Application.DTOs;
namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassageiroService
    {
        Task<IEnumerable<PassageiroDto>> GetAllAsync();
        Task<PassageiroDto> GetByIdAsync(int Id);
        Task AddAsync(CadastrarPassageiroDto passageiro);
        Task Update(CadastrarPassageiroDto passageiro);
        Task Delete(int id);
    }
}
