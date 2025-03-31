using Sistemapassagemaerea.Application.DTOs;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassagemAereaService
    {

        Task<IEnumerable<PassagemAereaDto>> GetAllPassagensAsync();

        Task<PassagemAereaDto> GetByIdAsync(int id);

        Task<CadastroResponse> AddPassagemAereaAsync(CadastrarPassagemAereaDto passagemAerea);
        Task UpdatePassagemAereaAsync(int id, CadastrarPassagemAereaDto passagemAerea);

        Task DeletePassagemAereaAsync(int id);
    }
}
