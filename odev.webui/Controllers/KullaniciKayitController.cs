using Microsoft.AspNetCore.Mvc;
using odev.webui.Data;
using OdevPortali.Models;
using OdevPortali.ViewModels;

public class KullaniciKayitController : Controller
{
    private readonly OdevPortaliContext _dbContext;
    [HttpGet]
    public IActionResult Kayit()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult KayitPost(KullaniciKayitViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var existingUser = _dbContext.Kullanicilar.FirstOrDefault(u => u.KullaniciAdi == model.KullaniciAdi);

                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten kullanılmaktadır.");
                    return View("Kayit", model);
                }

                if (model.Sifre != model.SifreTekrar)
                {
                    ModelState.AddModelError(string.Empty, "Şifreler uyuşmuyor.");
                    return View("Kayit", model);
                }

                var newUser = new Kullanici
                {
                    KullaniciAdi = model.KullaniciAdi,
                    Sifre = model.Sifre,
                };

                _dbContext.Kullanicilar.Add(newUser);
                _dbContext.SaveChanges();

                return RedirectToAction("Giris");
            }
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen tekrar deneyin.");
        }

        return View("Kayit", model);
    }
}
