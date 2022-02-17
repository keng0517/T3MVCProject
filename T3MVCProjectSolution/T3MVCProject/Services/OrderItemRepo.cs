using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class OrderItemRepo : IRepo<int, OrderItem>
    {
        private readonly T3ShopContext _context;
        public OrderItemRepo(T3ShopContext context)
        {
            _context = context;
        }
        public bool Add(OrderItem item)
        {
            _context.OrderItems.Add(item);
            _context.SaveChanges();
            return true;
        }

        public OrderItem Get(int id)
        {
            OrderItem orderItem = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == id);
            return orderItem;
        }

        public OrderItem GetById(int orderId) //GetByUserId
        {
            OrderItem orderItem = _context.OrderItems.FirstOrDefault(x => x.OrderId == orderId);
            return orderItem;
        }

        public ICollection<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public bool Remove(int id)
        {
            OrderItem orderItem = Get(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(OrderItem item)
        {
            OrderItem orderItem = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == item.OrderItemId);
            if (orderItem != null)
            {
                orderItem.OrderId = item.OrderId;
                orderItem.ProductId = item.ProductId;
                orderItem.Quantity = item.Quantity;
                orderItem.Price = item.Price;
                _context.OrderItems.Update(orderItem);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public ICollection<OrderItem> GetSpecific(int k)
        {
            throw new NotImplementedException();
        }

        OrderItem IRepo<int, OrderItem>.Add(OrderItem item)
        {
            throw new NotImplementedException();
        }

        OrderItem IAdding<int, OrderItem>.Add(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
