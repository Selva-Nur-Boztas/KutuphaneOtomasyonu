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

namespace kütüphaneotomasyonu
{
    public partial class kullaniciigiris : Form
    {
        public kullaniciigiris()
        {
            InitializeComponent();
        }


        //    string kullaniciadi = tb_kullaniciadi.Text;
        //    string sifre = tb_sifre.Text;

        //    if (kullaniciadi == "selva" && sifre == "123")
        //    {

        //        anamenü frm = new anamenü();
        //        this.Visible = false;
        //        frm.ShowDialog();
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Hatalı giriş yaptınız");
        //    }
        //}

        private void kullaniciigiris_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglan = new SqlConnection();
        private void btn_kullanıcıgiris_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_kullaniciadi.Text) || 
                String.IsNullOrWhiteSpace(tb_sifre.Text))
            {
                MessageBox.Show("Giriş Başarısız! Eksiksiz Giriniz!", "..:: HATA ::..", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                // Sql bağlantı cümlemiz.
                baglan.ConnectionString = @"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True";
                baglan.Open(); // Bağlantıyı aç.
                // Sorgumuz. 
                string sql = "SELECT * FROM Kullanici WHERE Kullaniciadi=@KAdi AND sifre=@KSifre";     
                SqlParameter komut = new SqlParameter("@KAdi", tb_kullaniciadi.Text); 
                SqlParameter komut1 = new SqlParameter("@KSifre", tb_sifre.Text);
                SqlCommand cmd = new SqlCommand(sql, baglan);
                cmd.Parameters.Add(komut);
                cmd.Parameters.Add(komut1); 
                DataTable dt = new DataTable(); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
 
                if (dt.Rows.Count > 0)
                {
                    anamenü frm = new anamenü();
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Veritabanında böyle bir kullanıcı bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
            
        private void tb_sifre_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tb_sifre_TextChanged(object sender, EventArgs e)
        {

        }





        private void kullaniciigiris_Load_1(object sender, EventArgs e)
        {

        }



    }
}