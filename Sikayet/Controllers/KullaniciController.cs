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
            return View();
        }

        public ActionResult KullaniciSil()
        {
            return View();
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
    }
}