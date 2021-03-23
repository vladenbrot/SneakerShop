using Microsoft.EntityFrameworkCore;
using SneakerShop.Data;
using SneakerShop.Data.Entities;
using SneakerShop.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Service
{
    public class ShoeService : IShoeService
    {
        private SneakerShopDbContext dbContext;

        public ShoeService(SneakerShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(int id, int amountInStore, double price, ShoeType shoeType, double size)
        {
            var newShoe = new Shoe(
                id,
                amountInStore,
                true,
                price,
                true,
                shoeType,
                size);

            this.dbContext.Shoes.Add(newShoe);
            this.dbContext.SaveChanges();
        }

        public void Delete(int shoeId)
        {
            var shoe = GetById(shoeId);

            foreach (var order in this.dbContext.Orders.Include(x => x.Shoe).Include(x => x.ClientsOrders))
            {
                if (order.Shoe == shoe)
                {
                    foreach (var clientOrder in order.ClientsOrders)
                    {
                        var client = this.dbContext.Clients.Find(clientOrder.ClientId);
                        client.ClientsOrders = new List<ClientOrders>();
                    }
                    this.dbContext.Orders.Remove(order);
                }
            }

            this.dbContext.Shoes.Remove(shoe);
            this.dbContext.SaveChanges();
        }

        public void Edit(int id, int amountInStore, double price, ShoeType shoeType, double size)
        {
            var shoe = GetById(id);

            shoe.Id = id;
            shoe.AmountInStore = amountInStore;
            shoe.Price = price;
            shoe.ShoeType = shoeType;
            shoe.Size = size;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Shoe> GetAll()
        {
            return this.dbContext.Shoes.OrderBy(x => x.Size).ThenBy(x => x.ShoeType).ThenBy(x => x.AmountInStore).ToList();
        }

        public Shoe GetById(int id)
        {
            return this.dbContext.Shoes.Find(id);
        }
    }
}
