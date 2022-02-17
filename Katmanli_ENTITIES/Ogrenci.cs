using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_ENTITIES
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        [Required]
        public string OgrenciAd { get; set; }
        [Required]
        public string OgrenciSoyad { get; set; }
        [StringLength(200)]
        public string OgrenciAdres { get; set; }
        public DateTime OgrenciYas { get; set; }
        [ForeignKey("Sinif")]
        public int SinifID { get; set; }
        public Sinif Sinif { get; set; }
    }
}
