namespace Academy.Empresas.Domain.Interfaces.Service
{
    public interface IAutenticacaoService
    {
        Task<string> Login(string usuario, string senha);
    }
}