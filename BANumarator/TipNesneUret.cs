using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    class TipNesneUret
    {
        MusteriTip musteriTip = new MusteriTip();

        //Tek elden yönetim. Yapılan tip sorgusuna göre nesne oluşturur.
        public Musteri MusteriNesneUret(string tc)
        {
            switch (musteriTip.MusteriTipSorgula(tc))
            {
                case Tip.Yuksek:
                    return new VipMusteri(tc);
                case Tip.Orta:
                    return new BireyselMusteri(tc);
                default:
                    return new GiseMusteri(tc);
            }
        }
    }
}
