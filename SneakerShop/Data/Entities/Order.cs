using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Shoe Shoe { get; set; }
        public int ShoeCount { get; set; }
        public ShoeType ShoeType { get; set; }
        public double OrderPrice { get; set; }
        public ICollection<ClientOrders> ClientsOrders { get; set; }
    }
}
