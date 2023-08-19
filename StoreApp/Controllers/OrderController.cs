using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        public readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("","Sorry, your cart is empty.");
            }
            if(ModelState.IsValid)
            {
                order.Lines = _cart.Lines;
                _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new {OrderId = order.OrderId});
            }
            else
            {
                return View();
            }
        }
    }
}