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
    public partial class üyegirisi : Form
    {
        public üyegirisi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        SqlCommand komut;
        object uyenumara, tckimlik, ad, soyad, bolum, telefon, adres, eposta,resim;

        private void üyegirisi_Load(object sender, EventArgs e)
        {
            rb_ad.Checked = true;

            try
            {
                if(baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                    KayitlariGetir();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kayıtları Lİstelemede Hata:" + ex.Message);
            }
        }

        private void KayitlariGetir()
        {
            SqlDataAdapter sda =new SqlDataAdapter("SELECT*FROM Uyeler", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "uyegirisi");
            dataGridView_uye.DataSource = ds.Tables["uyegirisi"];
        }
        private void btn_uyekaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Uyeler(tckimlik,ad,soyad,bolum,telefon,adres,eposta,resim) values (@2,@3,@4,@5,@6,@7,@8,@9)";
                komut = new SqlCommand(kaydet, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_Uyenumara.Text;
                komut.Parameters.Add("@2", SqlDbType.Char, 11).Value = tb_Uyetckimlik.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Uyead.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar, 50).Value = tb_Uyesoyad.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 50).Value = tb_Uyebolum.Text;
                komut.Parameters.Add("@6", SqlDbType.Char, 11).Value = tb_Uyetelefon.Text;
                komut.Parameters.Add("@7", SqlDbType.VarChar, 50).Value = tb_Uyeadres.Text;
                komut.Parameters.Add("@8", SqlDbType.VarChar, 50).Value = tb_Uyeeposta.Text;
                komut.Parameters.Add("@9", SqlDbType.VarChar, 150).Value = tb_uyeresim.Text;

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
        private void btn_uyegirisgüncellestir_Click(object sender, EventArgs e)
        {
           try
            {
                String guncellenecekSatir = dataGridView_uye.CurrentRow.Cells["uyenumara"].Value.ToString();

                string guncelle = "UPDATE Uyeler SET tckimlik = @2, ad= @3, soyad = @4 , bolum = @5, telefon= @6 ,adres=@7,eposta=@8,resim=@9 WHERE uyenumara=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_Uyenumara.Text;
                komut.Parameters.Add("@2", SqlDbType.Char, 11).Value = tb_Uyetckimlik.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Uyead.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar, 50).Value = tb_Uyesoyad.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 50).Value = tb_Uyebolum.Text;
                komut.Parameters.Add("@6", SqlDbType.Char, 11).Value = tb_Uyetelefon.Text;
                komut.Parameters.Add("@7", SqlDbType.VarChar, 50).Value = tb_Uyeadres.Text;
                komut.Parameters.Add("@8", SqlDbType.VarChar, 50).Value = tb_Uyeeposta.Text;
                komut.Parameters.Add("@9", SqlDbType.VarChar, 150).Value = tb_uyeresim.Text;
                

                komut.ExecuteNonQuery();

                KayitlariGetir();

                MessageBox.Show("Seçili Kayıt Güncellendi");
             
            }
            catch (Exception ex)
            {

                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }
        }
        private void btn_uyegirisicikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_uyegiristemizle_Click(object sender, EventArgs e)
        {
           temizle();
        }

        private void temizle()
        {
            tb_Uyenumara.Clear();
            tb_Uyetckimlik.Clear();
            tb_Uyead.Clear();
            tb_Uyesoyad.Clear();
            tb_Uyeadres.Clear();
            tb_Uyebolum.Clear();
            tb_Uyeeposta.Clear();
            tb_Uyetelefon.Clear();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView_uye.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_uye.CurrentRow.Cells["uyenumara"].Value.ToString();

                string sil = "DELETE From Uyeler WHERE uyenumara=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tb_uyearama.Text != "")
            {
                if (rb_tckimlik.Checked)
                    aramaYap(tb_uyearama.Text, "tckimlik");
                else if (rb_ad.Checked)
                    aramaYap(tb_uyearama.Text, "ad");
                else if (rb_bolum.Checked)
                    aramaYap(tb_uyearama.Text, "bolum");
                else if (rb_adres.Checked)
                    aramaYap(tb_uyearama.Text, "adres");
            }
            else
            {
                KayitlariGetir();
            }
        }
        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Uyeler ";

            if (tb_uyearama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_uyearama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
            
        }
        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Uyeler");
            dataGridView_uye.DataSource = ds.Tables["Uyeler"];
        }

        private void rb_tckimlik_CheckedChanged(object sender, EventArgs e)
        {
            tb_uyearama.Text = null;
            tb_uyearama.Focus();
        }
        private void rb_adsoyad_CheckedChanged(object sender, EventArgs e)
        {
            tb_uyearama.Text = null;
            tb_uyearama.Focus();
        }
        private void rb_bolum_CheckedChanged(object sender, EventArgs e)
        {
            tb_uyearama.Text = null;
            tb_uyearama.Focus();
        }
        private void rb_adres_CheckedChanged(object sender, EventArgs e)
        {
            tb_uyearama.Text = null;
            tb_uyearama.Focus();
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
        private void dataGridView_uye_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_uye.SelectedCells[0].RowIndex;

            tb_Uyenumara.Text = dataGridView_uye.Rows[veriAktar].Cells[0].Value.ToString();
            tb_Uyetckimlik.Text = dataGridView_uye.Rows[veriAktar].Cells[1].Value.ToString();
            tb_Uyead.Text = dataGridView_uye.Rows[veriAktar].Cells[2].Value.ToString();
            tb_Uyesoyad.Text = dataGridView_uye.Rows[veriAktar].Cells[3].Value.ToString();
            tb_Uyebolum.Text = dataGridView_uye.Rows[veriAktar].Cells[4].Value.ToString();
            tb_Uyetelefon.Text = dataGridView_uye.Rows[veriAktar].Cells[5].Value.ToString();
            tb_Uyeadres.Text = dataGridView_uye.Rows[veriAktar].Cells[6].Value.ToString();
            tb_Uyeeposta.Text = dataGridView_uye.Rows[veriAktar].Cells[7].Value.ToString();
            tb_uyeresim.Text = dataGridView_uye.Rows[veriAktar].Cells[8].Value.ToString();
            pictureBox.Image = Image.FromFile(Application.StartupPath + "\\uyeresim\\" + tb_uyeresim.Text);

        }
        private void tb_Uyetckimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_Uyenumara_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_Uyetelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView_uye_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_uye.Rows.Count; i++)
            {
                dataGridView_uye.Rows[i].Height = 20;
            }

            dataGridView_uye.CurrentRow.Height = 50;
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
        private void tb_Uyetckimlik_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyetckimlik.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyetckimlik, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyetckimlik, "");
        }

        private void tb_Uyead_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyead.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyead, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyead, "");
        }

        private void tb_Uyesoyad_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyesoyad.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyesoyad, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyesoyad, "");
        }

        private void tb_Uyetelefon_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyetelefon.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyetelefon, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyetelefon, "");
        }

        private void tb_Uyeadres_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyeadres.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyeadres, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyeadres, "");
        }

        private void tb_Uyeeposta_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyeeposta.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyeeposta, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyeeposta  , "");
        }

        private void tb_Uyebolum_Validating(object sender, CancelEventArgs e)
        {
            if (tb_Uyebolum.Text.Trim() == "")
                errorProvider1.SetError(tb_Uyebolum, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_Uyebolum, "");
        }

        private void btn_uyegozat_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            tb_uyeresim.Text = openFileDialog.SafeFileName;
            pictureBox.ImageLocation = openFileDialog.FileName;
        }

        
       

       


        

        
        

       

      }
}
