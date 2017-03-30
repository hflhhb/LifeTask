using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LLY.LifeTask.Service;
using LLY.LifeTask.Model.Life;

namespace LLY.LifeTask.Office.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISaleOrderService _orderSvr = null;
        public HomeController(ISaleOrderService orderSvr)
        {
            _orderSvr = orderSvr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        //public IActionResult OrderList()
        //{
        //    return View();
        //}
        public async Task<IActionResult> OrderList()
        {
            var model = await _orderSvr.GetOrdersAsync();

            return View(model);
        }

        public IActionResult OrderListDapper()
        {
            var model = _orderSvr.GetOrders();
            //
            return View("OrderList", model);
        }
    }
}
