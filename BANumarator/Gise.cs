using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANumarator
{
    public class Gise
    {
        //Musteriyi (Yani musteriye ait olan numarayı) çağıran sınıf.





        // Singleton olarak tanımladığımız Sira sınıfının nesnesini burada donduruyoruz. 
        private Sira MusteriKuyruk
        {
            get
            {
                return Sira.Instance;
            }
        }

        //Kuyruktan  çıkartılan numarayı çağırır.
        public void YeniNumaraCagir()
        {
            try
            {
                MessageBox.Show(this.MusteriKuyruk.NumaraCikar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
