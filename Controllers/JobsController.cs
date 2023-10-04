using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EthioServices.Data;
using EthioServices.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EthioServices.Controllers
{
    public class JobsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public JobsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [Authorize]
        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.GetUserAsync(this.User);
            ViewBag.Id = user.Id;
            return _context.Jobs != null ? 
                          View(await _context.Jobs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Jobs'  is null.");
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.Jobs != null ?
                        View("Index", await _context.Jobs.Where(j => j.name.Contains(SearchPhrase)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Jobs'  is null.");
        }
        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }


        // GET: Jobs/Create
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create()
        {
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.GetUserAsync(this.User);
            ViewBag.Id = user.Id;

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([Bind("Id,name,ownerId,type,location,salary,payment,description,appliedPeople,acceptedTalent")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobs);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            return View(jobs);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,type,location,salary,payment,description,appliedPeople,acceptedTalent")] Jobs jobs)
        {
            if (id != jobs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsExists(jobs.Id))
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
            return View(jobs);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jobs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jobs'  is null.");
            }
            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs != null)
            {
                _context.Jobs.Remove(jobs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsExists(int id)
        {
          return (_context.Jobs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
