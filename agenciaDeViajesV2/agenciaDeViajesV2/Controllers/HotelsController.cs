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
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hotels.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelClass = await _context.Hotels
                .FirstOrDefaultAsync(m => m.PK_hotel == id);
            if (hotelClass == null)
            {
                return NotFound();
            }

            return View(hotelClass);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_hotel,hotelName,addressAt,stars,imageHotel,createdAt,updatedAt,states")] HotelClass hotelClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelClass);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelClass = await _context.Hotels.FindAsync(id);
            if (hotelClass == null)
            {
                return NotFound();
            }
            return View(hotelClass);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_hotel,hotelName,addressAt,stars,imageHotel,createdAt,updatedAt,states")] HotelClass hotelClass)
        {
            if (id != hotelClass.PK_hotel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelClassExists(hotelClass.PK_hotel))
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
            return View(hotelClass);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelClass = await _context.Hotels
                .FirstOrDefaultAsync(m => m.PK_hotel == id);
            if (hotelClass == null)
            {
                return NotFound();
            }

            return View(hotelClass);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelClass = await _context.Hotels.FindAsync(id);
            if (hotelClass != null)
            {
                _context.Hotels.Remove(hotelClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelClassExists(int id)
        {
            return _context.Hotels.Any(e => e.PK_hotel == id);
        }
    }
}
