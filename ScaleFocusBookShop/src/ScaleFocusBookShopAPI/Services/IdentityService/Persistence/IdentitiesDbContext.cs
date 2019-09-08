using IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Persistence
{
    public class IdentitiesDbContext : DbContext
    {
        public IdentitiesDbContext(DbContextOptions<IdentitiesDbContext> options) : base(options)
        {

        }

        public DbSet<Identity> Identities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>().HasData(
                new Identity() { Id = 1, Username = "kstoilov", Password = "1234"},
                new Identity() { Id = 2, Username = "gbajatovski", Password = "1235"},
                new Identity() { Id = 3, Username = "akulakov", Password = "1236"}
            );
        }
    }
}
