using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface IGroupRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Groups>> GetGroups();
        Task<Groups> GetGroup(int _Id);
        Task<Groups> GenerateGroup(Groups _groups);
        Task<bool> UserExists(string _groupName); 
    }
}