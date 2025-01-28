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
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activities.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityClass = await _context.Activities
                .FirstOrDefaultAsync(m => m.PK_activity == id);
            if (activityClass == null)
            {
                return NotFound();
            }

            return View(activityClass);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_activity,actName,price,details,createdAt,updatedAt,states")] ActivityClass activityClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityClass);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityClass = await _context.Activities.FindAsync(id);
            if (activityClass == null)
            {
                return NotFound();
            }
            return View(activityClass);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_activity,actName,price,details,createdAt,updatedAt,states")] ActivityClass activityClass)
        {
            if (id != activityClass.PK_activity)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityClassExists(activityClass.PK_activity))
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
            return View(activityClass);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityClass = await _context.Activities
                .FirstOrDefaultAsync(m => m.PK_activity == id);
            if (activityClass == null)
            {
                return NotFound();
            }

            return View(activityClass);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityClass = await _context.Activities.FindAsync(id);
            if (activityClass != null)
            {
                _context.Activities.Remove(activityClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityClassExists(int id)
        {
            return _context.Activities.Any(e => e.PK_activity == id);
        }
    }
}
