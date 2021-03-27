using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class OrderViewModel
    {
        public OrderViewModel (int id, string username, int shoeCount, ShoeType shoeType, double shoeSize, double orderPrice)
        {
            Id = id;
            Username = username;
            ShoeSize = shoeSize;
            ShoeType = shoeType;
            ShoeSize = shoeSize;
            OrderPrice = orderPrice;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int ShoeCount { get; set; }
        public ShoeType ShoeType { get; set; }
        public double ShoeSize { get; set; }
        public double OrderPrice { get; set; }
    }
}
