using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
   public class Musteri : IMusteri
    {


        private string _tcKimlik;
        
        public string TcKimlik
        {
            get
            {
                return _tcKimlik;
            }

            set
            {
                //Tc nin 11 haneli olup olmadığını kontrol ediyoruz
                if (value.Length != 11)
                {
                    throw new Exception("Tc 11 haneli olmalı.");
                }
                _tcKimlik = value;
            }
        }

     
        //Musteri sınıfının yapıcı metodu tc parametresini alır ve property olan tc ye bu değeri atar.
        public Musteri(string tc)
        {
            this.TcKimlik = tc;
        }

        
        public override string ToString()
        {
            return "Musteri Tipi : " + this.GetType().Name + "\nMusteri TC : " + this.TcKimlik + " ";
        }

       // Numarator sınıfının içerisindeki NumaraUret metodunu tetiklemesi için bir event delegate tanımladık. delegate Musteri tipinde parametre alacak ve geriye uretilen numarayı döndürecek.

        public delegate Numara NumaraDondurDel(Musteri musteri);
        public event NumaraDondurDel numaraDondurEvent;

        //NumaraAl metodu çalıştığında numaraDondurEvent eventi tetiklenmiş olacak. ve gidip numaratordeki musteri propertysinin içerisinde handler olacak o da numaraUret metodunu çalıştıracak.
        public Numara NumaraAl()
        {
            if (numaraDondurEvent != null)
                return numaraDondurEvent(this);
            else
                throw new Exception("Atanmış fonksiyon yok");
        }
    }
}
