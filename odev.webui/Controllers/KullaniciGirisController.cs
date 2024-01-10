using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using odev.webui.Data;
using OdevPortali.Models;
using OdevPortali.ViewModels;
using System.Security.Claims;

namespace odev.webui.Controllers
{
    

    public class KullaniciGirisController : Controller
    {
        private readonly OdevPortaliContext _dbContext;

        public KullaniciGirisController(OdevPortaliContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GirisPost(KullaniciGirisViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _dbContext.Kullanicilar.SingleOrDefault(u => u.KullaniciAdi == model.KullaniciAdi && u.Sifre == model.Sifre);

                    if (user != null)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.KullaniciAdi),
                    };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                            IsPersistent = model.BeniHatirla,
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            authProperties);

                        return RedirectToAction("Odevler", "Pages");
                    }

                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen tekrar deneyin.");
            }

           
            return View("Giris", model);


        }
    }
}
