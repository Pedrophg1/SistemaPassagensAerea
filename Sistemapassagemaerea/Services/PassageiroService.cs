using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

namespace Sistemapassagemaerea.Services
{
    public class PassageiroService : IPassageiroService
    {
        private readonly IPassageiroRepository _passageiroRepository;

        public PassageiroService(IPassageiroRepository passageiroRepository)
        {
            _passageiroRepository = passageiroRepository;
        }

        public async Task<IEnumerable<Passageiro>> GetAllPassageirosAsync()
        {
            return await _passageiroRepository.GetAllPassageirosAsync();
        }

        public async Task<Passageiro> GetPassageiroByCpfAsync(string cpf)
        {
            return await _passageiroRepository.GetPassageiroByCpfAsync(cpf);
        }

        public async Task AddPassageiroAsync(Passageiro passageiro)
        {
            await _passageiroRepository.AddPassageiroAsync(passageiro);
        }

        public async Task UpdatePassageiroAsync(Passageiro passageiro)
        {
            await _passageiroRepository.UpdatePassageiroAsync(passageiro);
        }

        public async Task DeletePassageiroAsync(string cpf)
        {
            await _passageiroRepository.DeletePassageiroAsync(cpf);
        }
    }

}
