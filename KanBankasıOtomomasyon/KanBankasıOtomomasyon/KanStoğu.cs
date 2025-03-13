﻿using System;
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
    public partial class KanStoğu : Form
    {
        public KanStoğu()
        {
            InitializeComponent();
            KanStok();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-OR3T0EKC\SQLEXPRESS;Initial Catalog=KanBankasiDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
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
        private void KanStoğu_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi kant = new KanTransferi();
            kant.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
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

        private void label11_Click(object sender, EventArgs e)
        {
            KanBagisi kb= new KanBagisi();
            kb.Show();
            this.Hide();
        }
    }
}
