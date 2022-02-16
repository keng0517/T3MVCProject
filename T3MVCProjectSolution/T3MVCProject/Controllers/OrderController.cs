using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using T3MVCProject.Models;
using T3MVCProject.Services;

namespace T3MVCProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public IActionResult Index()
        {
            return View(_orderService.GetAllOrder());
        }

        public IActionResult Details(int id)
        {
            Order order = _orderService.GetOrderById(id);

            dynamic orderViewModel = new ExpandoObject();
            orderViewModel.Orders = order;
            orderViewModel.OrderItems = _orderService.GetAllOrderItem().Where(o => o.OrderId == order.OrderId);

            return View(orderViewModel);
        }
        //public IActionResult Edit(int id)
        //{
        //    Order order = _repo.Get(id);
        //    return View(order);
        //}

        //[HttpPost]
        //public IActionResult Edit(int id, Order order)
        //{
        //    _repo.Update(order);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Create()
        //{
        //    return View(new Order());
        //}

        //[HttpPost]
        //public IActionResult Create(Order order)
        //{
        //    _repo.Add(order);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    Order order = _repo.Get(id);
        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult Delete(int id, Order order)
        //{
        //    _repo.Remove(id);
        //    return RedirectToAction("Index");
        //}
    }
}
