using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Service.Contracts
{
    public interface IOrderService
    {

        void Create(int id, double OrderPrice, int shoeCount, Shoe shoe, ShoeType shoeType);

        void Edit(int id, double OrderPrice, int shoeCount, Shoe shoe, ShoeType shoeType);

        void Delete(int orderId);

        void AddClients(List<Client> clients, int orderId);

        IEnumerable<Order> GetAll();

        Order GetById(int id);
    }
}
