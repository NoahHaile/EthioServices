using EthioServices.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace EthioServices.Controllers
{
    public class HomeController : Controller
    {
        
        private UserManager<ApplicationUser> _userManager;

        //class constructor
        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        

        public async Task<IActionResult> Index()
        {
            if (User != null)
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                if (currentUser != null)
                {
                    /*
                   var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                   ApplicationUser user = await _userManager.GetUserAsync(currentUser);
                    ViewBag.Location = user.Location;
                    */
                }
                

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}