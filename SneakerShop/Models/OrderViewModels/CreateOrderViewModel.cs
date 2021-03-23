using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public int ShoeCount { get; set; }
        public ShoeType Type { get; set; }
        public IEnumerable<Shoe> Shoes { get; set; }
        public double OrderPrice { get; set; }
    }
}
