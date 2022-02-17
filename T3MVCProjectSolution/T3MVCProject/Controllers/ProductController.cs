using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using T3MVCProject.Models;
using T3MVCProject.Services;

namespace T3MVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;
        private readonly IRepo<int, ShoppingCartItem> _cartRepo;
        public ProductController(IRepo<int, Product> repo, IRepo<int, ShoppingCartItem> cartRepo)
        {
            _repo = repo;
            _cartRepo = cartRepo;
        }
        public IActionResult IndexAdmin()
        {
            return View(_repo.GetAll());
        }
        public IActionResult IndexShopper()
        {
            return View(_repo.GetAll());
        }
        public IActionResult DetailsAdmin(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        public IActionResult DetailsShopper(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        public IActionResult Create()
        {
            ViewBag.Category = GetProductCategories();
            //ViewBag.Pic = GetProductPic();
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile file)
        {
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

            if (file != null)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName);

                using (var stream = new FileStream(pathToSave, FileMode.Create))
                {
                    file.CopyTo(stream);
                    product.Pic = "/img/" + ImageName;
                }
                _repo.Add(product);
                return RedirectToAction("IndexAdmin");
            }

            return RedirectToAction("Create");

        }
        public IActionResult Edit(int id)
        {
            Product product = _repo.Get(id);
            ViewBag.Category = GetProductCategories();
            //ViewBag.Pic = GetProductPic();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult QtyOfProduct(int Quantity, Product product)
        {
            int userId = 1;   //get session
            int qty = Quantity;   //put to session
            int productId = product.ProductId;   //put to session
            double price = product.Price;

            ICollection<ShoppingCartItem> items = _cartRepo.GetSpecific(userId);
            foreach (var item in items)
            {
                if (item.ProductId == productId)
                {
                    item.Qty = item.Qty + qty;
                    item.Amount = price * item.Qty;
                    _cartRepo.Update(item);
                }
                else
                {
                    ShoppingCartItem newItem = new ShoppingCartItem();
                    newItem.ProductId = productId;
                    newItem.Qty = qty;
                    newItem.Amount = price * qty;
                    newItem.UserId = userId;
                    
                    _cartRepo.Add(newItem);
                }
            }

            return RedirectToAction("ViewCart", "Cart");
        }

        IEnumerable<SelectListItem> GetProductCategories()
        {
            List<SelectListItem> category = new List<SelectListItem>();
            category.Add(new SelectListItem { Text = "Bakery and Bread", Value = "Bakery and Bread" });
            category.Add(new SelectListItem { Text = "Seafood", Value = "Seafood" });
            category.Add(new SelectListItem { Text = "Meat", Value = "Meat" });
            category.Add(new SelectListItem { Text = "Pasta and Rice", Value = "Pasta and Rice" });
            category.Add(new SelectListItem { Text = "Oils, Sauces and Condiments", Value = "Oils, Sauces and Condiments" });
            category.Add(new SelectListItem { Text = "Cereals and Breakfast Foods", Value = "Cereals and Breakfast Foods" });
            category.Add(new SelectListItem { Text = "Soups and Canned Goods", Value = "Soups and Canned Goods" });
            category.Add(new SelectListItem { Text = "Frozen Foods", Value = "Frozen Foods" });
            category.Add(new SelectListItem { Text = "Dairy", Value = "Dairy" });

            return category;
        }
    }
}
