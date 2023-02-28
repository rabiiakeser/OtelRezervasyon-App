using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }

        private void rezervasyonlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervasyonlar frmRezervasyonlar = new frmRezervasyonlar();
            frmRezervasyonlar.Show();
        }

        private void odaListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOdalar frmOdalar = new frmOdalar();
            frmOdalar.Show();
        }

        private void odaTipleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOdaTipleri frmOdaTipleri = new frmOdaTipleri();
            frmOdaTipleri.Show();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMusteriler frmMusteriler = new frmMusteriler();
            frmMusteriler.Show();
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullanicilar frmKullanicilar = new frmKullanicilar();
            frmKullanicilar.Show();
        }
    }
}
