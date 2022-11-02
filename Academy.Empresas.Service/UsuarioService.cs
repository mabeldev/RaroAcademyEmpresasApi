using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Entities;
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