using Microsoft.AspNetCore.Mvc;

public class PagesController : Controller
{
    public IActionResult Index()
    {
        return View();

    }
        public IActionResult Odevler()
    {
        
        if (!HttpContext.Session.GetInt32("KullaniciId").HasValue || !HttpContext.Session.GetInt32("Yetki").HasValue)
        {
            return RedirectToAction("Giris", "Kullanici");
        }

        ViewData["Title"] = "Odevler";

        return View();
    }

    [HttpPost]
    public IActionResult OdevlerPost()
    {
        
        if (KullaniciVeSifreKontrolu())
        {
            
            if (!HttpContext.Session.GetInt32("KullaniciId").HasValue || !HttpContext.Session.GetInt32("Yetki").HasValue)
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            

            ViewData["Title"] = "Odevler";

            return View("Odevler");
        }
        else
        {
            
            ViewData["HataMesaji"] = "Kullanıcı adı veya şifre yanlış.";
            return View("Giris"); 
        }
    }

    private bool KullaniciVeSifreKontrolu()
    {
        
        return true;
    }
}
