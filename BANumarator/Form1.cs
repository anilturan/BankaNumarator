using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANumarator
{
    public partial class Form1 : Form
    {
        Gise gise1 = new Gise();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TipNesneUret musteriUret = new TipNesneUret();
            Musteri musteri = musteriUret.MusteriNesneUret("12345678901");
            Numarator numarator = Numarator.Instance;
            numarator.Musteri = musteri;
            MessageBox.Show(musteri.NumaraAl().ToString()); 
        }

        private void btnMusteriGetir_Click(object sender, EventArgs e)
        {
            gise1.YeniNumaraCagir();
        }
    }
}
