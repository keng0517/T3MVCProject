using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepo<int, Order> _orderRepo;
        private readonly IRepo<int, OrderItem> _orderItemRepo;

        public OrderService(IRepo<int, Order> orderRepo,
            IRepo<int, OrderItem> orderItemRepo)
        {
            this._orderRepo = orderRepo;
            this._orderItemRepo = orderItemRepo;
        }
        #region Order
        public ICollection<Order> GetAllOrder()
        {
            return _orderRepo.GetAll().ToList();
        }

        public Order GetOrderById(int orderId)
        {
            Order order = _orderRepo.Get(orderId);
            return order;
        }

        public void InsertOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("Order");

            _orderRepo.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("Order");

            _orderRepo.Update(order);
        }
        public void DeleteOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("Order");

            _orderRepo.Remove(order.OrderId);
        }

        #endregion

        #region OrderItem
        public ICollection<OrderItem> GetAllOrderItem()
        {
            return _orderItemRepo.GetAll().ToList();
        }

        public OrderItem GetOrderItemById(int orderItemId)
        {
            OrderItem orderItem = _orderItemRepo.Get(orderItemId);
            return orderItem;
        }

        public OrderItem GetOrderItemByOrderId(int orderId)
        {
            OrderItem orderItem = _orderItemRepo.GetById(orderId);
            return orderItem;
        }

        public void InsertOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException("OrderItem");

            _orderItemRepo.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException("OrderItem");

            _orderItemRepo.Update(orderItem);
        }
        public void DeleteOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException("OrderItem");

            _orderItemRepo.Remove(orderItem.OrderItemId);
        }


        #endregion


    }
}
