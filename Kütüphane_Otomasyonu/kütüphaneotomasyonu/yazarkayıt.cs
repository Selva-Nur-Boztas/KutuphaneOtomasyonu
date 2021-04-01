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


namespace kütüphaneotomasyonu
{
    public partial class yazarkayıt : Form
    {
        public yazarkayıt()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        
        SqlCommand komut;
        object yazarno, ad,soyad;
        private void yazarkayıt_Load(object sender, EventArgs e)
        {
            rb_ad.Checked = true;

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    KayitlariGetir();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıtları Listelemede Hata: " + ex.Message);
            }
        }

        private void KayitlariGetir()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Yazarlar", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "yazarkayıt");
            dataGridView_yazarkyt.DataSource = ds.Tables["yazarkayıt"];
        }

        private void btn_yazarkytkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Yazarlar(ad,soyad) values (@2,@3)";
                komut = new SqlCommand(kaydet, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_yazarnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar, 50).Value = tb_Yazarad.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Yazarsoyad.Text;
                
                komut.ExecuteNonQuery();
                KayitlariGetir();
                temizle();
                MessageBox.Show("Kaydedildi");
            }


            catch (Exception ex)
            {
                MessageBox.Show("Kaydetmede Hata:" + ex.Message);
            }
        }

        private void btn_yazarkytgüncellestir_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_yazarkyt.CurrentRow.Cells["yazarnumara"].Value.ToString();

                string guncelle = "UPDATE Yazarlar SET ad=@2 , soyad=@3 WHERE yazarnumara=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_yazarnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar,50).Value = tb_Yazarad.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar,50).Value = tb_Yazarsoyad.Text;

                komut.ExecuteNonQuery();

                KayitlariGetir();

                MessageBox.Show("Seçili Kayıt Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }
        }

        private void btn_uyelistele_Click(object sender, EventArgs e)
        {
            try
            {
                KayitlariGetir();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Listeleme İşleminde Hata ", ex.Message);
            }
        }
        private void btn_yazarkytanamenu_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_yazarkytcikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yazarkyttemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {
            tb_yazarnumara.Clear();
            tb_Yazarad.Clear();
            tb_Yazarsoyad.Clear();
        }

        private void btn_yazarkytsil_Click(object sender, EventArgs e)
        {
            if (dataGridView_yazarkyt.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_yazarkyt.CurrentRow.Cells["yazarnumara"].Value.ToString();

                string sil = "DELETE From Yazarlar WHERE yazarnumara=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }
        private void tb_yazarkytarama_TextChanged(object sender, EventArgs e)
        {
            if(tb_yazarkytarama.Text!="")
            {
                if(rb_ad.Checked)
                    aramaYap(tb_yazarkytarama.Text,"ad");
                else if(rb_soyad.Checked)
                    aramaYap(tb_yazarkytarama.Text,"soyad");
            }
            else
            {
                KayitlariGetir();
            }
        }
        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Yazarlar ";

            if (tb_yazarkytarama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_yazarkytarama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
        }
        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Yazarlar");
            dataGridView_yazarkyt.DataSource = ds.Tables["Yazarlar"];
        }
        private void rb_ad_CheckedChanged(object sender, EventArgs e)
        {
            tb_yazarkytarama.Text = null;
            tb_yazarkytarama.Focus();
        }

        private void rb_soyad_CheckedChanged(object sender, EventArgs e)
        {
            tb_yazarkytarama.Text = null;
            tb_yazarkytarama.Focus();
        }

        private void dataGridView_yazarkyt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_yazarkyt.SelectedCells[0].RowIndex;

            tb_yazarnumara.Text = dataGridView_yazarkyt.Rows[veriAktar].Cells[0].Value.ToString();
            tb_Yazarad.Text = dataGridView_yazarkyt.Rows[veriAktar].Cells[1].Value.ToString();
            tb_Yazarsoyad.Text = dataGridView_yazarkyt.Rows[veriAktar].Cells[2].Value.ToString();
        }
        private void dataGridView_yazarkyt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_yazarkyt.Rows.Count; i++)
            {
                dataGridView_yazarkyt.Rows[i].Height = 20;
            }

            dataGridView_yazarkyt.CurrentRow.Height = 50;
        }

        private void anamenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

    }
}
