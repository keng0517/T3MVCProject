using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class ShopperRepo : IRepo<int, Shopper>
    {
        private readonly T3ShopContext _context;

        //Taking the context object as injection
        public ShopperRepo(T3ShopContext context)
        {
            _context = context;
        }



        public Shopper Add(Shopper item)
        {
            _context.Shoppers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Shopper Get(int username)
        {
            throw new NotImplementedException();
        }

        public ICollection<Shopper> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shopper GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Shopper> GetSpecific(int k)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int username)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shopper item)
        {
            throw new NotImplementedException();
        }
    }
}
