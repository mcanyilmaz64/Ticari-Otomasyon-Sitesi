using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;

namespace OnlineTicariSite.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var degerler = c.Faturas.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);

            return View("FaturaGetir", fatura);

        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var dgr = c.Faturas.Find(f.FaturaId);
            dgr.FaturaSerino = f.FaturaSerino;
            dgr.FaturaSırano = f.FaturaSırano;
            dgr.Tarih = f.Tarih;
            dgr.Saat = f.Saat;
            dgr.VergiDairesi = f.VergiDairesi;
            dgr.TeslimEden = f.TeslimEden;
            dgr.TeslimAlan = f.TeslimAlan;
            dgr.Toplam = f.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {

        return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}