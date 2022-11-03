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

            Regex EmailRegex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            Regex TelefoneRegex = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}-[0-9]{4}$");
            Regex SenhaRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8,}$");

            if (usuarioRequest.Nome == null || usuarioRequest.Nome.Length <= 2)
            {
                throw new ArgumentException("Nome de usuário inválido ou inexistente!");
            }
            
            if (!CpfValidation.Validacao(usuarioRequest.CPF))
            {
                throw new ArgumentException ("Cpf não corresponde a um cpf válido!");
            }

            if (usuarioRequest.Endereco.Rua.Length <= 0)
            {
                throw new ArgumentException ("Rua não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Bairro.Length <= 0)
            {
                throw new ArgumentException ("Bairro não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Cep.Length <= 0)
            {
                throw new ArgumentException ("Cep não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Cidade.Length <= 0)
            {
                throw new ArgumentException ("Cidade não pode ser nulo");
            }

            if (usuarioRequest.Endereco.Estado.Length <= 0)
            {
                throw new ArgumentException ("Cidade não pode ser nulo");
            }
            if (usuarioRequest.Endereco.Numero.Length <= 0)
            {
                throw new ArgumentException ("Numero não pode ser nulo");
            }
            if (usuarioRequest.Email.Length <= 0)
            {
                throw new ArgumentException ("Email não pode ser nulo");
            }
            if (!EmailRegex.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException ("Email não corresponde a um email válido");
            }
            
            if (!DateValidation.Validacao(usuarioRequest.DataDeNascimento))
            {
                throw new ArgumentException ("Data está invalida!");
            }

            if (!TelefoneRegex.IsMatch(usuarioRequest.Telefone))
            {
                throw new ArgumentException ("Telefone não corresponde a um telefone válido");
            }

            if (!SenhaRegex.IsMatch(usuarioRequest.Senha))
            {
                throw new ArgumentException ("Sua senha é muito fraca, necessário caracteres especiais, números e letras (Aa)");
            }

            if (!Enum.IsDefined(typeof(RoleEnum), usuarioRequest.Role))
            {
            throw new ArgumentException("Essa role não existe, use Admin ou Cliente");
            }

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
            var usuariosRetornoBaseDados = await _usuarioRepository.GetById(id);

            return _mapper.Map<UsuarioResponse>(usuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> Put(UsuarioRequest usuarioRequest, int? id)
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);

            usuarioBancoDeDados.Nome = usuarioRequest.Nome;

            var usuarioCadastrado = await _usuarioRepository.Put(usuarioBancoDeDados, null);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }
        public async Task Delete(int id)
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);

            if (usuarioBancoDeDados != null)
            {
                await _usuarioRepository.Delete(usuarioBancoDeDados);
            }
        }

    }
}