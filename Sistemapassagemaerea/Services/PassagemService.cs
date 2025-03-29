using System.Collections.Generic;
using System.Threading.Tasks;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

namespace Sistemapassagemaerea.Services
{
    public class PassagemService : IPassagemService
    {
        private readonly IPassagemRepository _passagemRepository;

        public PassagemService(IPassagemRepository passagemRepository)
        {
            _passagemRepository = passagemRepository;
        }

        public async Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync()
        {
            return await _passagemRepository.GetAllPassagensAsync();
        }

        public async Task<PassagemAerea> GetPassagemByIdAsync(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            return await _passagemRepository.GetPassagemByIdAsync(cpfPassageiro, codigoCompanhiaAerea);
        }

        public async Task AddPassagemAsync(PassagemAerea passagemAerea)
        {
            // Adicionar validações ou lógica de negócio aqui, se necessário
            await _passagemRepository.AddPassagemAsync(passagemAerea);
        }

        public async Task UpdatePassagemAsync(PassagemAerea passagemAerea)
        {
            // Adicionar validações ou lógica de negócio aqui, se necessário
            await _passagemRepository.UpdatePassagemAsync(passagemAerea);
        }

        public async Task DeletePassagemAsync(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            // Adicionar validações ou lógica de negócio aqui, se necessário
            await _passagemRepository.DeletePassagemAsync(cpfPassageiro, codigoCompanhiaAerea);
        }
    }
}
