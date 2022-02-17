using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly T3ShopContext _context;
        public ProductRepo(T3ShopContext context)
        {
            _context = context;
        }

        public Product Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Product Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            return product;
        }



        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetSpecific(int k)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            Product product = Get(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Product item)
        {
            Product product = _context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (product != null)
            {
                product.Name = item.Name;
                product.Category = item.Category;
                product.Price = item.Price;
                product.Qty = item.Qty;
                product.Pic = item.Pic;
                product.Description = item.Description;
                product.Status = item.Status;
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
