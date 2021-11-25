using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PBL6BackEnd.Config;
using System;

namespace PBL6BackEnd
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var postgressConfig = Activator.CreateInstance<PostgresConfig>();
            configuration.Bind(typeof(PostgresConfig).Name, postgressConfig);

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseNpgsql(postgressConfig.BuildConnectionString(), b => b.MigrationsAssembly("PBL6BackEnd"));
            return new DataContext(optionsBuilder.Options);
        }
    }
}
