﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;

namespace OnlineTicariSite.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");   
        }
       
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);

            return View("DepartmanGetir",dpt);
        }
        public ActionResult DepartmanGuncelle(Departman d) 
        { 
            var dept = c.Departmans.Find(d.DepartmanId);
            dept.DepartmanAd=d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
  
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x=>x.DepartmanId==id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);

        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var per =c.Personels.Where(x=>x.PersonelId== id).Select(y=>y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}