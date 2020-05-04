using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface ICityRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<city>> GetCities();
        Task<city> GetCity(int Id);
        Task<city> GenerateCity(city _city);
        Task<bool> UserExists(string _cityName); 
    }
}