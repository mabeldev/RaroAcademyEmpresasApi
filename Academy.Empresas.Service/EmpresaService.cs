using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Domain.Entities;
using AutoMapper;
using Academy.Empresas.Domain.Interfaces.Repository;

namespace Academy.Empresas.Service
{
    public class EmpresaService : Validators, IEmpresaService
    {
        public readonly IEmpresaRepository _empresaRepository;
        public readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
        public async Task<EmpresaResponse> Post(EmpresaRequest empresaRequest)
        {

            ValidacaoDeNomeFantasia(empresaRequest);

            ValidacaoDeEnderecoEmpresa(empresaRequest);

            var requestEmpresaEntity = _mapper.Map<EmpresaEntity>(empresaRequest);

            var empresaCadastrada = await _empresaRepository.Post(requestEmpresaEntity);

            return _mapper.Map<EmpresaResponse>(empresaCadastrada);
        }
        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            var listaEmpresasRetornoBaseDados = await _empresaRepository.Get();

            return _mapper.Map<IEnumerable<EmpresaResponse>>(listaEmpresasRetornoBaseDados);
        }

        public async Task<EmpresaResponse> GetById(int id)
        {
            ValidacaoDeId(id);

            var empresasRetornoBaseDados = await _empresaRepository.GetById(id);

            return _mapper.Map<EmpresaResponse>(empresasRetornoBaseDados);
        }

        public async Task<EmpresaResponse> Put(EmpresaRequest empresaRequest, int? id)
        {

            ValidacaoDeNomeFantasia(empresaRequest);

            ValidacaoDeEnderecoEmpresa(empresaRequest);

            var empresaBancoDeDados = await _empresaRepository.GetById((int)id);

            if (!empresaBancoDeDados.Nome.Equals(empresaRequest.Nome))
            {
                empresaBancoDeDados.Nome = empresaRequest.Nome;
            }
            if (!empresaBancoDeDados.NomeFantasia.Equals(empresaRequest.NomeFantasia))
            {
                empresaBancoDeDados.NomeFantasia = empresaRequest.NomeFantasia;
            }
            if (!empresaBancoDeDados.Endereco.Equals(empresaRequest.Endereco))
            {
                empresaBancoDeDados.Endereco = _mapper.Map<EnderecoEntity>(empresaRequest.Endereco);
            }

            var empresaCadastrado = await _empresaRepository.Put(empresaBancoDeDados, null);

            return _mapper.Map<EmpresaResponse>(empresaCadastrado);
        }
        public async Task Delete(int id)
        {
            ValidacaoDeId(id);
            
            var empresaBancoDeDados = await _empresaRepository.GetById((int)id);

            if (empresaBancoDeDados != null)
            {
                await _empresaRepository.Delete(empresaBancoDeDados);
            }
        }
    }
}