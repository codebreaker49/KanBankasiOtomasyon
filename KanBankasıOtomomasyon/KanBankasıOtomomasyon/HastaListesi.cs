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
    public partial class HastaListesi : Form
    {
        public HastaListesi()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select*from HastaTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void HastaListesi_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HstAdSoyad.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HstYas.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HstTel.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            cmbHstCinsiyet.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            cmbHstKG.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HstAdres.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (HstAdSoyad.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            HstAdSoyad.Text = "";
            HstYas.Text = "";
            cmbHstCinsiyet.SelectedIndex = -1;
            HstTel.Text = "";
            cmbHstKG.SelectedIndex = -1;
            HstAdres.Text = "";
            key = 0;
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from HastaTBL where HNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    baglanti.Close();
                    Reset();
                    uyeler();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HstAdSoyad.Text == "" || HstYas.Text == "" || cmbHstCinsiyet.SelectedIndex == -1 || HstTel.Text == "" || cmbHstKG.SelectedIndex == -1 || HstAdres.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update HastaTBL set HAdSoyad='" + HstAdSoyad.Text + "',HYas=  " + HstYas.Text + ", HTelefon='" + HstTel.Text + "', HCinsiyet='" + cmbHstCinsiyet.SelectedItem.ToString() + "', HKGrup='" + cmbHstKG.SelectedItem.ToString() + "', HAdres='" + HstAdres.Text + "' where HNum=" + key + "; ";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                    baglanti.Close();
                    Reset();
                    uyeler();
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
            DonörListesi dnl= new DonörListesi();
            dnl.Show();
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
            KanTransferi kt= new KanTransferi();
            kt.Show();
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

        private void label17_Click(object sender, EventArgs e)
        {
            KanBagisi kb= new KanBagisi();
            kb.Show();
            this.Hide();
        }
    }
}
