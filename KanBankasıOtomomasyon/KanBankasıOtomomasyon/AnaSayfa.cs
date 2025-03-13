using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankasıOtomomasyon
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn= new Donor();
            dn.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            KanBagisi kb=new KanBagisi();
            kb.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonörListesi dl= new DonörListesi();
            dl.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hasta hst= new Hasta();
            hst.Show();
            this.Hide();  
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HastaListesi hstl= new HastaListesi();
            hstl.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStoğu ks= new KanStoğu();
            ks.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi kt=new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kp=new KontrolPaneli();
            kp.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }
    }
}
