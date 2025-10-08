using OnlineTicariSite.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;
using System.IO;



namespace OnlineTicariSite.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEKle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger1;
            return View();
        }
        [HttpPost]  
        public ActionResult PersonelEKle(Personel p)
        {
            if (Request.Files.Count> 0)
            { string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            string yol = "~/Image/" + dosyaadi + uzanti;
            Request.Files[0].SaveAs(Server.MapPath(yol));
            p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;

            }
           
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = c.Personels.Find(id);

            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger1;

            return View("PersonelGetir",prs);
        } 
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;

            }
            var prsn = c.Personels.Find(p.PersonelId);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.DepartmanId = p.DepartmanId;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();

            return View(sorgu);
        }
    

    }
}