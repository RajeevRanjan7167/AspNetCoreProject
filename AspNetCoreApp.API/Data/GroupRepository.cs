using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;
        public GroupRepository(DataContext context)
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

        public async Task<Groups> GenerateGroup(Groups _groups)
        {
            await _context.Groups.AddAsync(_groups);
            await _context.SaveChangesAsync();
            return _groups;
        }

        public async Task<Groups> GetGroup(int _Id)
        {
            var Group = await _context.Groups.FirstOrDefaultAsync(g => g.id == _Id);
            return Group;
        }

        public async Task<IEnumerable<Groups>> GetGroups()
        {
            var Groups = await _context.Groups.ToListAsync();
            return Groups;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync()> 0;
        }

        public async Task<bool> UserExists(string _groupName)
        {
             if(await _context.Groups.AnyAsync(g => g.group_Name == _groupName))
                return true;
            
            return false;
        }
    }
}