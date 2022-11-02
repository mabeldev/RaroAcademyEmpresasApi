using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academy.Empresas.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly EmpresasApiContext _context;

        public EnderecoRepository(EmpresasApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnderecoEntity>> Get()
        {
            return await _context.Enderecos.AsNoTracking().ToListAsync();
        }

        public async Task<EnderecoEntity> GetById(int id)
        {
            return await _context.Enderecos.Where(prop => prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<EnderecoEntity> Post(EnderecoEntity request)
        {
            await _context.Enderecos.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<EnderecoEntity> Put(EnderecoEntity request, int? id = null)
        {
            _context.Enderecos.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task Delete(EnderecoEntity request)
        {
            _context.Enderecos.Remove(request);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }
    }
}