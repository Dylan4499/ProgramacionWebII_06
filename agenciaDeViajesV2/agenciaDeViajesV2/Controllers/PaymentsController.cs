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
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Payments.Include(p => p.Offer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentClass = await _context.Payments
                .Include(p => p.Offer)
                .FirstOrDefaultAsync(m => m.PK_payment == id);
            if (paymentClass == null)
            {
                return NotFound();
            }

            return View(paymentClass);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_payment,FK_offer,totalPrice,paymentMethod,createdAt,updatedAt,states")] PaymentClass paymentClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", paymentClass.FK_offer);
            return View(paymentClass);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentClass = await _context.Payments.FindAsync(id);
            if (paymentClass == null)
            {
                return NotFound();
            }
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", paymentClass.FK_offer);
            return View(paymentClass);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PK_payment,FK_offer,totalPrice,paymentMethod,createdAt,updatedAt,states")] PaymentClass paymentClass)
        {
            if (id != paymentClass.PK_payment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentClassExists(paymentClass.PK_payment))
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
            ViewData["FK_offer"] = new SelectList(_context.Offers, "PK_offer", "Destiny", paymentClass.FK_offer);
            return View(paymentClass);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentClass = await _context.Payments
                .Include(p => p.Offer)
                .FirstOrDefaultAsync(m => m.PK_payment == id);
            if (paymentClass == null)
            {
                return NotFound();
            }

            return View(paymentClass);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentClass = await _context.Payments.FindAsync(id);
            if (paymentClass != null)
            {
                _context.Payments.Remove(paymentClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentClassExists(int id)
        {
            return _context.Payments.Any(e => e.PK_payment == id);
        }
    }
}
