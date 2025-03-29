using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Services
{
    public interface IPassageiroService
    {
        Task<IEnumerable<Passageiro>> GetAllPassageirosAsync();
        Task<Passageiro> GetPassageiroByCpfAsync(string cpf);
        Task AddPassageiroAsync(Passageiro passageiro);
        Task UpdatePassageiroAsync(Passageiro passageiro);
        Task DeletePassageiroAsync(string cpf);
    }

}
