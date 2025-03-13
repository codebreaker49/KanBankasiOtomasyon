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
    public partial class KanTransferi : Form
    {
        public KanTransferi()
        {
            InitializeComponent();
            fillHastaCb();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HNum from HastaTBL", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt= new DataTable();
            dt.Columns.Add("HNum", typeof(int));
            dt.Load(rdr);
            cmbHastaid.ValueMember = "HNum";
            cmbHastaid.DataSource = dt;
            baglanti.Close();
        }
        private void VeriAl()
        {
            baglanti.Open();
            string query = "select*from HastaTBL where HNum=" + cmbHastaid.SelectedValue.ToString() + "";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                hstAdSoyad.Text = dr["HAdSoyad"].ToString();
                hstKG.Text = dr["HKGrup"].ToString();
            }
            baglanti.Close();
        }
        int stokk=0;
        private void Stok(string KGrup)
        {
            baglanti.Open();
            string query = "select*from KanTBL where KGrup='" + KGrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stokk = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }
        private void KanTransferi_Load(object sender, EventArgs e)
        {

        }

        private void cmbHastaid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(hstKG.Text);
            if (stokk > 0)
            {
                Transferbtn.Visible = true;
                Uygunlbl.Text = "Stok Uygun";
                Uygunlbl.Visible = true;
            }
            else
            {
                Uygunlbl.Text = "Stok Uygun Değil";
                Uygunlbl.Visible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
        }
        private void Reset()
        {
            hstAdSoyad.Text = "";
            hstKG.Text = "";
            Uygunlbl.Visible = false;
            Transferbtn.Visible = false;
        }
        private void KanGuncelle()
        {
            int yenistok = stokk - 1;
            try
            {
                string query = "update KanTBL set KStok=" + yenistok + " where KGrup='" + hstKG.Text + "';";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                //MessageBox.Show("Hasta Başarıyla Güncellendi");
                baglanti.Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Ex.Message");
            }
        }
        private void Transferbtn_Click(object sender, EventArgs e)
        {
                try
                {
                int yenistok = stokk - 1;
                    string query = "insert into TransferTBL values('" +hstAdSoyad.Text+  "', '"+hstKG.Text+ "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer Başarılı");
                    baglanti.Close();
                    Stok(hstKG.Text);
                    KanGuncelle();
                    Reset();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStoğu ks= new KanStoğu();
            ks.Show();
            this.Hide();
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

        private void label4_Click(object sender, EventArgs e)
        {
            HastaListesi hsl= new HastaListesi();
            hsl.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi ks= new KanTransferi();
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

        private void label14_Click(object sender, EventArgs e)
        {
            KanBagisi kb= new KanBagisi();
            kb.Show();
            this.Hide();
        }
    }
}

