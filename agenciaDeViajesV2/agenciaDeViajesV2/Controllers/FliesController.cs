using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agenciaDeViajesV2.Data;
using agenciaDeViajesV2.Models;

namespace agenciaDeViajesV2.Controllers
{
    public class FliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flies.ToListAsync());
        }

        // GET: Flies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flyClass = await _context.Flies
                .FirstOrDefaultAsync(m => m.PK_fly == id);
            if (flyClass == null)
            {
                return NotFound();
            }

            return View(flyClass);
        }

        // GET: Flies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_fly,airline,sailsIn,arrivesIn,sailsAt,arrivesExpected,pricePerSeat,createdAt,updatedAt,states")] FlyClass flyClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flyClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flyClass);
        }

        // GET: Flies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flyClass = await _context.Flies.FindAsync(id);
            if (flyClass == null)
            {
                return NotFound();
            }
            return View(flyClass);
        }

        // POST: Flies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_fly,airline,sailsIn,arrivesIn,sailsAt,arrivesExpected,pricePerSeat,createdAt,updatedAt,states")] FlyClass flyClass)
        {
            if (id != flyClass.PK_fly)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flyClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlyClassExists(flyClass.PK_fly))
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
            return View(flyClass);
        }

        // GET: Flies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flyClass = await _context.Flies
                .FirstOrDefaultAsync(m => m.PK_fly == id);
            if (flyClass == null)
            {
                return NotFound();
            }

            return View(flyClass);
        }

        // POST: Flies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flyClass = await _context.Flies.FindAsync(id);
            if (flyClass != null)
            {
                _context.Flies.Remove(flyClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlyClassExists(int id)
        {
            return _context.Flies.Any(e => e.PK_fly == id);
        }
    }
}
