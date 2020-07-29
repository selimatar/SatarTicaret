using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SatarTicaret.App_Classes;
using SatarTicaret.Models;
using System.Drawing;
using System.Web.UI;
using System.Configuration;
using System.IO;

namespace SatarTicaret.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urunler()
        {
            return View(Context.Baglanti.Uruns.ToList());
        }
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = Context.Baglanti.Kategoris.ToList();
            ViewBag.Markalar = Context.Baglanti.Markas.ToList();
            return View();
        }
        public ActionResult Markalar()
        {
            return View(Context.Baglanti.Markas.ToList());
        }
        public ActionResult MarkaEkle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult MarkaEkle(Marka mrk, HttpPostedFileBase fileUpload)
        {
            int resimId = -1;
            if (fileUpload != null)
            {
                
                Image img = Image.FromStream(fileUpload.InputStream);

                int width = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidth"].ToString());

                int heigth = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeigth"].ToString());

                //Guid, 24 basamaklı eşi ve benzeri olmayan bir string ifade verir. 
                //Bu string ifade harf ve sayı içerir

                /*Path.GetExtension resimin kendi uzantısı neyse onu alır*/

                string name = "/Content/MarkaResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                //resmin kendi uzantısıyla beraber bir isim oluşturmak

                Bitmap bm = new Bitmap(img, width, heigth);
                //bitmap ile resmin boyutları değiştirilir

                bm.Save(Server.MapPath(name));
                //Dosya isimleririn aynı olmaması için guid ile dosyaya isim
                //verildikten sonra kaydetme aşaması yapılsın.

                Resim rsm = new Resim();
                rsm.OrtaYol = name;

                Context.Baglanti.Resims.Add(rsm);
                Context.Baglanti.SaveChanges();
                //resimleri veritabanına ekle ve kaydet

                if (rsm.Id != null) 
                    resimId = rsm.Id;
            }
            if (resimId != -1) mrk.ResimID = resimId;

            Context.Baglanti.Markas.Add(mrk);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Markalar");

        }
    }
}