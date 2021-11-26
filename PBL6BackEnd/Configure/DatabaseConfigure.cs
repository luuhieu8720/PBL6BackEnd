using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PBL6BackEnd;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Configure
{
    public static class DatabaseConfigure
    {
        public static void ConfigDatabase(this IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(options => PostgresDatabaseConnection.ConfigPosgressDb(services, options));
        }

        public static void MigrateDatabase(this IServiceCollection services)
        {
            services.BuildServiceProvider()
                .GetService<DataContext>()
                .Database
                .Migrate();
        }
    }
}
