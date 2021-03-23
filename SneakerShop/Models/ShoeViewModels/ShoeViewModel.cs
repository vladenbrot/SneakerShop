using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models.ShoeViewModels
{
    public class ShoeViewModel
    {
        public ShoeViewModel (int id, int amountInStore, bool isOnSale, double price, bool isNewRelease, ShoeType type, double size)
        {
            Id = id;
            AmountInStore = amountInStore;
            IsOnSale = isOnSale;
            Type = type;
            Price = price;
            IsNewRelease = isNewRelease;
            Size = size;
        }

        public ShoeViewModel()
        {

        }

        public int Id { get; set; }
        public int AmountInStore { get; set; }
        public bool IsOnSale { get; set; }
        public double Price { get; set; }
        public bool IsNewRelease { get; set; }
        public ShoeType Type { get; set; }
        public double Size { get; set; }
    }
}
