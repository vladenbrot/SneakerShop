using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Data.Entities
{
    public class Shoe
    {
        public Shoe(int id, int amountInStore, bool isOnSale, double price, bool isNewRelease, ShoeType shoeType, double size)
        {
            Id = id;
            AmountInStore = amountInStore;
            IsOnSale = isOnSale;
            Price = price;
            IsNewRelease = isNewRelease;
            Size = size;
        }

        public int Id { get; set; }
        public int AmountInStore { get; set; }
        public bool IsOnSale { get; set; }
        public double Price { get; set; }
        public bool IsNewRelease { get; set; }
        public ShoeType ShoeType { get; set; }
        public double Size { get; set; }
    }
}
