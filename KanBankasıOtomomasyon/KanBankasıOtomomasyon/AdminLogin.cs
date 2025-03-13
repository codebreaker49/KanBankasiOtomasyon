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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txtAdminSifre.Text == "")
            {
                MessageBox.Show("Admin Şifrenizi Giriniz");
            }
            else if(txtAdminSifre.Text=="0678")
            {
                Calisanlar cal= new Calisanlar();
                cal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre");
                txtAdminSifre.Text = "";
            }
        }
    }
}
