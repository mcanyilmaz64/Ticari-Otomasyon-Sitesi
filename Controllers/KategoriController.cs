using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariSite.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);//genelde 10-12

            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEKle()
        {
            return View();  
        }
        [HttpPost]  
        public ActionResult KategoriEKle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();    
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);

            return View("KategoriGetir",kategori); 
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriId);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}