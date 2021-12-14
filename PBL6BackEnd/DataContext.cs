using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBL6BackEnd.Extensions;
using PBL6BackEnd.Model;

namespace PBL6BackEnd
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Username = "admin",
                    Password = "admin".Encrypt(),
                    FirstName = "Admin",
                    LastName = "01",
                    Role = Role.Admin
                });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaskPredictedInfo>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.MaskPredictedInfos)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<MaskPredictedInfo> MaskPredictedInfos { get; set; }
    }
}
