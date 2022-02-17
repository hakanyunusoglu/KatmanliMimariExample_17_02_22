using Katmanli_ENTITIES;
using Katmanli_REP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari_BL
{//Business Layer: İş kuralları yazılır. Karar mekanizmasıdır.
    public class Repository
    {
        public class OgrenciRepository:BaseRepository<Ogrenci>
        {

        }
        public class SinifRepository : BaseRepository<Sinif>
        {

        }
    }
}
