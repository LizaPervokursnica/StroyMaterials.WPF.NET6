using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StroyMaterials.Model;
using System;
using System.IO;

namespace StroyMaterials.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoint { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductAmount> ProductAmount { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла
            builder.AddJsonFile("DataAccess/connectionString.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("MaterialsDataSource");

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
