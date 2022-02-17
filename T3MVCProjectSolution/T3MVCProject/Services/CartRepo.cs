using T3MVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace T3MVCProject.Services
{
    public class CartRepo : IRepo<int, ShoppingCartItem>
    {
        private readonly T3ShopContext _context;
        public CartRepo(T3ShopContext context)
        {
            _context = context;
        }
        public ShoppingCartItem Add(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ICollection<ShoppingCartItem> GetSpecific(int id)
        {
            return _context.ShoppingCartItems.Include(x => x.Product).Where(x => x.UserId == id).ToList();

        }

        public ICollection<ShoppingCartItem> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<ShoppingCartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            ShoppingCartItem shoppingCartItem = Get(id);
            _context.ShoppingCartItems.Remove(shoppingCartItem);
            _context.SaveChanges();
            return true;
        }

        public bool Update(ShoppingCartItem item)
        {
            ShoppingCartItem shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.UserId == item.UserId);
            if (shoppingCartItem != null)
            {
                shoppingCartItem.Qty = item.Qty;
                shoppingCartItem.Amount = item.Amount;

                _context.ShoppingCartItems.Update(shoppingCartItem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ShoppingCartItem Get(int id)
        {
            ShoppingCartItem shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);
            return shoppingCartItem;
        }

        public ShoppingCartItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
