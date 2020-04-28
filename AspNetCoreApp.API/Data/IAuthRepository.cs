using System.Threading.Tasks;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Data
{
    public interface IAuthRepository
    {
         Task<ResourcesMST> Register(ResourcesMST resource,string password);
         Task<ResourcesMST> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}