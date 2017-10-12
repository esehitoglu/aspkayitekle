using kayitekleme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kayitekleme.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OgrenciKaydet(string ad, string soyad, string ders , int not)
        {
            if (HttpRuntime.Cache["ogrenciler"]==null)
            {
                List<ogrenci> ogrenciListesi = new List<ogrenci>();
                ogrenci ogr = new ogrenci();
                ogr.ad = ad;
                ogr.soyad = soyad;
                ogr.ders = ders;
                ogr.not = not;

                ogrenciListesi.Add(ogr);
                HttpRuntime.Cache["ogrenciler"] = ogrenciListesi;
            }
            else
            {
                List<ogrenci> ogrenciListesi = (List<ogrenci>)HttpRuntime.Cache["ogrenciler"];
                ogrenci ogr = new ogrenci();
                ogr.ad = ad;
                ogr.soyad = soyad;
                ogr.ders = ders;
                ogr.not = not;

                ogrenciListesi.Add(ogr);
                HttpRuntime.Cache["ogrenciler"] = ogrenciListesi;
            }

            return RedirectToAction("ogrenciListesi");
        }

        public ActionResult ogrenciListesi()
        {
            var model = (List<ogrenci>)HttpRuntime.Cache["ogrenciler"];
            return View(model);
        }
	}
}