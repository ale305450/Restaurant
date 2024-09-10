using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.Order;

namespace Restaurant.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            var orders = await _orderService.GetOrders();
            return View(orders);
        }

        // GET: OrderController
        public async Task<ActionResult> UserOrders()
        {
            string userId ="";
            var orders = await _orderService.GetUserOrders(userId);
            return View(orders);
        }

        // GET: OrderController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOrderVM order)
        {
            try
            {
                var response = await _orderService.CreateOrder(order);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(order);

        }

        // POST: OrderController/ChangeOrderStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeOrderStatus(int id, ChangeOrderStatusVM orderStatus)
        {
            try
            {
                var response = await _orderService.ChangeOrderStatus(id, orderStatus);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(orderStatus);
        }
        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _orderService.DeleteOrder(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
