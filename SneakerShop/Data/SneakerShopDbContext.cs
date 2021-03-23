using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient.Memcached;
using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Data
{
    public class SneakerShopDbContext : IdentityDbContext<Entities.Client, IdentityRole<int>, int>
    {
        public DbSet<Entities.Client> Clients { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ClientOrders> ClientOrders { get; set; }

        public SneakerShopDbContext(DbContextOptions options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientOrders>(cr =>
            {
                cr.HasKey(x => new { x.ClientId, x.OrderId });
            });
        }
    }
}
