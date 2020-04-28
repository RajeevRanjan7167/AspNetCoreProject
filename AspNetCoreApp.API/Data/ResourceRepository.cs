using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DataContext _context;        
        public ResourceRepository(DataContext context)
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

        public async Task<ResourcesMST> GetResource(int Id)
        {
            var resource = await _context.Resources.Include(p => p.Photos).FirstOrDefaultAsync(r => r.ID==Id);
            return resource;        
        }

        public async Task<IEnumerable<ResourcesMST>> GetResources()
        {
            var resources = await _context.Resources.Include(p => p.Photos).ToListAsync();
            return resources;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}