using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class EditOrderViewModel
    {
        public EditOrderViewModel(int id, int shoeCount, ShoeType shoeType, Shoe shoe, double orderPrice)
        {
            Id = id;
            ShoeCount = shoeCount;
            ShoeType = shoeType;
            Shoe = shoe;
            OrderPrice = orderPrice;
        }

        public EditOrderViewModel(int id)
        {

        }

        public EditOrderViewModel()
        {

        }

        public int Id { get; set; }

        public int ShoeCount { get; set; }

        public ShoeType ShoeType { get; set; }

        public Shoe Shoe { get; set; }

        public double OrderPrice { get; set; }
    }
}
