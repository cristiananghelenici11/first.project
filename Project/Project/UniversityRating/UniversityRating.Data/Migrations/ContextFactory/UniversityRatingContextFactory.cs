//using System.IO;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using UniversityRating.Data.Context;
//
//namespace UniversityRating.Data.Migrations.ContextFactory
//{
//    public class UniversityRatingContextFactory : IDesignTimeDbContextFactory<UniversityRatingContext>
//    {
//        public UniversityRatingContext CreateDbContext(string[] args)
//        {
//            var builder = new ConfigurationBuilder();
//            
//            builder.SetBasePath(Directory.GetCurrentDirectory());
//
//            builder.AddJsonFile("appsettings.json");
//
//            IConfigurationRoot config = builder.Build();
//
//            string connectionString = config.GetConnectionString("UniversityDatabase");
//
//            var optionsBuilder = new DbContextOptionsBuilder<UniversityRatingContext>();
//            DbContextOptions<UniversityRatingContext> options = optionsBuilder
//                .UseSqlServer(connectionString)
//                .Options;
//
//            return new UniversityRatingContext(options);
//        }
//    }
//}