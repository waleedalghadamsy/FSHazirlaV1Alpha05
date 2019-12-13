using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppOnLinux
{
    public class ExampleDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        //public DbSet<Person> persons { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }
}
