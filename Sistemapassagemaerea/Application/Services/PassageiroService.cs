using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Application.Services
{
    public class PassageiroService : IPassageiroService
    {
        private readonly IPassageiroRepository _passageiroRepository;

        public PassageiroService(IPassageiroRepository passageiroRepository)
        {
            _passageiroRepository = passageiroRepository;
        }

        public async Task<IEnumerable<PassageiroDto>> GetAllAsync()
        {
            return await _passageiroRepository.GetAllAsync();
        }

        public async Task<PassageiroDto> GetByIdAsync(int id)
        {
            return await _passageiroRepository.GetByIdAsync(id);
        }

        public async Task<CadastroResponse> AddAsync(CadastrarPassageiroDto passageiro)
        {
            await _passageiroRepository.AddPassageiroAsync(passageiro);
            //SE VIRE MEU AMIGO, AGORA É COM VC
        }

        public async Task UpdatePassageiroAsync(int id, CadastrarPassageiroDto passageiro)
        {
            await _passageiroRepository.Update(passageiro);
        }

        public async Task DeletePassageiroAsync(int id)
        {
            await _passageiroRepository.Delete(id);
        }
    }

}
