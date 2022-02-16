using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public interface IOrderService
    {
        #region Order
        ICollection<Order> GetAllOrder();
        Order GetOrderById(int orderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);

        #endregion

        #region OrderItem
        ICollection<OrderItem> GetAllOrderItem();
        OrderItem GetOrderItemById(int orderItemId);
        OrderItem GetOrderItemByOrderId(int orderId);
        void InsertOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(OrderItem orderItem);
        #endregion
    }
}
