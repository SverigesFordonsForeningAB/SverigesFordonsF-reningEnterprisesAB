﻿using Microsoft.AspNetCore.Mvc;
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
        // Get: Orders/create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Orders/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await _apiService.AddOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        // Show a form to get an order
        ////// GET: order/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _apiService.GetOrderByIdAsync(id);
            return View(order);
        }
        ////// Uppdate an order
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateOrderAsync(id, order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        // Get details for orders
        public async Task<IActionResult> Details(int id)
        {
            var order = await _apiService.GetOrderByIdAsync(id);
            return View(order);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _apiService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

