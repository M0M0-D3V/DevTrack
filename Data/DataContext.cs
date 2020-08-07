using DevTrack.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace DevTrack.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(_configuration["ConnectionString"]);
        }

        public DbSet<User> Users { get; set; }
    }
}