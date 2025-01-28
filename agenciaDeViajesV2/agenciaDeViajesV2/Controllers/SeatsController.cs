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
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seats.Include(s => s.Fly).Include(s => s.Offer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatClass = await _context.Seats
                .Include(s => s.Fly)
                .Include(s => s.Offer)
                .FirstOrDefaultAsync(m => m.PK_seat == id);
            if (seatClass == null)
            {
                return NotFound();
            }

            return View(seatClass);
        }

        // GET: Seats/Create
        public IActionResult Create()
        {
            ViewData["FK_fly"] = new SelectList(_context.Flies, "PK_fly", "airline");
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny");
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_seat,FK_fly,FK_offer,seatNumber,reserState,createdAt,updatedAt,states")] SeatClass seatClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_fly"] = new SelectList(_context.Flies, "PK_fly", "airline", seatClass.FK_fly);
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", seatClass.FK_offer);
            return View(seatClass);
        }

        // GET: Seats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatClass = await _context.Seats.FindAsync(id);
            if (seatClass == null)
            {
                return NotFound();
            }
            ViewData["FK_fly"] = new SelectList(_context.Flies, "PK_fly", "airline", seatClass.FK_fly);
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", seatClass.FK_offer);
            return View(seatClass);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_seat,FK_fly,FK_offer,seatNumber,reserState,createdAt,updatedAt,states")] SeatClass seatClass)
        {
            if (id != seatClass.PK_seat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seatClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatClassExists(seatClass.PK_seat))
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
            ViewData["FK_fly"] = new SelectList(_context.Flies, "PK_fly", "airline", seatClass.FK_fly);
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", seatClass.FK_offer);
            return View(seatClass);
        }

        // GET: Seats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatClass = await _context.Seats
                .Include(s => s.Fly)
                .Include(s => s.Offer)
                .FirstOrDefaultAsync(m => m.PK_seat == id);
            if (seatClass == null)
            {
                return NotFound();
            }

            return View(seatClass);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seatClass = await _context.Seats.FindAsync(id);
            if (seatClass != null)
            {
                _context.Seats.Remove(seatClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatClassExists(int id)
        {
            return _context.Seats.Any(e => e.PK_seat == id);
        }
    }
}
