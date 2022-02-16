using Microsoft.Data.SqlClient;
using T3MVCProject.Exceptions;
using T3MVCProject.Models;

namespace T3MVCProject.Services
{
    public class UserRepo : IRepo<string, User>
    {
        private readonly T3ShopContext _context;

        public UserRepo()
        {

        }

        public UserRepo(T3ShopContext context)
        {
            _context = context;
        }





        public User Add(User item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                //update here later, compare to each record username
                if ((e.InnerException as SqlException).Number == 2601)
                {
                    throw new UsernameDuplicateException();
                }
            }
            return null;
        }






        public User Get(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }








        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }





        public bool Remove(string username)
        {
            throw new NotImplementedException();
        }





        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
