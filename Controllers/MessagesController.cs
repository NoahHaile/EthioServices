using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EthioServices.Data;
using EthioServices.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace EthioServices.Controllers
{
    public class MessagesController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public MessagesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Message == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Message' is null.");
            }
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.GetUserAsync(this.User);
            string id1 = user.Id;
            
            var filteredMessages = await _context.Message
                .Where(j => j.receiver.Contains(id1))
                .OrderByDescending(j => j.Id)
                .ToListAsync();

            return View(filteredMessages);
        }

        // GET: Messages
        public async Task<IActionResult> MessageLink(string? id2)
        {
            if (_context.Message == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Message' is null.");
            }
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.GetUserAsync(this.User);
            string id1 = user.Id;
            ViewBag.Receiver = id1;
            ViewBag.Sender = id2;

            var filteredMessages = await _context.Message
                .Where(j => j.sender.Contains(id1) || j.receiver.Contains(id1) || j.sender.Contains(id2) || j.receiver.Contains(id2))
                .ToListAsync();

            return View(filteredMessages);
        }
        

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public async Task<IActionResult> Create(string? id2)
        {
            ViewBag.Receiver = id2;
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.GetUserAsync(this.User);
           
            ViewBag.Sender = user.Id;
            ViewBag.SenderName = user.FirstName + user.LastName;

            ApplicationUser user2 = await _userManager.FindByIdAsync(id2);
            ViewBag.ReceiverName = user2.FirstName + user2.LastName;
          

            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("senderName,receiverName,sender,receiver,text,read")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sender,receiver,text")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Message == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Message'  is null.");
            }
            var message = await _context.Message.FindAsync(id);
            if (message != null)
            {
                _context.Message.Remove(message);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
          return (_context.Message?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
