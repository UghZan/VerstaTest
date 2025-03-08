using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VerstaMain.Models;
using VerstaMain.Services;

namespace VerstaMain.Controllers
{
    [Route("home")]
    [Route("")]
    public class HomeController : Controller
    {
        private OrderService orderService;

        public HomeController(OrderService _orderService)
        {
            orderService = _orderService;
        }

        [Route("{controller=Home}/{action=Index}")]
        public async Task<IActionResult> Index()
        {
            var number = await orderService.GetOrderCount();
            ViewBag.OrderNumber = number;
            return View();
        }
        [Route("AddOrder")]
        public IActionResult AddOrder()
        {
            return View();
        }
        [Route("AddOrder")]
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderModel model)
        {
            var id = await orderService.AddOrder(model);
            ViewBag.LastOrderId = id;
            return RedirectToAction(nameof(ListOrders));
        }
        [Route("ListOrders")]
        public async Task<IActionResult> ListOrders()
        {
            var orders = await orderService.GetOrders();
            return View(orders);
        }
        [Route("ViewOrder")]
        public async Task<IActionResult> ViewOrder(Guid id)
        {
            GetOrderModel order;
            try
            {
                order = await orderService.GetOrderByID(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(ShowError), new { message = ex.Message });
            }
            return View(order);
        }

        [Route("ShowError")]
        public IActionResult ShowError(string message)
        {
            return View((object)message);
        }
    }
}
