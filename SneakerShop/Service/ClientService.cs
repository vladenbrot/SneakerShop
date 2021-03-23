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
    public class ClientService : IClientService
    {
        private SneakerShopDbContext dbContext;

        public ClientService(SneakerShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string firstName, string lastName, string telephone, string email, string gender)
        {
            var newClient = new Client(
                firstName,
                lastName,
                telephone,
                email,
                gender);

            this.dbContext.Add(newClient);
            this.dbContext.SaveChanges();
        }

        public void Delete(int clientId)
        {
            var client = GetById(clientId);
            foreach (var clientOrder in client.ClientsOrders)
            {
                var order = this.dbContext.Orders.Find(clientOrder.OrderId);
                order.ClientsOrders.Remove(clientOrder);
            }

            client.ClientsOrders = new List<ClientOrders>();
            this.dbContext.Clients.Remove(client);
            this.dbContext.SaveChanges();
        }
        
        public void Edit(int id, string firstName, string lastName, string telephone, string email, string gender)
        {
            var client = GetById(id);

            client.FirstName = firstName;
            client.LastName = lastName;
            client.Telephone = telephone;
            client.Email = email;
            client.Gender = gender;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return this.dbContext.Clients.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
        }

        public Client GetById(int id)
        {
            var clients = this.dbContext.Clients.Include(x => x.ClientsOrders).ToList();
            return clients.FirstOrDefault(x => x.Id == id);
        }
    }
}
