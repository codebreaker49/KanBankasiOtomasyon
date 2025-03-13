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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin al= new AdminLogin();
            al.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CalisanTBL where Calid='" + txtKullanici.Text + "' and Calsif='" + txtSifre.Text + "'", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                AnaSayfa ana= new AnaSayfa();
                ana.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı yada Şifre");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
