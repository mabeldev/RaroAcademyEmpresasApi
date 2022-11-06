using System.Text.RegularExpressions;
using Academy.Empresas.Domain.Contracts.Empresa;
using Academy.Empresas.Domain.Contracts.Usuario;
using Academy.Empresas.Domain.Enum;
using Academy.Empresas.Service.Utils;

namespace Academy.Empresas.Service
{
    public class Validators
    {
        public static void ValidacaoDeEmail(UsuarioRequest usuarioRequest)
        {
            Regex EmailRegex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (usuarioRequest.Email.Length <= 0)
            {
                throw new ArgumentException("Email não pode ser nulo!");
            }
            if (!EmailRegex.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException("Email não corresponde a um email válido!");
            }
        }
        public static void ValidacaoDeNomeFantasia(EmpresaRequest emrpesaRequest)
        {
            if (emrpesaRequest.NomeFantasia.Length <= 2)
            {
                throw new ArgumentException("Nome Fantasia de empresa é muito pequeno ou inexistente!");
            }
        }
        public static void ValidacaoDeEndereco(UsuarioRequest usuarioRequest)
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
                throw new ArgumentException("Estado não pode ser nulo");
            }
            if (usuarioRequest.Endereco.Numero.Length <= 0)
            {
                throw new ArgumentException("Numero não pode ser nulo");
            }
        }

        public static void ValidacaoDeEnderecoEmpresa(EmpresaRequest empresaRequest)
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
                throw new ArgumentException("Estado não pode ser nulo");
            }
            if (empresaRequest.Endereco.Numero.Length <= 0)
            {
                throw new ArgumentException("Numero não pode ser nulo");
            }
        }

        public static void ValidacaoDeNome(UsuarioRequest usuarioRequest)
        {
            if (usuarioRequest.Nome == null || usuarioRequest.Nome.Length <= 2)
            {
                throw new ArgumentException("Nome de usuário inválido ou inexistente!");
            }
        }
        public static void ValidacaoDeNomeEmpresa(UsuarioRequest usuarioRequest)
        {
            if (usuarioRequest.Nome == null || usuarioRequest.Nome.Length <= 2)
            {
                throw new ArgumentException("Nome de usuário inválido ou inexistente!");
            }
        }
        public static void ValidacaoDeDataDeNascimento(UsuarioRequest usuarioRequest)
        {
            if (!DateValidation.Validacao(usuarioRequest.DataDeNascimento))
            {
                throw new ArgumentException("Data está invalida!");
            }
        }

        public static void ValidacaoDeCpf(UsuarioRequest usuarioRequest)
        {
            if (!CpfValidation.Validacao(usuarioRequest.CPF))
            {
                throw new ArgumentException("Cpf não corresponde a um cpf válido!");
            }
        }
        public static void ValidacaoDeTelefone(UsuarioRequest usuarioRequest)
        {
            Regex TelefoneRegex = new Regex(@"^\(?[1-9]{2}\)?\s?(?:[0-9]|9[0-9])[0-9]{3}\-?[0-9]{4}$");
            if (!TelefoneRegex.IsMatch(usuarioRequest.Telefone))
            {
                throw new ArgumentException("Telefone não corresponde a um telefone válido");
            }
        }
        public static void ValidacaoDeEnum(UsuarioRequest usuarioRequest)
        {
            if (!Enum.IsDefined(typeof(RoleEnum), usuarioRequest.Role))
            {
                throw new ArgumentException("Essa role não existe, use Admin ou Cliente");
            }
        }

        public static void ValidacaoDeSenha(UsuarioCadastroRequest usuarioRequest)
        {
            Regex SenhaRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8,}$");
            if (!SenhaRegex.IsMatch(usuarioRequest.Senha))
            {
                throw new ArgumentException("Sua senha é muito fraca, necessário caracteres especiais, números e letras (Aa)");
            }
        }
        public static void ValidacaoDeId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id de usuário não pode ser nulo");
            }
        }
    }
}