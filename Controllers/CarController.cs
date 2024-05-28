using Microsoft.AspNetCore.Mvc;
using SverigesFordonsFöreningEnterprisesAB.Models;
using SverigesFordonsFöreningEnterprisesAB.Services;

namespace SverigesFordonsFöreningEnterprisesAB.Controllers
{
    public class CarController : Controller
    {
        public readonly ApiService _apiService;
        public CarController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var car = await _apiService.GetCarAsync();
            if (car == null || !car.Any())
            {
                Console.WriteLine("No cars found in the database or API service returned null.");
                return View(new List<Car>());
            }

            return View(car);
        }
        // Get: Car/create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Car/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _apiService.AddCarAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
        // Show a form to get an car
        ////// GET: Car/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _apiService.GetCarByIdAsync(id);
            return View(car);
        }
        ////// Uppdate an car
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateCarAsync(id, car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
        // Get details for car
        public async Task<IActionResult> Details(int id)
        {
            var car = await _apiService.GetCarByIdAsync(id);
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _apiService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();
            return View(car);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteCarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

