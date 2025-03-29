using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public interface IPassageiroRepository
    {
        Task<IEnumerable<Passageiro>> GetAllPassageirosAsync();
        Task<Passageiro> GetPassageiroByCpfAsync(string cpf);
        Task AddPassageiroAsync(Passageiro passageiro);
        Task UpdatePassageiroAsync(Passageiro passageiro);
        Task DeletePassageiroAsync(string cpf);
    }

}
