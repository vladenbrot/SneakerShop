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
    public class OrderService : IOrderService
    {
        private SneakerShopDbContext dbContext;

        public OrderService(SneakerShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public void AddClients(List<Client> clients, int orderId)
        {
            var order = GetById(orderId);

            foreach (var client in clients)
            {
                var clientOrder = new ClientOrders()
                {
                    ClientId = client.Id,
                    Client = client,
                    OrderId = orderId,
                    Order = order
                };

                client.ClientsOrders.Add(clientOrder);
                order.ClientsOrders.Add(clientOrder);
            }

            this.dbContext.SaveChanges();
        }

        public void Create(int id, double orderPrice, int shoeCount, Shoe shoe, ShoeType shoeType)
        {

            var order = new Order()
            {
                Id = id,
                OrderPrice = orderPrice,
                ShoeCount = shoeCount,
                Shoe = shoe,
                ShoeType = shoeType
            };

            this.dbContext.Add(order);
            this.dbContext.SaveChanges();
        }

        public void Delete(int orderId)
        {
            var order = GetById(orderId);
            RemoveClient(order);
            this.dbContext.Orders.Remove(order);
            this.dbContext.SaveChanges();

        }

        public void Edit(int id, double OrderPrice, int shoeCount, Shoe shoe, ShoeType shoeType)
        {
            var order = GetById(id);
            order.Shoe = shoe;
            order.ShoeType = shoeType;

            this.dbContext.SaveChanges();

        }

        public IEnumerable<Order> GetAll()
        {
            return this.dbContext.Orders.Include(x => x.Shoe).Include(x => x.ClientsOrders);
        }

        public Order GetById(int id)
        {
            var orders = this.dbContext.Orders.Include(x => x.Shoe).Include(x => x.ClientsOrders).ToList();
            return orders.FirstOrDefault(x => x.Id == id);
        }

        private void RemoveClient(Order order)
        {
            foreach (var clientOrder in order.ClientsOrders)
            {
                var client = this.dbContext.Clients.Find(clientOrder.ClientId);
                client.ClientsOrders.Remove(clientOrder);
            }
            order.ClientsOrders = new List<ClientOrders>();
        }
    }
}
