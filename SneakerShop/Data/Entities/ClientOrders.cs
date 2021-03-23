using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Data.Entities
{
    public class ClientOrders
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
