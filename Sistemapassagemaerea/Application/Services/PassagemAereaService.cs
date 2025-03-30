using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Application.Services
{
    public class PassagemAereaService : IPassagemAereaService
    {
        private readonly IPassagemAereaRepository _passagemAereaRepository;
        private readonly IUnityOfWork _unityOfWork;

        public PassagemAereaService(IPassagemAereaRepository passagemAereaRepository, IUnityOfWork unityOfWork)
        {
            _passagemAereaRepository = passagemAereaRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<IEnumerable<PassagemAereaDto>> GetAllPassagensAsync()
        {
            // Recupera as passagens aéreas do repositório
            var passagensAereas = await _passagemAereaRepository.GetAllAsync();

            // Converte as passagens para DTOs
            var passagensAereasDto = passagensAereas.Select(pa => new PassagemAereaDto(
                pa.CodigoPassagem,
                pa.DataHoraCompra,
                pa.ValorPassagem,
                pa.IdPassageiro,
                pa.Passageiro?.Nome ?? string.Empty, // Nome do passageiro (pode ser vazio se não houver passageiro)
                pa.IdCompanhiaAerea
            ));

            return passagensAereasDto;
        }

        public async Task<PassagemAereaDto> GetByIdAsync(int id)
        {
            // Recupera a passagem aérea por ID
            var passagemAerea = await _passagemAereaRepository.GetByIdAsync(id);

            if (passagemAerea == null)
                return null!;

            // Converte para DTO
            var passagemAereaDto = new PassagemAereaDto(
                passagemAerea.CodigoPassagem,
                passagemAerea.DataHoraCompra,
                passagemAerea.ValorPassagem,
                passagemAerea.IdPassageiro,
                passagemAerea.Passageiro?.Nome ?? string.Empty,
                passagemAerea.IdCompanhiaAerea
            );

            return passagemAereaDto;
        }

        public async Task<CadastroResponse> AddPassagemAereaAsync(PassagemAereaDto passagemAereaDto)
        {
           
            var passagemAerea = new PassagemAerea
            {
                CodigoPassagem = passagemAereaDto.CodigoPassagem,
                DataHoraCompra = passagemAereaDto.DataHoraCompra,
                ValorPassagem = passagemAereaDto.ValorPassagem,
                IdPassageiro = passagemAereaDto.IdPassageiro,
                IdCompanhiaAerea = passagemAereaDto.IdCompanhiaAerea
            };

            // Adiciona no repositório
            await _passagemAereaRepository.AddAsync(passagemAerea);
            await _unityOfWork.SaveChangesAsync();

            return new CadastroResponse(passagemAerea.Id);
        }

        public async Task UpdatePassagemAereaAsync(int id, PassagemAereaDto passagemAereaDto)
        {
            var passagemAerea = await _passagemAereaRepository.GetByIdAsync(id);

            if (passagemAerea == null)
                return;

            // Atualiza os dados da passagem aérea
            passagemAerea.CodigoPassagem = passagemAereaDto.CodigoPassagem;
            passagemAerea.DataHoraCompra = passagemAereaDto.DataHoraCompra;
            passagemAerea.ValorPassagem = passagemAereaDto.ValorPassagem;
            passagemAerea.IdPassageiro = passagemAereaDto.IdPassageiro;
            passagemAerea.IdCompanhiaAerea = passagemAereaDto.IdCompanhiaAerea;

            // Atualiza o repositório
            _passagemAereaRepository.Update(passagemAerea);
            await _unityOfWork.SaveChangesAsync();
        }

        public async Task DeletePassagemAereaAsync(int id)
        {
            var passagemAerea = await _passagemAereaRepository.GetByIdAsync(id);

            if (passagemAerea == null)
                return;

            _passagemAereaRepository.Delete(passagemAerea);
            await _unityOfWork.SaveChangesAsync();
        }
    }
}
