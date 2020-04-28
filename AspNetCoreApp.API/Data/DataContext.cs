using AspNetCoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Value> Values { get; set; }
        public DbSet<ResourcesMST> Resources { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<city> City { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}