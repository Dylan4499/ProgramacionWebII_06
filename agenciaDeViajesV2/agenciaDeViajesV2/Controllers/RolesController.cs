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
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClass = await _context.Roles
                .FirstOrDefaultAsync(m => m.PK_rol == id);
            if (roleClass == null)
            {
                return NotFound();
            }

            return View(roleClass);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_rol,RolName,CreatedAt,UpdatedAt,states")] RoleClass roleClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleClass);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClass = await _context.Roles.FindAsync(id);
            if (roleClass == null)
            {
                return NotFound();
            }
            return View(roleClass);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_rol,RolName,CreatedAt,UpdatedAt,states")] RoleClass roleClass)
        {
            if (id != roleClass.PK_rol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleClassExists(roleClass.PK_rol))
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
            return View(roleClass);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClass = await _context.Roles
                .FirstOrDefaultAsync(m => m.PK_rol == id);
            if (roleClass == null)
            {
                return NotFound();
            }

            return View(roleClass);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleClass = await _context.Roles.FindAsync(id);
            if (roleClass != null)
            {
                _context.Roles.Remove(roleClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleClassExists(int id)
        {
            return _context.Roles.Any(e => e.PK_rol == id);
        }
    }
}
