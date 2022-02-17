using Microsoft.AspNetCore.Mvc;
using T3MVCProject.Models;
using T3MVCProject.Services;

namespace T3MVCProject.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepo<int, ShoppingCartItem> _repo;

        public CartController(IRepo<int, ShoppingCartItem> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            //userid take from session, might not need to take in as parameter
            int userId = 1;   //harcode for now

            return View(_repo.GetSpecific(userId));

        }


        [HttpPost]
        public IActionResult Checkout(int[] ids, string command)
        {

            if (command.Equals("Checkout"))
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    //ids[i]
                    //add this entire row(using product id and user id) to order item table
                    //then delete this row at the end of payment transaction
                }
            }
            else
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    _repo.Remove(ids[i]);
                }
            }

            return RedirectToAction("ViewCart", "Cart");   //to be changed: should be redirected to confirm order page
        }

        [HttpPost]
        public IActionResult DeleteSelectedItems(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                _repo.Remove(ids[i]);
            }
            return RedirectToAction("ViewCart", "Cart");
        }
    }
}
