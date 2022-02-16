using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using T3MVCProject.Models;
using T3MVCProject.Services;
using System.Diagnostics;

namespace T3MVCProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepo<string, User> _adding;
        private readonly IRepo<int, Shopper> _repo;
        private readonly LoginService _loginService;

        public UserController(IRepo<string, User> adding,
                                IRepo<int, Shopper> repo,
                               LoginService lservice)
        {
            _adding = adding;
            _repo = repo;
            _loginService = lservice;
        }


        public IActionResult Register()
        {
            ViewBag.Roles = GetUserRoles();
            ViewBag.Genders = GetGenders();
            return View(new UserShopper());
        }




        [HttpPost]
        public IActionResult Register(UserShopper userShopper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User();
                    Shopper shopper = new Shopper();
                    shopper = _repo.Add(shopper);

                    
                    user.ShopperId = shopper.ShopperId;
                    user.Username = userShopper.Username;
                    user.Password = userShopper.Password;
                    user.Email = userShopper.Email;
                    user.Phone = userShopper.Phone;
                    user.Role = userShopper.Role;
                    user.Address = userShopper.Address;
                    user.DOB = userShopper.DOB;
                    user.Gender = userShopper.Gender;

                    _adding.Add(user);

                    TempData.Add("un", user.Username);
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(userShopper, ex.Message);
                }

            }
            return RedirectToAction("Login");
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            var myuser = _loginService.LoginCheck(user);
            if (myuser == null)
                return View();
            HttpContext.Session.SetString("un", user.Username);


            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }




        //Initialize user roles
        IEnumerable<SelectListItem> GetUserRoles()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Admin", Value = "admin" });
            roles.Add(new SelectListItem { Text = "Shopper", Value = "shopper" });
            return roles;
        }

        //Initialize genders
        IEnumerable<SelectListItem> GetGenders()
        {
            List<SelectListItem> genders = new List<SelectListItem>();
            genders.Add(new SelectListItem { Text = "Male", Value = "male" });
            genders.Add(new SelectListItem { Text = "Female", Value = "female" });
            return genders;
        }
    }
}
