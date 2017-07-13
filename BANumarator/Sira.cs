using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BANumarator
{
    //müşteriyle gişe arasındaki bağlantıyı sağlayan sınıf.

    class Sira
    {
        private static Sira _instance;
        private int _giseSayac;

        //İlk gelen ilk çıkar kuralını sağlayan "queue" koleksiyonuyla müşteri tipine göre 3 farklı kuyruk oluşturduk.
        //queue koleksiyonu kullanma nedenimiz List'ten farklı olarak sadece en baştaki elemana ulaşmak istediğimiz için.
        Queue<Numara> _kuyrukVip;
        Queue<Numara> _kuyrukBireysel;
        Queue<Numara> _kuyrukGise;

        private Sira()
        {

        }

        public static Sira Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sira();
                return _instance;
            }
        }

        private Queue<Numara> KuyrukVip
        {
            get
            {
                return _kuyrukVip;
            }

            set
            {
                _kuyrukVip = value;
            }
        }

        private Queue<Numara> KuyrukBireysel
        {
            get
            {
                return _kuyrukBireysel;
            }

            set
            {
                _kuyrukBireysel = value;
            }
        }

        private Queue<Numara> KuyrukGise
        {
            get
            {
                return _kuyrukGise;
            }

            set
            {
                _kuyrukGise = value;
            }
        }

        public int GiseSayac
        {
            get
            {
                return _giseSayac;
            }

            set
            {
               if (value < 0)
               {
                   throw new Exception("Sayac negatif olamaz");
               }
                    _giseSayac = value;
            }
        }

        private void VipNumaraEkle(Numara numara)
        {
            try
            {
                //Enqueue metoduyla kuyruğa numara eklendi.
                this.KuyrukVip.Enqueue(numara);
            }
            catch (Exception)
            {
                //İlk nesne oluşmadan numara eklenemeyeceği için nesne burada oluşturuldu.
                this.KuyrukVip = new Queue<Numara>();
                this.VipNumaraEkle(numara);
            }
        }

        private Numara VipMusteriCikar()
        {
            //İşlemi biten müşteri sıradan çıkarıldı.
            return this.KuyrukVip.Dequeue();
        }

        private void BireyselNumaraEkle(Numara numara)
        {
            try
            {
                this.KuyrukBireysel.Enqueue(numara);
            }
            catch (Exception)
            {

                this.KuyrukBireysel = new Queue<Numara>();
                this.BireyselNumaraEkle(numara);
            }
        }

        private Numara BireyselMusteriCikar()
        {
            return this.KuyrukBireysel.Dequeue();
        }

        private void GiseNumaraEkle(Numara numara)
        {
            try
            {
                this.KuyrukGise.Enqueue(numara);
            }
            catch (Exception)
            {
                this.KuyrukGise = new Queue<Numara>();
                this.GiseNumaraEkle(numara);
            }
        }

        private Numara GiseMusteriCikar()
        {
            return this.KuyrukGise.Dequeue();
        }

        //Müşteri nesnelerinin tiplerine göre kuyruğa eklendi
        public void SiraEkleme(Numara numara)
        {
            switch (numara.Musteri.GetType().Name)
            {
                case "VipMusteri":
                    this.VipNumaraEkle(numara);
                    break;
                case "BireyselMusteri":
                    this.BireyselNumaraEkle(numara);
                    break;
                case "GiseMusteri":
                    this.GiseNumaraEkle(numara);
                    break;
            }
        }


        public Numara NumaraCikar()
        {
            //Kuyrukta herhangi bir müşteri var mı?
                if (this.KuyrukVip.Count() + this.KuyrukBireysel.Count() + this.KuyrukGise.Count() > 0)
                {
                    //Vip müşteri varsa hepsini çağır.
                    if (this.KuyrukVip.Count() > 0)
                    {
                        //İşlemi biteni kuyruktan çıkar.
                        return this.VipMusteriCikar();
                    }

                    //Gişe ve bireysel arasındaki ilişki.
                    //Gişe sayaç 3'ten küçük olduğu sürece, gişe ve bireysel müşteri varsa 3 gişeden sonra 1 bireysel müşteri çağırıldı.
                    else if (this.GiseSayac < 3 && (this.KuyrukGise.Count() > 0 && this.KuyrukBireysel.Count() > 0))
                    {
                        //peek:indise göre kuyruğun başındaki elemanı getirir, çıkartma yapmaz.
                            if (this.KuyrukBireysel.Peek() < this.KuyrukGise.Peek())
                            {
                                //bireysel müşteri işleme girdikten sonra gişe sayacı sıfırlanır.
                                this.GiseSayac = 0;
                                return this.BireyselMusteriCikar();
                            }

                            else
                            {
                                this.GiseSayac++;
                                return this.GiseMusteriCikar();
                            }
                    }

                    //sadece bireysel müşteri olma durumu
                    else if (this.KuyrukBireysel.Count() > 0 )
                    {
                        this.GiseSayac = 0;
                        return this.BireyselMusteriCikar();                    
                    }

                    else 
                    {
                        this.GiseSayac++;
                        return this.GiseMusteriCikar();
                    }
                }

                else
                {
                    throw new Exception("Kuyrukta eleman kalmadı");
                }
            
        }
    }
}
