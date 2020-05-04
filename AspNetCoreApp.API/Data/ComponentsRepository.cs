using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class ComponentsRepository : IComponentsRepository
    {
        private readonly DataContext _context;

        public ComponentsRepository(DataContext context)
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

        public async Task<components> GenerateComponent(components _components)
        {
            await _context.Components.AddAsync(_components);
            await _context.SaveChangesAsync();
            return _components;
        }

        public async Task<components> GetComponent(int _Id)
        {
            var Component = await _context.Components.FirstOrDefaultAsync(c => c.id == _Id);
            return Component;
        }

        public async Task<IEnumerable<components>> GetComponents()
        {
            var Components = await _context.Components.ToListAsync();
            return Components;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserExists(string _components)
        {
            if(await _context.Components.AnyAsync(c=> c.com_Name == _components))
                return true;
            
            return false;
        }
    }
}