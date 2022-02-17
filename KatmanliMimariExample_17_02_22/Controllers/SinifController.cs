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
        SinifModel sm = new SinifModel();

        public ActionResult Index()
        {
            sm.sList = RepoSinif.Listele();
            return View(sm);
        }
    }
}