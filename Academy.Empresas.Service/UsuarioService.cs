using System.Text.RegularExpressions;
using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Enum;
using Academy.Empresas.Domain.Interfaces.Repository;
using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Domain.Shared;
using AutoMapper;

namespace Academy.Empresas.Service
{
    public class UsuarioService :  Validators, IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Task<UsuarioResponse> Post(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponse> Post(UsuarioCadastroRequest usuarioRequest)
        {

            ValidacaoDeNome(usuarioRequest);

            ValidacaoDeCpf(usuarioRequest);

            ValidacaoDeEndereco(usuarioRequest);

            ValidacaoDeEmail(usuarioRequest);

            ValidacaoDeDataDeNascimento(usuarioRequest);

            ValidacaoDeTelefone(usuarioRequest);

            ValidacaoDeSenha(usuarioRequest);

            ValidacaoDeEnum(usuarioRequest);

            var requestUsuarioEntity = _mapper.Map<UsuarioEntity>(usuarioRequest);

            requestUsuarioEntity.Senha = Cryptography.Encrypt(usuarioRequest.Senha);

            var usuarioCadastrado = await _usuarioRepository.Post(requestUsuarioEntity);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }

        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            var listaUsuariosRetornoBaseDados = await _usuarioRepository.Get();

            return _mapper.Map<IEnumerable<UsuarioResponse>>(listaUsuariosRetornoBaseDados);
        }
        public async Task<IEnumerable<AdminUsuarioResponse>> AdminGet()
        {
            var listaUsuariosRetornoBaseDados = await _usuarioRepository.Get();

            return _mapper.Map<IEnumerable<AdminUsuarioResponse>>(listaUsuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> GetById(int id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id de usuário não pode ser nulo");
            }
            var usuariosRetornoBaseDados = await _usuarioRepository.GetById(id);

            return _mapper.Map<UsuarioResponse>(usuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> Put(UsuarioCadastroRequest usuarioRequest, int? id)
        {
            ValidacaoDeId(id);

            ValidacaoDeNome(usuarioRequest);

            ValidacaoDeCpf(usuarioRequest);

            ValidacaoDeEndereco(usuarioRequest);

            ValidacaoDeEmail(usuarioRequest);

            ValidacaoDeSenha(usuarioRequest);

            ValidacaoDeDataDeNascimento(usuarioRequest);

            ValidacaoDeTelefone(usuarioRequest);

            ValidacaoDeEnum(usuarioRequest);

            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);
            var _senhaCriptografada = Cryptography.Encrypt(usuarioRequest.Senha);

            if (!usuarioBancoDeDados.Nome.Equals(usuarioRequest.Nome))
            {
                usuarioBancoDeDados.Nome = usuarioRequest.Nome;
            }
            if (!usuarioBancoDeDados.CPF.Equals(usuarioRequest.CPF))
            {
                usuarioBancoDeDados.CPF = usuarioRequest.CPF;
            }
            if (!usuarioBancoDeDados.DataDeNascimento.Equals(usuarioRequest.DataDeNascimento))
            {
                usuarioBancoDeDados.DataDeNascimento = usuarioRequest.DataDeNascimento;
            }
            if (!usuarioBancoDeDados.Endereco.Equals(usuarioRequest.Endereco))
            {
                usuarioBancoDeDados.Endereco = _mapper.Map<EnderecoEntity>(usuarioRequest.Endereco);
            }
            if (!usuarioBancoDeDados.Email.Equals(usuarioRequest.Email))
            {
                usuarioBancoDeDados.Email = usuarioRequest.Email;
            }
            if (!usuarioBancoDeDados.Senha.Equals(usuarioRequest.Senha))
            {
                usuarioBancoDeDados.Senha = usuarioRequest.Senha;
            }
            if (!usuarioBancoDeDados.DataDeNascimento.Equals(usuarioRequest.DataDeNascimento))
            {
                usuarioBancoDeDados.DataDeNascimento = usuarioRequest.DataDeNascimento;
            }
            if (!usuarioBancoDeDados.Telefone.Equals(usuarioRequest.Telefone))
            {
                usuarioBancoDeDados.Telefone = usuarioRequest.Telefone;
            }

            var usuarioCadastrado = await _usuarioRepository.Put(usuarioBancoDeDados, null);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }

        public async Task Delete(int id)
        {
            ValidacaoDeId(id);

            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);

            if (usuarioBancoDeDados != null)
            {
                await _usuarioRepository.Delete(usuarioBancoDeDados);
            }
        }
        public Task<UsuarioResponse> Put(UsuarioRequest request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}