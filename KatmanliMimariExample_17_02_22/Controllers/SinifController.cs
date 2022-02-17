using Katmanli_ENTITIES;
using Katmanli_REP;
using KatmanliMimariExample_17_02_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static KatmanliMimari_BL.Repository;

namespace KatmanliMimariExample_17_02_22.Controllers
{
    public class SinifController : Controller
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
            sm.sList = RepoSinif.GenelListe().Where(x=> x.Sube.Contains(name)).ToList();
          
            return View(sm);

        }
        public ActionResult Detay(int id)
        {
            sm.Siniflar = RepoSinif.Bul(id);
            sm.oList = RepoOgr.Listele().Where(x=>x.SinifID == id).ToList();
            return View(sm);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Sinif s = new Sinif();
                sm.oList = RepoOgr.GenelListe().Where(x => x.SinifID == model.Siniflar.SinifID).ToList();
                s.Sube = model.Siniflar.Sube;
                if (sm.oList == null || sm.oList.Count() == 0)
                {
                    s.SinifMevcudu = 0;
                }
                else
                {
                    s.SinifMevcudu = sm.oList.Count();
                }
                RepoSinif.Ekle(s);
                RepoSinif.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            Sinif s = RepoSinif.Bul(id);
            RepoSinif.Sil(s);
            RepoSinif.Guncel();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            sm.Siniflar = RepoSinif.Bul(id);
            return View(sm);
        }
        [HttpPost]
        public ActionResult Guncelle(int id, SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Sinif secilisinif = RepoSinif.Bul(id);
                secilisinif.Sube = model.Siniflar.Sube;
                RepoSinif.Guncel();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult Sec()
        {
            SinifModel s = new SinifModel();
            s.sList = RepoSinif.GenelListe().OrderBy(x => x.SinifID).Skip(3).Take(5).ToList();
            return View(s);
        }
    }
}