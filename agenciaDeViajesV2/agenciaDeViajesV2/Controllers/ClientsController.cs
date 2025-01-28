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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.Clients
                .FirstOrDefaultAsync(m => m.PK_client == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_client,firstName,lastName,email,phoneNumber,preferences,createdAt,updatedAt,states")] ClientClass clientClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientClass);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.Clients.FindAsync(id);
            if (clientClass == null)
            {
                return NotFound();
            }
            return View(clientClass);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_client,firstName,lastName,email,phoneNumber,preferences,createdAt,updatedAt,states")] ClientClass clientClass)
        {
            if (id != clientClass.PK_client)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientClassExists(clientClass.PK_client))
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
            return View(clientClass);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.Clients
                .FirstOrDefaultAsync(m => m.PK_client == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientClass = await _context.Clients.FindAsync(id);
            if (clientClass != null)
            {
                _context.Clients.Remove(clientClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientClassExists(int id)
        {
            return _context.Clients.Any(e => e.PK_client == id);
        }
    }
}
