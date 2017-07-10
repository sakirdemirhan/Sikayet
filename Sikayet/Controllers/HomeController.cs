using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sikayet.Models;

namespace Sikayet.Controllers
{
    
    public class HomeController : Controller
    {
        SikayetContext _context = new SikayetContext();
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GirisYap()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult GirisYap(string TC, string Sifre)
        {
            var kullanici = _context.Kullanicis.FirstOrDefault(x => x.TC == TC && x.Sifre == Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.Adi, false);
                HttpCookie tc = new HttpCookie("tc");
                tc.Value = TC;
                tc.Expires = DateTime.Now.AddHours(1);
                Response.SetCookie(tc);
                return RedirectToAction("Profilim", "Kullanici");

            }
            else
            {
                ViewBag.HataMesaji = "Yanlış TC ya da şifre girdiniz.";
            }


            return View();
        }

        
        public ActionResult GirisYapMod()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult GirisYapMod(string kullaniciAdi, string Sifre)
        {
            var kullanici = _context.Moderators.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult KayitOl()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult KayitOl(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Kullanicis.Add(kullanici);
                    _context.SaveChanges();
                    return RedirectToAction("GirisYap", "Home");
                }
                catch
                {
                    ViewBag.HataMesaji = "Kayıt olurken hata. Eksik bilgi ya da daha önce kaydolmuş bir TC girdiniz.";
                }
            }
            else
            {
                ViewBag.HataMesaji = "Kayıt olurken hata. Eksik bilgi ya da daha önce kaydolmuş bir TC girdiniz.";
            }

            return View();
        }

        
        public ActionResult CikisYap()
        {
            if (Request.Cookies["tc"] != null)
            {
                var c = new HttpCookie("tc");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Home");
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        

    }
}