using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academy.Empresas.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EmpresasApiContext _context;

        public EmpresaRepository(EmpresasApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaEntity>> Get()
        {
            return await _context.Empresas.AsNoTracking().Include(prop => prop.Endereco).ToListAsync();
        }

        public async Task<EmpresaEntity> GetById(int id)
        {
            return await _context.Empresas.Where(prop => prop.Id == id).AsNoTracking().Include(prop => prop.Endereco).FirstOrDefaultAsync();
        }

        public async Task<EmpresaEntity> Post(EmpresaEntity request)
        {
            await _context.Empresas.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<EmpresaEntity> Put(EmpresaEntity request, int? id = null)
        {
            _context.Empresas.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task Delete(EmpresaEntity request)
        {
            _context.Empresas.Remove(request);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }
    }
}