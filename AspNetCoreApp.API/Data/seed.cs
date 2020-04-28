using System.Collections.Generic;
using System.Linq;
using AspNetCoreApp.API.Models;
using Newtonsoft.Json;


namespace AspNetCoreApp.API.Data
{
    public class seed
    {
        public static void SeedResources(DataContext context)
        {
            if(!context.Resources.Any())
            {
                var resourcesData = System.IO.File.ReadAllText("Data/resourceSeedData.json");
                var resources = JsonConvert.DeserializeObject<List<ResourcesMST>>(resourcesData);
                foreach (var res in resources)
                {
                    byte[] passwordhash, passwordSalt;
                    CreatePasswordHash("password", out passwordhash, out passwordSalt);   

                    res.PasswordHash = passwordhash;
                    res.PasswordSalt = passwordSalt;
                    res.rm_Login_Id = res.rm_Login_Id.ToLower();
                    context.Resources.Add(res);
                }
                context.SaveChanges();
            }
        }

        
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hWindow = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hWindow.Key;
                passwordHash = hWindow.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}