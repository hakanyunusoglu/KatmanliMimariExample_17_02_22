using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_ENTITIES
{
    public class Sinif
    {
        public int SinifID { get; set; }
        //public string Kademe { get; set; }
        [Required]
        public string Sube { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }
    }
}
