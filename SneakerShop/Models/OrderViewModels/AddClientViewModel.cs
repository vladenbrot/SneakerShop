using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models.OrderViewModels
{
    public class AddClientViewModel
    {
        public AddClientViewModel(int orderId, int shoeCount)
        {
            OrderId = orderId;
            ShoeCount = shoeCount;
        }

        public AddClientViewModel()
        {

        }

        public int OrderId { get; set; }

        public int ShoeCount { get; set; }

        public IEnumerable<Client> People { get; set; }
    }
}
