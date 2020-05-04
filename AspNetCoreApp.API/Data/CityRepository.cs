using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context)
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

        public async Task<city> GenerateCity(city _city)
        {
            await _context.City.AddAsync(_city);
            await _context.SaveChangesAsync();
            return _city;
        }

        public async Task<city> GetCity(int Id)
        {
             var city = await _context.City.FirstOrDefaultAsync(c => c.id == Id);
            return city;
        }

        public async Task<IEnumerable<city>> GetCities()
        {
             var citys = await _context.City.ToListAsync();
            return citys;
        }

        public async Task<bool> SaveAll()
        {
        return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserExists(string _cityName)
        {
            if (await _context.City.AnyAsync(c => c.ct_Name == _cityName))
                return true;

            return false;
        }
    }
}