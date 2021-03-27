using SneakerShop.Data.Entities;

namespace SneakerShop.Controllers
{
    internal class OrderDetailsViewModels
    {
        private int id;
        private Shoe shoe;
        private int shoeCount;
        private ShoeType shoeType;
        private double orderPrice;

        public OrderDetailsViewModels(int id, Shoe shoe, int shoeCount, ShoeType shoeType, double orderPrice)
        {
            this.id = id;
            this.shoe = shoe;
            this.shoeCount = shoeCount;
            this.shoeType = shoeType;
            this.orderPrice = orderPrice;
        }
    }
}