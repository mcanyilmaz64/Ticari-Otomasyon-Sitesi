﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;
namespace OnlineTicariSite.Controllers
{
    public class SatisController : Controller
    {   
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList() 
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value =x.UrunId.ToString()

                                           }).ToList();
            

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariId.ToString()

                                           }).ToList();
           

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");   

        } 
        public ActionResult SatisGetir(int id )
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()

                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariId.ToString()

                                           }).ToList();


            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir",deger);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.SatisId);
            deger.CariId = p.CariId;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelId = p.PersonelId;
            deger.ToplamTutar = p.ToplamTutar;  
            deger.Tarih=p.Tarih;
            deger.UrunId = p.UrunId;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.SatisId == id).ToList();
            return View(degerler);

        }

    }
}