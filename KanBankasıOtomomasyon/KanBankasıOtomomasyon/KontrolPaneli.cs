using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankasıOtomomasyon
{
    public partial class KontrolPaneli : Form
    {
        public KontrolPaneli()
        {
            InitializeComponent();
            Vericek();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void Vericek()
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from DonorTBL", baglanti);
            DataTable dt= new DataTable();
            sda.Fill(dt);
            Donorlbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*)from TransferTBL", baglanti);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Transferlbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*)from CalisanTBL", baglanti);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Kullanicilbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*)from KanTBL", baglanti);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int Kstok = Convert.ToInt32(dt3.Rows[0][0].ToString());
            totalLbl.Text = "" + Kstok;
            SqlDataAdapter sda4 = new SqlDataAdapter("select KStok from KanTBL where KGrup='"+"AB+"+"'", baglanti);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OpLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / Kstok) * 100;
            OplusBar.Value = Convert.ToInt32(OplusPercentage);
            SqlDataAdapter sda5 = new SqlDataAdapter("select KStok from KanTBL where KGrup='" + "0+" + "'", baglanti);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABpLbl.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / Kstok) * 100;
            ABplusBar.Value = Convert.ToInt32(ABplusPercentage);
            SqlDataAdapter sda6 = new SqlDataAdapter("select KStok from KanTBL where KGrup='" + "0-" + "'", baglanti);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OminLbl.Text = dt6.Rows[0][0].ToString();
            double OmPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / Kstok) * 100;
            OminBar.Value = Convert.ToInt32(OmPercentage);
            SqlDataAdapter sda7 = new SqlDataAdapter("select KStok from KanTBL where KGrup='" + "AB-" + "'", baglanti);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABminLbl.Text = dt7.Rows[0][0].ToString();
            double ABminPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / Kstok) * 100;
            ABminBar.Value = Convert.ToInt32(ABminPercentage);
            baglanti.Close();
        }
        private void KontrolPaneli_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn= new Donor();
            dn.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonörListesi dnl = new DonörListesi();
            dnl.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hasta hs= new Hasta();
            hs.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HastaListesi hsl= new HastaListesi();
            hsl.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStoğu ks=new KanStoğu();
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
            KontrolPaneli ktp= new KontrolPaneli();
            ktp.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            KanBagisi kb= new KanBagisi();
            kb.Show();
            this.Hide();
        }
    }
}
