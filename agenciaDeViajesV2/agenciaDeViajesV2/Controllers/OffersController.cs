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
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Offers.Include(o => o.Activity).Include(o => o.Client).Include(o => o.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerClass = await _context.Offers
                .Include(o => o.Activity)
                .Include(o => o.Client)
                .Include(o => o.Room)
                .FirstOrDefaultAsync(m => m.PK_offer == id);
            if (offerClass == null)
            {
                return NotFound();
            }

            return View(offerClass);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["FK_activity"] = new SelectList(_context.Activities, "PK_activity", "actName");
            ViewData["FK_client"] = new SelectList(_context.Clients, "PK_client", "email");
            ViewData["FK_room"] = new SelectList(_context.Rooms, "PK_room", "PK_room");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_offer,FK_room,FK_client,FK_activity,Destiny,DistanceDays,totalPrice,CreatedAt,UpdatedAt,states")] OfferClass offerClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_activity"] = new SelectList(_context.Activities, "PK_activity", "actName", offerClass.FK_activity);
            ViewData["FK_client"] = new SelectList(_context.Clients, "PK_client", "email", offerClass.FK_client);
            ViewData["FK_room"] = new SelectList(_context.Rooms, "PK_room", "PK_room", offerClass.FK_room);
            return View(offerClass);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerClass = await _context.Offers.FindAsync(id);
            if (offerClass == null)
            {
                return NotFound();
            }
            ViewData["FK_activity"] = new SelectList(_context.Activities, "PK_activity", "actName", offerClass.FK_activity);
            ViewData["FK_client"] = new SelectList(_context.Clients, "PK_client", "email", offerClass.FK_client);
            ViewData["FK_room"] = new SelectList(_context.Rooms, "PK_room", "PK_room", offerClass.FK_room);
            return View(offerClass);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_offer,FK_room,FK_client,FK_activity,Destiny,DistanceDays,totalPrice,CreatedAt,UpdatedAt,states")] OfferClass offerClass)
        {
            if (id != offerClass.PK_offer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferClassExists(offerClass.PK_offer))
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
            ViewData["FK_activity"] = new SelectList(_context.Activities, "PK_activity", "actName", offerClass.FK_activity);
            ViewData["FK_client"] = new SelectList(_context.Clients, "PK_client", "email", offerClass.FK_client);
            ViewData["FK_room"] = new SelectList(_context.Rooms, "PK_room", "PK_room", offerClass.FK_room);
            return View(offerClass);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerClass = await _context.Offers
                .Include(o => o.Activity)
                .Include(o => o.Client)
                .Include(o => o.Room)
                .FirstOrDefaultAsync(m => m.PK_offer == id);
            if (offerClass == null)
            {
                return NotFound();
            }

            return View(offerClass);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerClass = await _context.Offers.FindAsync(id);
            if (offerClass != null)
            {
                _context.Offers.Remove(offerClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferClassExists(int id)
        {
            return _context.Offers.Any(e => e.PK_offer == id);
        }
    }
}
