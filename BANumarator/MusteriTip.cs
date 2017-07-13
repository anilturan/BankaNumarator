using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    // Musteri Tip Sorgulama ve Tip enum ı bu sınıf içerisinde oluşturuldu.
    //Müşteri tiplerini belirlediğimiz enum 
    public enum Tip
    {
        Yuksek = 1,
        Orta = 2,
        Dusuk = 3
    }
 
    public class MusteriTip
    {

        Musteriler musteri = Musteriler.Instance;

        //Bankanın müşterilerinin tiplerini sorgulayan method
        //Eğer müşterinin tc si müşterilerin içinde bulunuyorsa Tipini bulunmuyorsa da DüşükTip döndürmektedir.
        //Müşterilerin içinde girilen tc yoksa hata alıp catch e düşecek
        public Tip MusteriTipSorgula(string tc)
        {
            try
            {
                return this.musteri.MusteriListesi[tc];
            }

            catch (Exception)
            {
                this.musteri.MusteriListesi.Add(tc, Tip.Orta); // Bir kere gişe de işlem yapmış olan müşteriyi Banka bundan sonra ki işlemleri için  kendi bireysel müşterisi olarak görmesi gerekiyor  bu yuzden listeye orta dereceli müşteri olarak ekledim.
                return Tip.Dusuk;
            }
        }
    }
}
