using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariSite.Models.Siniflar;

namespace OnlineTicariSite.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = c.Uruns.Where(x=>x.UrunId == 1).ToList();
            cs.deger1=c.Uruns.Where(x => x.UrunId == 1).ToList();
            cs.deger2=c.Detays.Where(y => y.DetayId == 1).ToList();
            return View(cs);
        }
    }
}