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

namespace EthioServices.Controllers
{
    public class TalentsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TalentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Talents
        public async Task<IActionResult> Index()
        {
              return _context.Talent != null ? 
                          View(await _context.Talent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Talent'  is null.");
        }

        // GET: Talents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Talent == null)
            {
                return NotFound();
            }

            var talent = await _context.Talent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // GET: Talents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Talents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,email,name,type,location,salary,description,imageUrl,portfolioUrl,rating,acceptedJobs,appliedJobs")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talent);
        }

        // GET: Talents/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Talent == null)
            {
                return NotFound();
            }
            
            var talent = await _context.Talent.FirstOrDefaultAsync(j => j.email.Contains(id));
            

            if (talent == null)
            {
                Talent newTalent = new Talent();
                newTalent.email = id;
                
                if (User != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (currentUser != null)
                    {
                        var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                        ApplicationUser user = await _userManager.GetUserAsync(currentUser);
                        newTalent.location = user.Location;
                        newTalent.name = user.FirstName + user.LastName;
                        newTalent.type = "";
                        newTalent.salary = 0;
                        newTalent.acceptedJobs = 0;
                        newTalent.appliedJobs = 0;
                        newTalent.imageUrl = "";
                        newTalent.portfolioUrl = "";
                        newTalent.rating = 0;
                        newTalent.description = "";

                    }


                }
                if (ModelState.IsValid)
                {
                    _context.Talent.Add(newTalent);
                    await _context.SaveChangesAsync();
                    talent = await _context.Talent.FirstOrDefaultAsync(j => j.email.Contains(id));
                    return View(talent);
                }
                return View(talent);
    

               
            }
            return View(talent);
        }

        // POST: Talents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,email,name,type,location,salary,description,imageUrl,portfolioUrl,rating,acceptedJobs,appliedJobs")] Talent talent)
        {
            if (id != talent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentExists(talent.Id))
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
            return View(talent);
        }

        // GET: Talents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Talent == null)
            {
                return NotFound();
            }

            var talent = await _context.Talent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Talent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Talent'  is null.");
            }
            var talent = await _context.Talent.FindAsync(id);
            if (talent != null)
            {
                _context.Talent.Remove(talent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalentExists(int id)
        {
          return (_context.Talent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
