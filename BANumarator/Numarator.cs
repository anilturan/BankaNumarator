using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    class Numarator 
    {
        //Singleton pattern kullanmak için tanımladık.
        private static Numarator _instance;
        Musteri _musteri;

        //müşteri tiplerine göre numara belirleme
        private const int VIPNUMARABASLANGIC = 0;
        private const int VIPNUMARABITIS = 999;
        private const int BIREYSELNUMARABASLANGIC = 1000;
        private const int BIREYSELNUMARABITIS = 1999;
        private const int GISENUMARABASLANGIC = 2000;
        private const int GISENUMARABITIS = 2999;

        //Sayaç tanımları
        // Bu tanımları hem genel sayac ı bulmak için kullanacağız hem de gişe ile bireysel müşteri geçişlerinde(3 gişeden sonra 1 bireysel)
        private int _vipSayac;
        private int _bireyselSayac;
        private int _giseSayac;

        private int GenelSayac
        {
            get
            {
                return BireyselSayac + VipSayac + GiseSayac;
            }
        }


        private Numarator()
        {

        }

        //Singleton
        public static Numarator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Numarator();
                return _instance;
            }
        }

        private int VipSayac
        {
            get
            {
                return _vipSayac;
            }

            set
            {
                _vipSayac = value;
            }
        }

        private int BireyselSayac
        {
            get
            {
                return _bireyselSayac;
            }

            set
            {
                _bireyselSayac = value;
            }
        }

        private int GiseSayac
        {
            get
            {
                return _giseSayac;
            }

            set
            {
                _giseSayac = value;
            }
        }

        //Banka tipinde 1 tane banka nesnesi oluşturuldu.
        private Banka Banka
        {
            get
            {
                return Banka.Instance;
            }
        }

        //Sıra tipinde MusteriKuyruk nesnesi oluşturuldu. 
        private Sira MusteriKuyruk
        {
            get
            {
                return Sira.Instance;
            }
        }

        public Musteri Musteri
        {
            get
            {
                return _musteri;
            }

            set
            {
                _musteri = value;
                _musteri.numaraDondurEvent += _musteri_numaraDondurEvent; // Musteri içerisindeki NumaraAl metodu için olay yakalayan handler
                    
            }
        }
       
        private Numara _musteri_numaraDondurEvent(Musteri musteri)
        {
            return this.NumaraUret(musteri);
        }

       

        //Müşterilerin tc kimlik no'larına göre tip sorgusu yapıp,(Tip sorgusu MusteriTip sınfında yeni musteri uretme TipNesneUret sınıfında oluşturuldu)
        //Musteriye göre de numara ataması yapıldı.
        public Numara NumaraUret(Musteri musteri)
        {
            int numara;
            
            switch (musteri.GetType().Name)
            {
                case "VipMusteri":
                    if (VipSayac == VIPNUMARABITIS)
                    {
                        VipSayac = VIPNUMARABASLANGIC;
                    }
                    numara = VIPNUMARABASLANGIC + (++this.VipSayac);
                    break;

                case "BireyselMusteri":
                    if (BireyselSayac == BIREYSELNUMARABITIS)
                    {
                        BireyselSayac = BIREYSELNUMARABASLANGIC;
                    }
                    numara = BIREYSELNUMARABASLANGIC + (++this.BireyselSayac);
                    break;

                case "GiseMusteri":
                    if (GiseSayac == GISENUMARABITIS)
                    {
                        GiseSayac = GISENUMARABASLANGIC;
                    }
                    numara = GISENUMARABASLANGIC + (++this.GiseSayac);
                    break;

                default:
                    throw new Exception("Numara üretilemedi.");
            }

            //Numara:Sıra numarası, GenelSayac:Genel numara
            Numara yeniNumara = new Numara(numara, this.GenelSayac, musteri);
            MusteriKuyruk.SiraEkleme(yeniNumara); //Gelen numarayı sıraya ekledik.
            return yeniNumara;  // Burada da Musteriye numarayı dondurduk(yani vermiş oluyoruz. Numara Al metoduyla)
        }

    }
}
