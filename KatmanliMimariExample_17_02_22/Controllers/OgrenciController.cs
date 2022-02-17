using Katmanli_ENTITIES;
using KatmanliMimariExample_17_02_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static KatmanliMimari_BL.Repository;

namespace KatmanliMimariExample_17_02_22.Controllers
{
    public class OgrenciController : Controller
    {
        SinifRepository RepoSinif = new SinifRepository();
        OgrenciRepository RepoOgr = new OgrenciRepository();
        SinifModel sm = new SinifModel();
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                name = "";
            }
            sm.oList = RepoOgr.GenelListe().Where(x => x.OgrenciAd.Contains(name) || x.OgrenciSoyad.Contains(name) || x.OgrenciAdres.Contains(name)).ToList();

            return View(sm);
        }
        public ActionResult Detay(int id)
        {
            sm.Ogrenci = RepoOgr.Bul(id);
            sm.oList = RepoOgr.Listele().Where(x => x.OgrenciID == id).ToList();
            sm.Siniflar = RepoSinif.Listele().FirstOrDefault(x=>x.SinifID == sm.Ogrenci.SinifID);
            return View(sm);
        }
        public ActionResult Ekle()
        {
            sm.SinifListesi = RepoSinif.GenelListe().Select(x => new SelectListItem
            {
                Text = x.Sube,
                Value = x.SinifID.ToString()
            });
            return View(sm);
        }
        [HttpPost]
        public ActionResult Ekle(SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Ogrenci o = new Ogrenci();
                sm.Siniflar = RepoSinif.Listele().FirstOrDefault(x=>x.SinifID == model.Ogrenci.SinifID);
                o.OgrenciAd = model.Ogrenci.OgrenciAd;
                o.OgrenciSoyad = model.Ogrenci.OgrenciSoyad;
                o.OgrenciYas = model.Ogrenci.OgrenciYas;
                o.OgrenciAdres = model.Ogrenci.OgrenciAdres;
                o.SinifID = model.Ogrenci.SinifID;
                sm.Siniflar.SinifMevcudu += 1;
                RepoSinif.Guncel();
                RepoOgr.Ekle(o);
                RepoOgr.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}