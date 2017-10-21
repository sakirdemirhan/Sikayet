using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sikayet.App_Classes;
using Sikayet.Models;


namespace Sikayet.Controllers
{
    
    [Authorize(Roles = "uye,moderator")]
    public class SikayetController : Controller
    {
        private readonly SikayetContext _context = new SikayetContext();
        KullaniciGetir kg = new KullaniciGetir();
        // GET: Sikayet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SikayetEkle()
        {
            var data = _context.Mahalles.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult SikayetEkle(Models.Sikayet sikayet, HttpPostedFileBase file, string Mahalle)
        {
           
                try
                {
                    var mahalle = _context.Mahalles.Where(x => x.Adi == Mahalle).Select(x => x.MahalleId).FirstOrDefault();
                    sikayet.Fotograf = FileUpload(file);
                    sikayet.MahalleID = mahalle;
                    sikayet.Tarih = DateTime.Today;
                    sikayet.Durum = true;
                    sikayet.KullaniciTC = Request.Cookies["tc"].Value.ToString();
                    _context.Sikayets.Add(sikayet);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    
                }
            

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SikayetDetay(int id)
        {
            var data = _context.Sikayets.FirstOrDefault(x => x.SikayetId == id);
            return View(data);
        }

        public ActionResult EskiSikayetDetay(int id)
        {
            var data = _context.SilinmisSikayets.FirstOrDefault(x => x.SilinmisId == id);
            return View(data);
        }

        public ActionResult SikayetKaldir(int id)
        {
            SilinmisSikayet cop = new SilinmisSikayet();
            var d = _context.Sikayets.FirstOrDefault(x => x.SikayetId == id);
            d.Durum = false;
            cop.KullaniciTC = d.KullaniciTC;
            cop.Aciklama = d.Aciklama;
            cop.Baslik = d.Baslik;
            cop.Fotograf = d.Fotograf;
            cop.MahalleID = d.MahalleID;
            cop.Sokak = d.Sokak;
            cop.Yorum = d.Yorum;
            cop.Tarih = d.Tarih;
            _context.SilinmisSikayets.Add(cop);
            _context.Sikayets.Remove(d);
            _context.SaveChanges();
            return Redirect("/Sikayet/EskiSikayetler/");
        }
        public ActionResult SikayetListele()
        {
            var data = _context.Sikayets.ToList();
            return View(data);
        }

        public ActionResult EskiSikayetler()
        {
            var data = _context.SilinmisSikayets.ToList();
            return View(data);
        }

        public ActionResult YorumEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YorumEkle(int id, string yorum)
        {
            var sikayet = _context.Sikayets.FirstOrDefault(x => x.SikayetId == id);
            sikayet.Yorum = yorum;
            _context.SaveChanges();
            return Redirect("/Sikayet/SikayetDetay/" + id);
        }

        public string FileUpload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/img/" + ImageName);

                //// save image in folder
                file.SaveAs(physicalPath);
                string resimUrl = "/Content/img/" + ImageName + "";
                return resimUrl;
            }
            return "";
        }
    }
}