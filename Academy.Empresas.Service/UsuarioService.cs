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
    public class UsuarioService : IUsuarioService
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
        
        private static void ValidacaoDeEmail(UsuarioRequest usuarioRequest)
        {
            Regex EmailRegex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (usuarioRequest.Email.Length <= 0)
            {
                throw new ArgumentException("Email não pode ser nulo");
            }
            if (!EmailRegex.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException("Email não corresponde a um email válido");
            }
        }
        private static void ValidacaoDeEndereco(UsuarioRequest usuarioRequest)
        {
            if (usuarioRequest.Endereco.Rua.Length <= 0)
            {
                throw new ArgumentException("Rua não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Bairro.Length <= 0)
            {
                throw new ArgumentException("Bairro não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Cep.Length <= 0)
            {
                throw new ArgumentException("Cep não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Cidade.Length <= 0)
            {
                throw new ArgumentException("Cidade não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Estado.Length <= 0)
            {
                throw new ArgumentException("Cidade não pode ser nulo");
            }
            if (usuarioRequest.Endereco.Numero.Length <= 0)
            {
                throw new ArgumentException("Numero não pode ser nulo");
            }
        }
        private static void ValidacaoDeNome(UsuarioRequest usuarioRequest)
        {
            if (usuarioRequest.Nome == null || usuarioRequest.Nome.Length <= 2)
            {
                throw new ArgumentException("Nome de usuário inválido ou inexistente!");
            }
        }
        private static void ValidacaoDeDataDeNascimento(UsuarioRequest usuarioRequest)
        {
            if (!DateValidation.Validacao(usuarioRequest.DataDeNascimento))
            {
                throw new ArgumentException("Data está invalida!");
            }
        }

        private static void ValidacaoDeCpf(UsuarioRequest usuarioRequest)
        {
            if (!CpfValidation.Validacao(usuarioRequest.CPF))
            {
                throw new ArgumentException("Cpf não corresponde a um cpf válido!");
            }
        }
        private static void ValidacaoDeTelefone(UsuarioRequest usuarioRequest)
        {
            Regex TelefoneRegex = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}-[0-9]{4}$");
            if (!TelefoneRegex.IsMatch(usuarioRequest.Telefone))
            {
                throw new ArgumentException("Telefone não corresponde a um telefone válido");
            }
        }
        private static void ValidacaoDeEnum(UsuarioRequest usuarioRequest)
        {
            if (!Enum.IsDefined(typeof(RoleEnum), usuarioRequest.Role))
            {
                throw new ArgumentException("Essa role não existe, use Admin ou Cliente");
            }
        }

        private static void ValidacaoDeSenha(UsuarioCadastroRequest usuarioRequest)
        {
            Regex SenhaRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8,}$");
            if (!SenhaRegex.IsMatch(usuarioRequest.Senha))
            {
                throw new ArgumentException("Sua senha é muito fraca, necessário caracteres especiais, números e letras (Aa)");
            }
        }
        private static void ValidacaoDeId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id de usuário não pode ser nulo");
            }
        }
    }
}