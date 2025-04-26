using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FMS.Models;

namespace FMS.Controllers
{
    public class TransactiondetailController : Controller
    {
        private readonly ManagementsystemContext _context;

        public TransactiondetailController(ManagementsystemContext context)
        {
            _context = context;
        }

        // GET: Transactiondetail
        public async Task<IActionResult> Index()
        {
            var managementsystemContext = _context.Transactiondetails.Include(t => t.Expense).Include(t => t.Income).Include(t => t.Transaction);
            return View(await managementsystemContext.ToListAsync());
        }

        // GET: Transactiondetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactiondetail = await _context.Transactiondetails
                .Include(t => t.Expense)
                .Include(t => t.Income)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.Transactionid == id);
            if (transactiondetail == null)
            {
                return NotFound();
            }

            return View(transactiondetail);
        }

        // GET: Transactiondetail/Create
        public IActionResult Create()
        {
            ViewData["Expenseid"] = new SelectList(_context.Expenses, "Expenseid", "Expenseid");
            ViewData["Incomeid"] = new SelectList(_context.Incomes, "Incomeid", "Incomeid");
            ViewData["Transactionid"] = new SelectList(_context.Transactions, "Transactionid", "Transactionid");
            return View();
        }

        // POST: Transactiondetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Transactionid,Incomeid,Expenseid")] Transactiondetail transactiondetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactiondetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Expenseid"] = new SelectList(_context.Expenses, "Expenseid", "Expenseid", transactiondetail.Expenseid);
            ViewData["Incomeid"] = new SelectList(_context.Incomes, "Incomeid", "Incomeid", transactiondetail.Incomeid);
            ViewData["Transactionid"] = new SelectList(_context.Transactions, "Transactionid", "Transactionid", transactiondetail.Transactionid);
            return View(transactiondetail);
        }

        // GET: Transactiondetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactiondetail = await _context.Transactiondetails.FindAsync(id);
            if (transactiondetail == null)
            {
                return NotFound();
            }
            ViewData["Expenseid"] = new SelectList(_context.Expenses, "Expenseid", "Expenseid", transactiondetail.Expenseid);
            ViewData["Incomeid"] = new SelectList(_context.Incomes, "Incomeid", "Incomeid", transactiondetail.Incomeid);
            ViewData["Transactionid"] = new SelectList(_context.Transactions, "Transactionid", "Transactionid", transactiondetail.Transactionid);
            return View(transactiondetail);
        }

        // POST: Transactiondetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Transactionid,Incomeid,Expenseid")] Transactiondetail transactiondetail)
        {
            if (id != transactiondetail.Transactionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactiondetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactiondetailExists(transactiondetail.Transactionid))
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
            ViewData["Expenseid"] = new SelectList(_context.Expenses, "Expenseid", "Expenseid", transactiondetail.Expenseid);
            ViewData["Incomeid"] = new SelectList(_context.Incomes, "Incomeid", "Incomeid", transactiondetail.Incomeid);
            ViewData["Transactionid"] = new SelectList(_context.Transactions, "Transactionid", "Transactionid", transactiondetail.Transactionid);
            return View(transactiondetail);
        }

        // GET: Transactiondetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactiondetail = await _context.Transactiondetails
                .Include(t => t.Expense)
                .Include(t => t.Income)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.Transactionid == id);
            if (transactiondetail == null)
            {
                return NotFound();
            }

            return View(transactiondetail);
        }

        // POST: Transactiondetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactiondetail = await _context.Transactiondetails.FindAsync(id);
            if (transactiondetail != null)
            {
                _context.Transactiondetails.Remove(transactiondetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactiondetailExists(int id)
        {
            return _context.Transactiondetails.Any(e => e.Transactionid == id);
        }
    }
}
