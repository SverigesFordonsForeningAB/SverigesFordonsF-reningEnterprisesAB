using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SverigesFordonsFöreningEnterprisesAB.Models;

namespace SverigesFordonsFöreningEnterprisesAB.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.Cars).Include(o => o.Customer).Include(o => o.Motorcycles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Cars)
                .Include(o => o.Customer)
                .Include(o => o.Motorcycles)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["FkCarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarId");
            ViewData["FkCustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "FirstName");
            ViewData["FkMotorcycleId"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleId", "MotorcycleId");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,FkCustomerId,FkCarId,FkMotorcycleId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarId", order.FkCarId);
            ViewData["FkCustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "FirstName", order.FkCustomerId);
            ViewData["FkMotorcycleId"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleId", "MotorcycleId", order.FkMotorcycleId);
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["FkCarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarId", order.FkCarId);
            ViewData["FkCustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "FirstName", order.FkCustomerId);
            ViewData["FkMotorcycleId"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleId", "MotorcycleId", order.FkMotorcycleId);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,FkCustomerId,FkCarId,FkMotorcycleId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarId", order.FkCarId);
            ViewData["FkCustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "FirstName", order.FkCustomerId);
            ViewData["FkMotorcycleId"] = new SelectList(_context.Set<Motorcycle>(), "MotorcycleId", "MotorcycleId", order.FkMotorcycleId);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Cars)
                .Include(o => o.Customer)
                .Include(o => o.Motorcycles)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
