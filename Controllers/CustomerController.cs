using Microsoft.AspNetCore.Mvc;
using SverigesFordonsFöreningEnterprisesAB.Models;
using SverigesFordonsFöreningEnterprisesAB.Services;

namespace SverigesFordonsFöreningEnterprisesAB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApiService _apiService;
        public CustomerController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _apiService.GetCustomersAsync();
            if (customers == null || !customers.Any())
            {
                return View(new List<Customer>());
            }

            return View(customers);
        }
        // Get: Customer/create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Emploees/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _apiService.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        // Show a form to get an customer
        ////// GET: Customer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _apiService.GetCustomerByIdAsync(id);
            return View(customer);
        }
        ////// Uppdate an customer
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateCustomerAsync(id, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        // Get details for customer
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _apiService.GetCustomerByIdAsync(id);
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _apiService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeletCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

