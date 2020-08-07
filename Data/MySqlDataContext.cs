// using DevTrack.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;

// namespace DevTrack.Data
// {
//     public class MySqlDataContext : DataContext
//     {
//         public MySqlDataContext(IConfiguration configuration) : base(configuration) { }
//         protected override void OnConfiguring(DbContextOptionsBuilder options)
//         {
//             options.UseMySql(_configuration["ConnectionString"]);
//         }

//     }
// }