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
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rooms.Include(r => r.Hotel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomClass = await _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.PK_room == id);
            if (roomClass == null)
            {
                return NotFound();
            }

            return View(roomClass);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["FK_hotel"] = new SelectList(_context.Hotels, "PK_hotel", "addressAt");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_room,FK_hotel,pricePerNight,capacity,createdAt,updatedAt,states")] RoomClass roomClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_hotel"] = new SelectList(_context.Hotels, "PK_hotel", "addressAt", roomClass.FK_hotel);
            return View(roomClass);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomClass = await _context.Rooms.FindAsync(id);
            if (roomClass == null)
            {
                return NotFound();
            }
            ViewData["FK_hotel"] = new SelectList(_context.Hotels, "PK_hotel", "addressAt", roomClass.FK_hotel);
            return View(roomClass);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_room,FK_hotel,pricePerNight,capacity,createdAt,updatedAt,states")] RoomClass roomClass)
        {
            if (id != roomClass.PK_room)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomClassExists(roomClass.PK_room))
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
            ViewData["FK_hotel"] = new SelectList(_context.Hotels, "PK_hotel", "addressAt", roomClass.FK_hotel);
            return View(roomClass);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomClass = await _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.PK_room == id);
            if (roomClass == null)
            {
                return NotFound();
            }

            return View(roomClass);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomClass = await _context.Rooms.FindAsync(id);
            if (roomClass != null)
            {
                _context.Rooms.Remove(roomClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomClassExists(int id)
        {
            return _context.Rooms.Any(e => e.PK_room == id);
        }
    }
}
