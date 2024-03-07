using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_D03.Models;
using System.Security.Claims;

namespace MVC_D03.Controllers
{
    public class AccountController : Controller
    {
        ITIContext db = new ITIContext();
        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(users u)
        {
            if (u == null || string.IsNullOrEmpty(u.username))
            {
                return View();
            }

            var user = await db.Users.FirstOrDefaultAsync(x => x.username == u.username && x.password == u.password);
            if (user != null)
            {
                //get roles, Admin
                Claim c1 = new Claim(ClaimTypes.Name, user.username);
                Claim c2 = new Claim(ClaimTypes.Email, user.username +"@iti.gov.eg" );
                Claim c3 = new Claim(ClaimTypes.Role, user.role);

                ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                ci.AddClaim(c1);
                ci.AddClaim(c2);
                ci.AddClaim(c3);

                ClaimsPrincipal cp = new ClaimsPrincipal(ci);

                await  HttpContext.SignInAsync(cp);

                return RedirectToAction("Index", "Home");


            }
            else
            {
                return View();
            }
           
        }

        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("login");

        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(users user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
    }
}
