using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Sikayet.Models;

namespace Sikayet.Controllers
{
    [Authorize(Roles = "moderator,uye")]
    public class KullaniciController : Controller
    {
        SikayetContext _context = new SikayetContext();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KullaniciListele()
        {
            var data = _context.Kullanicis.ToList();
            return View(data);
        }

        public ActionResult KullaniciSil(string id)
        {
            var sikayetler = _context.Sikayets.Where(x => x.KullaniciTC == id);
            foreach (var item in sikayetler)
            {
                _context.Sikayets.Remove(item);
            }
            _context.SaveChanges();

            var kullanici = _context.Kullanicis.FirstOrDefault(x => x.TC == id);
            _context.Kullanicis.Remove(kullanici);
            _context.SaveChanges();
            if (User.IsInRole("uye"))
            {
                return RedirectToAction("CikisYap", "Home");
            }
            else
            {
                return RedirectToAction("KullaniciListele", "Kullanici");
            }
            
        }

        public ActionResult BilgileriDuzenle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BilgileriDuzenle(Kullanici kul)
        {
            string TC = Request.Cookies["tc"].Value.ToString();
            var kullanici = _context.Kullanicis.FirstOrDefault(x => x.TC == TC);
            kullanici.Adi = kul.Adi;
            kullanici.Soyadi = kul.Soyadi;
            kullanici.Email = kul.Email;
            kullanici.Telefon = kul.Telefon;
            try
            {
                _context.SaveChanges();
                return RedirectToAction("CikisYap", "Home");
            }
            catch
            {
                ViewBag.HataMesaji = "Hata Oluştu";
            }
            return RedirectToAction("Bilgiler", "Kullanici");
        }


        public ActionResult Profilim()
        {
            string tc = Request.Cookies["tc"].Value.ToString();
            var data = _context.Sikayets.Where(x => x.KullaniciTC == tc).ToList();
            return View(data);
        }

        public ActionResult Bilgiler()
        {
            string tc = Request.Cookies["tc"].Value.ToString();
            var data = _context.Kullanicis.Where(x => x.TC == tc).ToList();
            return View(data);
        }
        public ActionResult Hesabim()
        {
            var data = _context.Sikayets.ToList();
            return View(data);
        }
    }
}   