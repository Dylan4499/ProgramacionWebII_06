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
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(u => u.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.PK_user == id);
            if (userClass == null)
            {
                return NotFound();
            }

            return View(userClass);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["FK_rol"] = new SelectList(_context.Roles, "PK_rol", "RolName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_user,FK_rol,FirstName,LastName,Email,PhoneNumber,CreatedAt,UpdatedAt,states")] UserClass userClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_rol"] = new SelectList(_context.Roles, "PK_rol", "RolName", userClass.FK_rol);
            return View(userClass);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.Users.FindAsync(id);
            if (userClass == null)
            {
                return NotFound();
            }
            ViewData["FK_rol"] = new SelectList(_context.Roles, "PK_rol", "RolName", userClass.FK_rol);
            return View(userClass);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_user,FK_rol,FirstName,LastName,Email,PhoneNumber,CreatedAt,UpdatedAt,states")] UserClass userClass)
        {
            if (id != userClass.PK_user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserClassExists(userClass.PK_user))
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
            ViewData["FK_rol"] = new SelectList(_context.Roles, "PK_rol", "RolName", userClass.FK_rol);
            return View(userClass);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.PK_user == id);
            if (userClass == null)
            {
                return NotFound();
            }

            return View(userClass);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userClass = await _context.Users.FindAsync(id);
            if (userClass != null)
            {
                _context.Users.Remove(userClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserClassExists(int id)
        {
            return _context.Users.Any(e => e.PK_user == id);
        }
    }
}
