using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KanBankasıOtomomasyon
{
    public partial class KanBagisi : Form
    {
        public KanBagisi()
        {
            InitializeComponent();
            uyeler();
            KanStok();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select*from DonorTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KBagisDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void KanStok()
        {
            baglanti.Open();
            string query = "select*from KanTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void KanBagisi_Load(object sender, EventArgs e)
        {

        }
        int eskistok;
        private void Stok(string KGrup)
        {
            baglanti.Open();
            string query = "select*from KanTBL where KGrup='" + KGrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                eskistok = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }
        private void KBagisDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DnrAdSoyad.Text = KBagisDGV.SelectedRows[0].Cells[1].Value.ToString();
            DnrKG.Text = KBagisDGV.SelectedRows[0].Cells[6].Value.ToString();
            Stok(DnrKG.Text);
        }
        private void Reset()
        {
            DnrAdSoyad.Text = "";
            DnrKG.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (DnrAdSoyad.Text == "")
            {
                MessageBox.Show("Bir Donor Seçiniz");
            }
            else
            {
                try
                {
                    int stok = eskistok + 1;
                    string query = "update KanTBL set KStok='" + stok + "' where KGrup='" + DnrKG.Text + "';";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bağış Başarılı");
                    baglanti.Close();
                    Reset();
                    KanStok();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
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

        private void label13_Click(object sender, EventArgs e)
        {
            KanBagisi kb= new KanBagisi();
            kb.Show();
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
            KanTransferi kst=new KanTransferi();
            kst.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kp= new KontrolPaneli();
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
