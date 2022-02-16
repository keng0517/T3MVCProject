using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class OrderRepo : IRepo<int, Order>
    {
        private readonly T3ShopContext _context;
        public OrderRepo(T3ShopContext context)
        {
            _context = context;
        }
        public bool Add(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
            return true;
        }

        public Order Get(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        public Order GetById(int userId) //GetByUserId
        {
            Order order = _context.Orders.FirstOrDefault(x => x.UserId == userId);
            return order;
        }

        public ICollection<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public bool Remove(int id)
        {
            Order order = Get(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Order item)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.OrderId == item.OrderId);
            if (order != null)
            {
                order.UserId = item.UserId;
                order.OrderDate = item.OrderDate;
                order.TotalAmount = item.TotalAmount;
                order.Status = item.Status;
                order.DeliveryId = item.DeliveryId;
                _context.Orders.Update(order);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

    }
}
