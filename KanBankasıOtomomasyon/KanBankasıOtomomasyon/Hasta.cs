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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void Reset()
        {
            HAdSoya.Text = "";
            HYas.Text = "";
            cmbHCinsiyet.SelectedIndex = -1;
            HTel.Text = "";
            cmbHKG.SelectedIndex = -1;
            HAdres.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdSoya.Text == "" || HYas.Text == "" || cmbHCinsiyet.SelectedIndex == -1 || HTel.Text == "" || cmbHKG.SelectedIndex == -1 || HAdres.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into HastaTBL values('" + HAdSoya.Text + "', " + HYas.Text + ", '" + HTel.Text + "', '" + cmbHCinsiyet.SelectedItem.ToString() + "', '" + cmbHKG.SelectedItem.ToString() + "', '" + HAdres.Text + "' )";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HastaListesi HL= new HastaListesi();
            HL.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi kt= new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hasta hst= new Hasta();
            hst.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonörListesi dnl= new DonörListesi();
            dnl.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn= new Donor();
            dn.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStoğu ks= new KanStoğu();
            ks.Show();
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
