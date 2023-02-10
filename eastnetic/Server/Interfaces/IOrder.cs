using eastnetic.Shared.Model;

namespace eastnetic.Server.Interfaces
{
    public interface IOrder
    {
        public List<OrderDto> GetOrderDetails();

        public void AddOrder(OrderDto Order);

        public void UpdateOrderDetails(OrderDto Order);

        public OrderDto GetOrderData(int id);

        public void DeleteOrder(int id);
    }
}