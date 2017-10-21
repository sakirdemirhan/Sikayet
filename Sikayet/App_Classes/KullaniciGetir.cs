using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sikayet.Models;

namespace Sikayet.App_Classes
{
    public class KullaniciGetir
    {
        SikayetContext _context = new SikayetContext();
        public string kGetir(string tc)
        {
            var kullanici = _context.SilinmisKullanicis.FirstOrDefault(x => x.TC == tc);
            return kullanici.Adi;
        }

        public string kGetirSilinmis(string tc)
        {
            var kullanici = _context.SilinmisKullanicis.FirstOrDefault(x => x.TC == tc);
            return kullanici.Adi;
        }

        public bool kullaniciSilinmisMi(string tc)
        {
            var kullanici = _context.Kullanicis.FirstOrDefault(x => x.TC == tc);
            if (kullanici == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}