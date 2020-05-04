using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface IFieldRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Fields>> GetFields();
        Task<Fields> GetField(int Id);
        Task<Fields> GenerateField(Fields _fields);
        Task<bool> UserExists(string _fieldsName);
    }
}