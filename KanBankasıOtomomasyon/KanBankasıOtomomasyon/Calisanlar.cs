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
    public partial class Calisanlar : Form
    {
        public Calisanlar()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void label9_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }
        private void Reset()
        {
            CAdSoyad.Text = "";
            CSifre.Text = "";
            key = 0;
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select*from CalisanTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CalisanDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (CAdSoyad.Text==""||CSifre.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into CalisanTBL values('" + CAdSoyad.Text + "', '" + CSifre.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Kaydedildi");
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
        int key = 0;
        private void CalisanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CAdSoyad.Text = CalisanDGV.SelectedRows[0].Cells[1].Value.ToString();
            CSifre.Text = CalisanDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (CAdSoyad.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CalisanDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Çalışanı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from CalisanTBL where CalNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Silindi");
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (CAdSoyad.Text==""|| CSifre.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update CalisanTBL set Calid='" + CAdSoyad.Text + "',Calsif='" + CSifre.Text + "' where CalNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Güncellendi");
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
            Calisanlar cls=  new Calisanlar();
            cls.Show();
            this.Hide();
        }
    }
}
