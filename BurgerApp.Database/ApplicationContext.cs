using BurgerApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodIngridient> FoodIngridients { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string serverName = "stud-mssql.sttec.yar.ru,38325";
            string dbName = "user35_db";
            string userId = "user35_db";
            string password = "user35";

            string connectionString = $"Server={serverName};Database={dbName};User Id={userId}; Password={password};TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
