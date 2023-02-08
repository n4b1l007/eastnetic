using eastnetic.Shared.Model;

namespace eastnetic.Server.Interfaces
{
    public interface IOrder
    {
        public List<Order> GetOrderDetails();

        public void AddOrder(Order Order);

        public void UpdateOrderDetails(Order Order);

        public Order GetOrderData(int id);

        public void DeleteOrder(int id);
    }
}