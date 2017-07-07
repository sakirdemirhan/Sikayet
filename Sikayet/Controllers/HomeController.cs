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
        SikayetContext context = new SikayetContext();
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
            var kullanici = context.Kullanicis.FirstOrDefault(x => x.TC == TC && x.Sifre == Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.Adi, false);
                HttpCookie tc = new HttpCookie("tc");
                tc.Value = TC;
                tc.Expires = DateTime.Now.AddHours(1);
                Response.SetCookie(tc);
                return RedirectToAction("Profilim", "Kullanici");

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
            var kullanici = context.Moderators.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == Sifre);
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
                    context.Kullanicis.Add(kullanici);
                    context.SaveChanges();
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Iletisim()
        {
            return View();
        }

    }
}