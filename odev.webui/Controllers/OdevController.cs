using Microsoft.AspNetCore.Mvc;
using OdevPortali.Models;
using odev.webui.Data;

namespace OdevPortali.Controllers
{
    public class OdevController : Controller
    {
        private readonly OdevPortaliContext _context;

        public OdevController(OdevPortaliContext context)
        {
            _context = context;
        }

        
        public IActionResult Ekle()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Ekle(OdevPortali.Models.Odevs odevModel)
        {
            if (ModelState.IsValid)
            {
                var homework = new OdevPortali.Models.Odevs
                {
                    

                    Ad = odevModel.Ad,
                };

               
                _context.SaveChanges();

              
                return RedirectToAction("Index", "Pages");
            }

            return View(odevModel);
        }
    }
}
    