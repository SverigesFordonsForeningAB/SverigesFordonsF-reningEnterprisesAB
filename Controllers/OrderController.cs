using Microsoft.AspNetCore.Mvc;
using SverigesFordonsFöreningEnterprisesAB.Models;
using SverigesFordonsFöreningEnterprisesAB.Services;

namespace SverigesFordonsFöreningEnterprisesAB.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApiService _apiService;
       public OrderController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _apiService.GetOrderAsync();
            if (order == null || !order.Any())
            {
                return View(new List<Order>());
            }
            return View(order);
        }
    }
}
