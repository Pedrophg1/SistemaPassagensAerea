using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassagemAereaMongoService
    {
        Task AddPassagemAsync(PassagemAereaMongo passagemAerea);

       
        Task<IEnumerable<PassagemAereaMongo>> GetAllPassagensAsync();

     
        Task<PassagemAereaMongo?> GetPassagemByIdAsync(int id);

       
        Task UpdatePassagemAsync(PassagemAereaMongo passagemAerea);

        
        Task DeletePassagemAsync(int id);
    }
}
