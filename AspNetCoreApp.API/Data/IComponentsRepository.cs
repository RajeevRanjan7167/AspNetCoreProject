using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface IComponentsRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<components>> GetComponents();
        Task<components> GetComponent(int _Id);
        Task<components> GenerateComponent(components _components);
        Task<bool> UserExists(string GroupName); 
    }
}