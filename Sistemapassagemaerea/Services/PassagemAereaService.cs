using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

namespace Sistemapassagemaerea.Services
{
    public class PassagemAereaService : IPassagemAereaService
    {
        private readonly IPassagemAereaRepository _passagemAereaRepository;

        public PassagemAereaService(IPassagemAereaRepository passagemAereaRepository)
        {
            _passagemAereaRepository = passagemAereaRepository;
        }

        public async Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync()
        {
            return await _passagemAereaRepository.GetAllPassagensAsync();
        }

        public async Task AddPassagemAereaAsync(PassagemAerea passagemAerea)
        {
            await _passagemAereaRepository.AddPassagemAereaAsync(passagemAerea);
        }

        public async Task DeletePassagemAereaAsync(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            await _passagemAereaRepository.DeletePassagemAereaAsync(cpfPassageiro, codigoCompanhiaAerea);
        }
    }

}
