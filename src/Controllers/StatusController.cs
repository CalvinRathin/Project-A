using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;

namespace PizzaProject.Controllers
{
    public class StatusController : Controller
    {
        private readonly PizzaProjectContext _context;

        public StatusController(PizzaProjectContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            var pizzaProjectContext = _context.Status.Include(s => s.Order);
            return View(await pizzaProjectContext.ToListAsync());
        }


        // Action method for updating the order status to "Delivered Successfully"
        public IActionResult MarkAsDelivered(int id)
        {
            // Get the status object for the order
            var status = _context.Status.SingleOrDefault(s => s.orderId == id);

            if (status != null)
            {
                // Update the status to "Delivered Successfully" and save changes
                status.status_details = "Delivered Successfully";
                _context.SaveChanges();
            }

            // Redirect to the order details page
            return RedirectToAction("Details", new { id });
        }



        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.statusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }






        // GET: Status/Create
        public IActionResult Create()
        {
            ViewData["orderId"] = new SelectList(_context.Orders, "orderId", "orderId");
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("statusId,orderId,status_details")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["orderId"] = new SelectList(_context.Orders, "orderId", "orderId", status.orderId);
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            ViewData["orderId"] = new SelectList(_context.Orders, "orderId", "orderId", status.orderId);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("statusId,orderId,status_details")] Status status)
        {
            if (id != status.statusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.statusId))
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
            ViewData["orderId"] = new SelectList(_context.Orders, "orderId", "orderId", status.orderId);
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.statusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Status == null)
            {
                return Problem("Entity set 'PizzaProjectContext.Status'  is null.");
            }
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
          return (_context.Status?.Any(e => e.statusId == id)).GetValueOrDefault();
        }
    }
}
