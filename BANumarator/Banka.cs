using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANumarator
{
    public class Banka
    {
        //Banka nesnesinden 1 tane oluşacağı için Singleton Pattern kullanıldı. 
        private static Banka _instance;

        public static Banka Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Banka();
                return _instance;
            }
        }

        // MusterilerListesi nesnesini döndürüyor
        private Musteriler MusteriListesi
        {
            get
            {
                return Musteriler.Instance;
            }
            
        }

        //Başka sınıflardan ulaşılamasın diye private yapıldı.
        private Banka()
        {
           
        }




    }
}
