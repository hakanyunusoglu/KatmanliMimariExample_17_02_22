using Katmanli_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanliMimariExample_17_02_22.Models
{
    public class SinifModel
    {
        public List<Sinif> sList { get; set; }
        public Sinif Siniflar { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public List<Ogrenci> oList { get; set; }

        public IEnumerable<SelectListItem> SinifListesi { get; set; }
    }
}