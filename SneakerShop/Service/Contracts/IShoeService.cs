using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Service.Contracts
{
    public interface IShoeService
    {
        void Create(int id, int amountInStore, double price, ShoeType shoeType, double size);

        void Delete(int shoeId);

        void Edit(int id, int amountInStore, double price, ShoeType shoeType, double size);

        IEnumerable<Shoe> GetAll();

        Shoe GetById(int id);
    }
}
