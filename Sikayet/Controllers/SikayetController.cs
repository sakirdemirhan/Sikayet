using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sikayet.Models;


namespace Sikayet.Controllers
{
    
    [Authorize(Roles = "uye,moderator")]
    public class SikayetController : Controller
    {
        private readonly SikayetContext _context = new SikayetContext();
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

        public ActionResult SikayetKaldir(int id)
        {
            var d = _context.Sikayets.FirstOrDefault(x => x.SikayetId == id);
            d.Durum = false;
            _context.SaveChanges();
            return Redirect("/Sikayet/SikayetDetay/" + id);
        }
        public ActionResult SikayetListele()
        {
            var data = _context.Sikayets.ToList();
            return View(data);
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