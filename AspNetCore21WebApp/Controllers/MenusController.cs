using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCore21WebApp.Data;
using AspNetCore21WebApp.Models;

namespace AspNetCore21WebApp.Controllers
{
    public class MenusController : Controller
    {
        private readonly AspNetCore21DbContext _context;

        public MenusController(AspNetCore21DbContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.Include(m => m.Restaurant).ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewBag.RestaurantList = GetRestaurantList(null);

            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,MenuName,CreatedAt,ModifiedAt,ApprovedAt,CreatedBy,ModifiedBy,ApprovedBy,RestaurantId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RestaurantList = GetRestaurantList(menu.RestaurantId);

            return View(menu);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            ViewBag.RestaurantList = GetRestaurantList(menu.RestaurantId);

            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,MenuName,CreatedAt,ModifiedAt,ApprovedAt,CreatedBy,ModifiedBy,ApprovedBy,RestaurantId")] Menu menu)
        {
            if (id != menu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuId))
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

            ViewBag.RestaurantList = GetRestaurantList(menu.RestaurantId);

            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #region *** Helper methods ********************************************
        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }

        private SelectList GetRestaurantList(int? restaurantId)
        {
            //TODO 2020-03-08 - Rewrite using LINQ and include ship name
            if (restaurantId.HasValue)
            {
                return new SelectList(_context.Restaurants.OrderBy(r => r.RestaurantName), "RestaurantId", "RestaurantName", restaurantId.Value);
            }
            else
            {
                return new SelectList(_context.Restaurants.OrderBy(r => r.RestaurantName), "RestaurantId", "RestaurantName");
            }
        }
        #endregion
    }
}
