using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Texter.Controllers
{
    public class ContactController : Controller
    {
        private readonly TexterContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ContactController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TexterContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(string contactName, string address, string imageUrl, string notes)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            var newContact = new Contact(contactName, address, imageUrl, notes);
            newContact.User = currentUser;
            _db.Contacts.Add(newContact);
            _db.SaveChanges();
            return View();
        }
    }
}
