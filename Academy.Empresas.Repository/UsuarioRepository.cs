using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Academy.Empresas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EmpresasApiContext _context;

        public UsuarioRepository(EmpresasApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioEntity>> Get()
        {
            return await _context.Usuarios.AsNoTracking().Include(prop => prop.Endereco).ToListAsync();
        }

        public async Task<UsuarioEntity> GetById(int id)
        {
            return await _context.Usuarios.Where(prop => prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> GetByEmail(string email)
        {
            return await _context.Usuarios.Where(prop => prop.Email == email)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> Post(UsuarioEntity request)
        {
            await _context.Usuarios.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<UsuarioEntity> Put(UsuarioEntity request, int? id = null)
        {
            _context.Usuarios.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task Delete(UsuarioEntity request)
        {
            _context.Usuarios.Remove(request);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }
    }
}