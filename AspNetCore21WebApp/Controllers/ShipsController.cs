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
    public class ShipsController : Controller
    {
        private readonly AspNetCore21DbContext _context;

        public ShipsController(AspNetCore21DbContext context)
        {
            _context = context;
        }

        // GET: Ships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ships.ToListAsync());
        }

        // GET: Ships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: Ships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipId,ShipName,NumberOfPassangers,CreatedAt,ModifiedAt,CreatedBy,ModifiedBy")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ship);
        }

        // GET: Ships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            return View(ship);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipId,ShipName,NumberOfPassangers,CreatedAt,ModifiedAt,CreatedBy,ModifiedBy")] Ship ship)
        {
            if (id != ship.ShipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.ShipId))
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
            return View(ship);
        }

        // GET: Ships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(int id)
        {
            return _context.Ships.Any(e => e.ShipId == id);
        }
    }
}
