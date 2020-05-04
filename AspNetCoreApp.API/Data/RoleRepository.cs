using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Roles> GetRole(int Id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.id == Id);
            return role;
        }

        public async Task<IEnumerable<Roles>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserExists(string _roleName)
        {
            if (await _context.Roles.AnyAsync(x => x.role_Name == _roleName))
                return true;

            return false;
        }

        public async Task<Roles> GenerateRole(Roles roles)
        {
            await _context.Roles.AddAsync(roles);
            await _context.SaveChangesAsync();
            return roles;
        }       


    }
}