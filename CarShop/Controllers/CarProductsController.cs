using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class CarProductsController : Controller
    {
        private readonly CarShopContext _context;

        public CarProductsController(CarShopContext context)
        {
            _context = context;
        }

        // GET: CarProducts
        public async Task<IActionResult> Index()
        {
            var carShopContext = _context.CarProducts.Include(c => c.Cat).Include(c => c.Dealer).Include(c => c.Owner);
            return View(await carShopContext.ToListAsync());
        }

        // GET: CarProducts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CarProducts == null)
            {
                return NotFound();
            }

            var carProduct = await _context.CarProducts
                .Include(c => c.Cat)
                .Include(c => c.Dealer)
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (carProduct == null)
            {
                return NotFound();
            }

            return View(carProduct);
        }

        // GET: CarProducts/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.CarCategories, "CatId", "CatId");
            ViewData["DealerId"] = new SelectList(_context.CarDealers, "DealerId", "DealerId");
            ViewData["OwnerId"] = new SelectList(_context.CarStoreOwners, "OwnerId", "OwnerId");
            return View();
        }

        // POST: CarProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarName,CarDetail,CarImage,CatId,Carprice,OwnerId,DealerId")] CarProduct carProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.CarCategories, "CatId", "CatId", carProduct.CatId);
            ViewData["DealerId"] = new SelectList(_context.CarDealers, "DealerId", "DealerId", carProduct.DealerId);
            ViewData["OwnerId"] = new SelectList(_context.CarStoreOwners, "OwnerId", "OwnerId", carProduct.OwnerId);
            return View(carProduct);
        }

        // GET: CarProducts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CarProducts == null)
            {
                return NotFound();
            }

            var carProduct = await _context.CarProducts.FindAsync(id);
            if (carProduct == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.CarCategories, "CatId", "CatId", carProduct.CatId);
            ViewData["DealerId"] = new SelectList(_context.CarDealers, "DealerId", "DealerId", carProduct.DealerId);
            ViewData["OwnerId"] = new SelectList(_context.CarStoreOwners, "OwnerId", "OwnerId", carProduct.OwnerId);
            return View(carProduct);
        }

        // POST: CarProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CarId,CarName,CarDetail,CarImage,CatId,Carprice,OwnerId,DealerId")] CarProduct carProduct)
        {
            if (id != carProduct.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarProductExists(carProduct.CarId))
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
            ViewData["CatId"] = new SelectList(_context.CarCategories, "CatId", "CatId", carProduct.CatId);
            ViewData["DealerId"] = new SelectList(_context.CarDealers, "DealerId", "DealerId", carProduct.DealerId);
            ViewData["OwnerId"] = new SelectList(_context.CarStoreOwners, "OwnerId", "OwnerId", carProduct.OwnerId);
            return View(carProduct);
        }

        // GET: CarProducts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CarProducts == null)
            {
                return NotFound();
            }

            var carProduct = await _context.CarProducts
                .Include(c => c.Cat)
                .Include(c => c.Dealer)
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (carProduct == null)
            {
                return NotFound();
            }

            return View(carProduct);
        }

        // POST: CarProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CarProducts == null)
            {
                return Problem("Entity set 'CarShopContext.CarProducts'  is null.");
            }
            var carProduct = await _context.CarProducts.FindAsync(id);
            if (carProduct != null)
            {
                _context.CarProducts.Remove(carProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarProductExists(string id)
        {
          return (_context.CarProducts?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
