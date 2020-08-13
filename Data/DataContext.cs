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
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<CoWorker> CoWorkers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}