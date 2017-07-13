using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    public class Numara
    {
        private int _siraNumara; //müsteri tipine göre verilecek numara
        private int _genelNumara; // index numarası(geliş sırası)
        private IMusteri _musteri;


        public IMusteri Musteri
        {
            get
            {
                return _musteri;
            }

            set
            {
                _musteri = value;

            }
        }

        public Numara(int sira,int genel,IMusteri musteri)
        {
            this.GenelNumara = genel;
            this.SiraNumara = sira;
            this.Musteri = musteri; //tip ve tc bilgisi gelir
        }

        //Operator aşırı yükleme. 
        //Public olmak zorunda. Static olmak zorunda
        //Parametrelerden en az biri kullanıldığı sınıf tipinden olmak zorunda.
        //İki parametreden fazla kullanılamaz.
        //Mantıksal operatörler kullanılırken bool tipinde olmak zorunda.
        //Mantıksal operatörler kullanılırken kullanılan operatörün tersi de yazılmak zorunda.
        //Geriye nesne döndürmek zorunda.
        // Tanımladık ama kuyruk yapımız olduğu için bizim isteklerimizi karşıladığı için bunu kullanmadık.
        public static bool operator <(Numara numara1, Numara numara2)
        {
            return numara1.GenelNumara < numara2.GenelNumara;
        }

        public static bool operator >(Numara numara1, Numara numara2)
        {
            return numara1.GenelNumara > numara2.GenelNumara;
        }
        
        public int GenelNumara
        {
            get
            {
                return _genelNumara;
            }

            set
            {
                _genelNumara = value;
            }
        }

        public int SiraNumara
        {
            get
            {
                return _siraNumara;
            }

            set
            {
                _siraNumara = value;
            }
        }

        public override string ToString()
        {
            return Musteri.ToString()+ "\nNumara: " + this.SiraNumara +"\nGenel Numara: "+this.GenelNumara;
        }
    }
}
