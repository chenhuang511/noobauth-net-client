using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OAuthNotes.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge("Noob");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }

        public async Task<IActionResult> LogoutIdp()
        {
            //First, logout from application
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Then logout from Idp
            string redirectUrl = "https://netclient.vn:5001/account/logout";
            string idpSignoutUrl = Configuration.GetValue<string>("Noob:LogoutEndpoint") + $"?redirect_url={redirectUrl}";
            return Redirect(idpSignoutUrl);
        }

        public IActionResult AccessDenied()
        {
            return Content("Access denied");
        }
    }
}