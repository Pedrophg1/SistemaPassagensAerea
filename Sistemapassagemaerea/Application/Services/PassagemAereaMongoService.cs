using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Application.Services
{
    public class PassagemAereaMongoService : IPassagemAereaMongoService 
    {
        private readonly IPassagemAereaMongoRepository _passagemAereaRepository;
        private readonly IPassageiroMongoRepository _passageiroRepository;
        private readonly ICompanhiaAereaMongoRepository _companhiaAereaRepository;

        public PassagemAereaMongoService(
            IPassagemAereaMongoRepository passagemAereaRepository,
            IPassageiroMongoRepository passageiroRepository,
            ICompanhiaAereaMongoRepository companhiaAereaRepository)
        {
            _passagemAereaRepository = passagemAereaRepository;
            _passageiroRepository = passageiroRepository;
            _companhiaAereaRepository = companhiaAereaRepository;
        }

        // Método para adicionar uma nova passagem
        public async Task AddPassagemAsync(PassagemAereaMongo passagemAerea)
        {
            // Verifica se o Passageiro com o Id fornecido existe
            var passageiro = await _passageiroRepository.GetByIdAsync(passagemAerea.IdPassageiro);
            if (passageiro == null)
            {
                throw new ArgumentException("Passageiro com o Id fornecido não existe.");
            }

            // Verifica se a Companhia Aérea com o Id fornecido existe
            var companhiaAerea = await _companhiaAereaRepository.GetByIdAsync(passagemAerea.IdCompanhiaAerea);
            if (companhiaAerea == null)
            {
                throw new ArgumentException("Companhia Aérea com o Id fornecido não existe.");
            }

            // Se tudo estiver ok, insere a passagem
            await _passagemAereaRepository.AddAsync(passagemAerea);
        }

        // Adicionar os outros métodos conforme necessário
        public async Task<IEnumerable<PassagemAereaMongo>> GetAllPassagensAsync()
        {
            return await _passagemAereaRepository.GetAllAsync();
        }

        public async Task<PassagemAereaMongo?> GetPassagemByIdAsync(int id)
        {
            return await _passagemAereaRepository.GetByIdAsync(id);
        }

        public async Task UpdatePassagemAsync(PassagemAereaMongo passagemAerea)
        {
            await _passagemAereaRepository.UpdateAsync(passagemAerea);
        }

        public async Task DeletePassagemAsync(int id)
        {
            await _passagemAereaRepository.DeleteAsync(id);
        }
    }
}
