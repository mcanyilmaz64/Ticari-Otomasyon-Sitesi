using OnlineTicariSite.Migrations;
using OnlineTicariSite.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariSite.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
          
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int  a1,a2,a3;
            a1 = random.Next(0,4);
            a2 = random.Next(0,4);
            a3 = random.Next(0,4);
            int s1, s2 ,s3;
            s1 = random.Next(100,1000);
            s2 = random.Next(10,100);
            s3 = random.Next(10,100);
            string kod = s1.ToString() + karakterler[a1] + s2 + karakterler[a2] + s3 + karakterler[a3];
            ViewBag.takipkod = kod;

            return View();

        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            
            return View(degerler);

        }

    }
}