using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    public class Musteriler
    {
        //Müşterileri tiplerine ve tc lerine göre saklayan liste
        Dictionary<string, Tip> _musteriListesi = new Dictionary<string, Tip>();

        // Bu sınıfı da singleton yaptık.Çünkü bu sınıf tek olmalı. 
        private static Musteriler _instance;

        public static Musteriler Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new Musteriler();
                }
                return _instance;
            }
        }

        //
        public Dictionary<string, Tip> MusteriListesi
        {
            get
            {
                return _musteriListesi;
            }

            set
            {
                _musteriListesi = value;
            }
        }

        // Constructor da MusteriEkle metodunu çağırdıkkii program yüklendiği anda müşterilerde yüklenmiş olsun.
        private Musteriler()
        {
            this.MusteriEkle();
        }


        //Class içerisinde metot kullanılmadan musteriListesi'ne ekleme yapılamayacağı için bir metot oluşturarak müşteri eklenildi.
        private void MusteriEkle()
        {
            MusteriListesi.Add("12345678913", Tip.Orta);
            MusteriListesi.Add("12345678912", Tip.Yuksek);
            MusteriListesi.Add("12345678914", Tip.Orta);
            MusteriListesi.Add("12345678911", Tip.Yuksek);
            MusteriListesi.Add("12345678915", Tip.Yuksek);
            MusteriListesi.Add("12345678916", Tip.Orta);
            MusteriListesi.Add("12345678917", Tip.Yuksek);
            MusteriListesi.Add("12345678918", Tip.Yuksek);
            MusteriListesi.Add("12345678919", Tip.Orta);
            MusteriListesi.Add("12345678920", Tip.Orta);
        }
    }
}
