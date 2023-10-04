using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EthioServices.Data;
using EthioServices.Models;
using Microsoft.AspNetCore.Authorization;

namespace EthioServices.Controllers
{
    public class BalancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BalancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Balances
        public async Task<IActionResult> Index()
        {
              return _context.Balance != null ? 
                          View(await _context.Balance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Balance'  is null.");
        }

        // GET: Balances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Balance == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }
        [Authorize(Roles = "Admin")]
        // GET: Balances/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Balances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("owner,money")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balance);
        }
        [Authorize(Roles = "Admin")]
        // GET: Balances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Balance == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            return View(balance);
        }
        [Authorize(Roles = "Admin")]
        // POST: Balances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,owner,money")] Balance balance)
        {
            if (id != balance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.Id))
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
            return View(balance);
        }
        [Authorize(Roles = "Admin")]
        // GET: Balances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Balance == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }
        [Authorize(Roles = "Admin")]
        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Balance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Balance'  is null.");
            }
            var balance = await _context.Balance.FindAsync(id);
            if (balance != null)
            {
                _context.Balance.Remove(balance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(int id)
        {
          return (_context.Balance?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Transfer(int id, [Bind("owner,money")] Balance balance)
        {
            if (id != balance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.Id))
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
            return View(balance);
        }
        private bool BalanceExistsForUser(string id)
        {
            return (_context.Balance?.Any(e => e.owner == id)).GetValueOrDefault();
        }
    }
}
