using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface IRoleRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Roles>> GetRoles();
        Task<Roles> GetRole(int _Id);
        Task<Roles> GenerateRole(Roles _role);
        Task<bool> UserExists(string _roleName);
    }
}