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
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void Reset()
        {
            DnrAdSoyad.Text = "";
            DnrYas.Text = "";
            cmbDnrCinsiyet.SelectedIndex = -1;
            DnrTel.Text = "";
            cmbDnrKG.SelectedIndex = -1;
            DnrAdres.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (DnrAdSoyad.Text == "" || DnrYas.Text == "" || cmbDnrCinsiyet.SelectedIndex == -1 || DnrTel.Text == "" || cmbDnrKG.SelectedIndex == -1 || DnrAdres.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into DonorTBL values('" + DnrAdSoyad.Text + "', " + DnrYas.Text + ", '" + cmbDnrCinsiyet.SelectedItem.ToString() + "', '" + DnrTel.Text + "', '" + DnrAdres.Text + "', '" + cmbDnrKG.SelectedItem.ToString() + "' )";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Donor Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dnr= new Donor();
            dnr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonörListesi dnl= new DonörListesi();
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
            KontrolPaneli kp=new KontrolPaneli();
            kp.Show();
            kp.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            KanBagisi kb=new KanBagisi();
            kb.Show();
            this.Hide();
        }
    }
}
