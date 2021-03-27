using SneakerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class CreateShoeViewModel
    {
        public int Id { get; set; }
        public int AmountInStore { get; set; }
        public ShoeType Type { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
    }
}
