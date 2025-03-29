using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

namespace Sistemapassagemaerea.Services
{
    public class CompanhiaAereaService : ICompanhiaAereaService
    {
        private readonly ICompanhiaAereaRepository _companhiaAereaRepository;

        public CompanhiaAereaService(ICompanhiaAereaRepository companhiaAereaRepository)
        {
            _companhiaAereaRepository = companhiaAereaRepository;
        }

        public async Task<IEnumerable<Companhia_Aerea>> GetAllCompanhiasAsync()
        {
            return await _companhiaAereaRepository.GetAllCompanhiasAsync();
        }

        public async Task<Companhia_Aerea> GetCompanhiaByCodigoAsync(string codigo)
        {
            return await _companhiaAereaRepository.GetCompanhiaByCodigoAsync(codigo);
        }

        public async Task AddCompanhiaAsync(Companhia_Aerea companhia)
        {
            await _companhiaAereaRepository.AddCompanhiaAsync(companhia);
        }

        public async Task UpdateCompanhiaAsync(Companhia_Aerea companhia)
        {
            await _companhiaAereaRepository.UpdateCompanhiaAsync(companhia);
        }

        public async Task DeleteCompanhiaAsync(string codigo)
        {
            await _companhiaAereaRepository.DeleteCompanhiaAsync(codigo);
        }
    }

}
