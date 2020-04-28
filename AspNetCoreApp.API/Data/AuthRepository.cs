using System;
using System.Threading.Tasks;
using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<ResourcesMST> Login(string username, string password)
        {
            var user = await _context.Resources.FirstOrDefaultAsync(x => x.rm_Login_Id == username);

            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using (var hWindow = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {            
               var ComputeHash = hWindow.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0 ; i< ComputeHash.Length;i ++  )
                {
                    if(ComputeHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public async Task<ResourcesMST> Register(ResourcesMST user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _context.Resources.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hWindow = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hWindow.Key;
                passwordHash = hWindow.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Resources.AnyAsync(x=> x.rm_Login_Id == username))
                return true;
            
            return false;
        }
    }
}