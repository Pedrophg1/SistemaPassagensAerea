using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassagemAereaService
    {
       
        Task<IEnumerable<PassagemAereaDto>> GetAllPassagensAsync();

        Task<PassagemAereaDto> GetByIdAsync(int id);
     
        Task<CadastroResponse> AddPassagemAereaAsync(PassagemAereaDto passagemAerea);
        Task UpdatePassagemAereaAsync(int id, PassagemAereaDto passagemAerea);

        Task DeletePassagemAereaAsync(int id);
    }
}
