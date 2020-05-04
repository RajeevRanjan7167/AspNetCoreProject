using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class FieldRepository : IFieldRepository
    {
        private readonly DataContext _context;
        public FieldRepository(DataContext context)
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

        public async Task<Fields> GetField(int Id)
        {
           var field = await _context.Fields.FirstOrDefaultAsync(f => f.id ==Id);
           return field; 
        }

        public async Task<IEnumerable<Fields>> GetFields()
        {
            var sField = await _context.Fields.ToListAsync();
            return sField;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0 ;
        }

         public async Task<Fields> GenerateField(Fields _fields)
        {
            await _context.Fields.AddAsync(_fields);
            await _context.SaveChangesAsync();
            return _fields;
        }

         public async Task<bool> UserExists(string _fieldName)
        {
             if(await _context.Fields.AnyAsync(f => f.fi_Name == _fieldName))
                return true;
            
            return false;
        }
    }
}