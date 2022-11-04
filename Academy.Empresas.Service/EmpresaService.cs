using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Domain.Entities;
using AutoMapper;
using Academy.Empresas.Domain.Interfaces.Repository;

namespace Academy.Empresas.Service
{
    public class EmpresaService : IEmpresaService
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

            ValidacaoDeEndereco(empresaRequest);

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

            ValidacaoDeEndereco(empresaRequest);

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
        private static void ValidacaoDeNomeFantasia(EmpresaRequest emrpesaRequest)
        {
            if (emrpesaRequest.NomeFantasia.Length <= 2)
            {
                throw new ArgumentException("Nome Fantasia de empresa é muito pequeno ou inexistente!");
            }
        }
        private static void ValidacaoDeNome(EmpresaRequest emrpesaRequest)
        {
            if (emrpesaRequest.Nome.Length <= 2)
            {
                throw new ArgumentException("Nome de empresa é muito pequeno ou inexistente!");
            }
        }
        private static void ValidacaoDeId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id de empresa não pode ser nulo");
            }
        }
        private static void ValidacaoDeEndereco(EmpresaRequest empresaRequest)
        {
            if (empresaRequest.Endereco.Rua.Length <= 0)
            {
                throw new ArgumentException("Rua não pode ser nulo");
            }

            if (empresaRequest.Endereco.Bairro.Length <= 0)
            {
                throw new ArgumentException("Bairro não pode ser nulo");
            }

            if (empresaRequest.Endereco.Cep.Length <= 0)
            {
                throw new ArgumentException("Cep não pode ser nulo");
            }

            if (empresaRequest.Endereco.Cidade.Length <= 0)
            {
                throw new ArgumentException("Cidade não pode ser nulo");
            }

            if (empresaRequest.Endereco.Estado.Length <= 0)
            {
                throw new ArgumentException("Cidade não pode ser nulo");
            }
            if (empresaRequest.Endereco.Numero.Length <= 0)
            {
                throw new ArgumentException("Numero não pode ser nulo");
            }
        }
    }
}