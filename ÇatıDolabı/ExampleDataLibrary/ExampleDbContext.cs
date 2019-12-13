using ExampleEntityLibrary;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExampleDataLibrary
{
    public class ExampleDbContext : DbContext
    {
        //public DbSet<School> Schools { get; set; }
        //public DbSet<Classroom> Classrooms { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<معلم> المعلمون { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<YerAdres> YerAdresler { get; set; }
        public DbSet<ÇalışmaZamanlama> ÇalışmaZamanlamalar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //BağlantıDizesi = "Data Source=.\\sqlexpr16; Initial Catalog=HazırlaVT; Persist Security Info=True; "
                //    + "user id=waleed; password=AbcXyz123;";

                string connStr = "User ID = waleed; Password = XyzAbc321; Server = localhost; Port = 5434; Database = turkexample2;"
                    + "Integrated Security = true; Pooling = true;";

                //optionsBuilder.UseSqlServer(BağlantıDizesi);
                optionsBuilder.UseNpgsql(connStr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
