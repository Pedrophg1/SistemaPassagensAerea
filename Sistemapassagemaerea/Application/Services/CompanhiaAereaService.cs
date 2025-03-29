using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Application.Services
{
    public class CompanhiaAereaService(ICompanhiaAereaRepository companhiaAereaRepository,
                                       IUnityOfWork unityOfWork) : ICompanhiaAereaService
    {
        private readonly ICompanhiaAereaRepository _companhiaAereaRepository = companhiaAereaRepository;
        private readonly IUnityOfWork _unityOfWork = unityOfWork;

        public async Task<IEnumerable<CompanhiaAereaDto>> GetAllAsync()
        {
            var companhias =  await _companhiaAereaRepository.GetAllAsync();

            var companhiasDto = companhias.Select(x => new CompanhiaAereaDto(
                                x.CodIATA,
                                x.NomeCompanhia,
                                x.EnderecoCompanhia,
                                x.PassagensAereas?.Select(p => new PassagemAereaDto(
                                    p.CodigoPassagem,
                                    p.DataHoraCompra,
                                    p.ValorPassagem,
                                    p.IdPassageiro,
                                    p.Passageiro?.Nome ?? string.Empty,
                                    p.IdCompanhiaAerea
                                )) ?? Enumerable.Empty<PassagemAereaDto>()) 
            );

            return companhiasDto;
        }

        public async Task<CompanhiaAereaDto> GetByIdAsync(int id)
        {
            var companhia = await _companhiaAereaRepository.GetByIdAsync(id);

            if (companhia == null)
                return null!;

            var companhiaDto =  new CompanhiaAereaDto(
                companhia.CodIATA,
                companhia.NomeCompanhia,
                companhia.EnderecoCompanhia,
                companhia.PassagensAereas?.Select(p => new PassagemAereaDto(
                    p.CodigoPassagem,
                    p.DataHoraCompra,
                    p.ValorPassagem,
                    p.IdPassageiro,
                    p.Passageiro?.Nome ?? string.Empty,
                    p.IdCompanhiaAerea
                )) ?? Enumerable.Empty<PassagemAereaDto>()
            );

            return companhiaDto;
        }

        public async Task<CadastroResponse> AddAsync(CadastrarCompanhiaAereaDto companhiaDto)
        {
            var companhia = new CompanhiaAerea
            {
                CodIATA = companhiaDto.CodIATA,
                NomeCompanhia = companhiaDto.NomeCompanhia,
                EnderecoCompanhia = companhiaDto.EnderecoCompanhia,
            };

            await _companhiaAereaRepository.AddAsync(companhia);
            await _unityOfWork.SaveChangesAsync();
            return new CadastroResponse(companhia.Id);
        }

        public async Task Update(int id, CadastrarCompanhiaAereaDto companhiaDto)
        {
            var companhia = await _companhiaAereaRepository.GetByIdAsync(id);

            if (companhia == null)
                return; 

            companhia.CodIATA = companhiaDto.CodIATA;
            companhia.NomeCompanhia = companhiaDto.NomeCompanhia;
            companhia.EnderecoCompanhia = companhiaDto.EnderecoCompanhia;

            _companhiaAereaRepository.Update(companhia);
            await _unityOfWork.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var companhia = await _companhiaAereaRepository.GetByIdAsync(id);

            if (companhia == null)
                return;

            _companhiaAereaRepository.Delete(companhia);
            await _unityOfWork.SaveChangesAsync();
        }
    }

}
