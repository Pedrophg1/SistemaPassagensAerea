using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Application.Services
{
    public class PassageiroService : IPassageiroService
    {
        private readonly IPassageiroRepository _passageiroRepository;
        private readonly IUnityOfWork _unityOfWork;

        public PassageiroService(IPassageiroRepository passageiroRepository, IUnityOfWork unityOfWork)
        {
            _passageiroRepository = passageiroRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<IEnumerable<PassageiroDto>> GetAllAsync()
        {
            var passageiros = await _passageiroRepository.GetAllAsync();

            var passageirosDto = passageiros.Select(p => new PassageiroDto(
                p.Cpf,
                p.Nome,
                p.DataNascimento,
                p.PassagensAereas?.Select(pa => new PassagemAereaDto(
                    pa.CodigoPassagem,
                    pa.DataHoraCompra,
                    pa.ValorPassagem,
                    pa.IdPassageiro,
                    pa.Passageiro?.Nome ?? string.Empty,
                    pa.IdCompanhiaAerea
                )) ?? Enumerable.Empty<PassagemAereaDto>()
            ));

            return passageirosDto;
        }

        public async Task<PassageiroDto> GetByIdAsync(int id)
        {
            var passageiro = await _passageiroRepository.GetByIdAsync(id);

            if (passageiro == null)
                return null!;

            var passageiroDto = new PassageiroDto(
                passageiro.Cpf,
                passageiro.Nome,
                passageiro.DataNascimento,
                passageiro.PassagensAereas?.Select(pa => new PassagemAereaDto(
                    pa.CodigoPassagem,
                    pa.DataHoraCompra,
                    pa.ValorPassagem,
                    pa.IdPassageiro,
                    pa.Passageiro?.Nome ?? string.Empty,
                    pa.IdCompanhiaAerea
                )) ?? Enumerable.Empty<PassagemAereaDto>()
            );

            return passageiroDto;
        }

        public async Task<CadastroResponse> AddAsync(CadastrarPassageiroDto passageiroDto)
        {
            var passageiro = new Passageiro
            {
                Cpf = passageiroDto.Cpf,
                Nome = passageiroDto.Nome,
                DataNascimento = passageiroDto.DataNascimento,
            };

            await _passageiroRepository.AddAsync(passageiro);
            await _unityOfWork.SaveChangesAsync();

            return new CadastroResponse(passageiro.Id);
        }

        public async Task UpdatePassageiroAsync(int id, CadastrarPassageiroDto passageiroDto)
        {
            var passageiro = await _passageiroRepository.GetByIdAsync(id);

            if (passageiro == null)
                return;

            passageiro.Cpf = passageiroDto.Cpf;
            passageiro.Nome = passageiroDto.Nome;
            passageiro.DataNascimento = passageiroDto.DataNascimento;

            _passageiroRepository.Update(passageiro);
            await _unityOfWork.SaveChangesAsync();
        }

        public async Task DeletePassageiroAsync(int id)
        {
            var passageiro = await _passageiroRepository.GetByIdAsync(id);

            if (passageiro == null)
                return;

            _passageiroRepository.Delete(passageiro);
            await _unityOfWork.SaveChangesAsync();
        }
    }
}
