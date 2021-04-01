using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kütüphaneotomasyonu
{
    public partial class kitapkayıt : Form
    {
        public kitapkayıt()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");

        SqlCommand komut;
        object barkodnumara, kitapadi, yazarnumara, sayfasayisi, turu, yayinevi, kitapdili, kitapId, salonnumara, rafnumara, resim;

        private void kitapkayıt_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Yazarlar order by ad", baglanti);
            baglanti.Open();
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            comboBox_yazarnumara.DisplayMember = "ad";
            comboBox_yazarnumara.ValueMember = "yazarnumara";
            comboBox_yazarnumara.DataSource = tbl;
            baglanti.Close();

            SqlCommand cmdd = new SqlCommand("select * from Kutuphane order by id", baglanti);
            baglanti.Open();
            DataTable tblo = new DataTable();
            tblo.Load(cmdd.ExecuteReader());
            comboBox_kid.DataSource = tblo;
            comboBox_kid.DisplayMember = "kutuphaneadi";
            comboBox_kid.ValueMember = "id";
            baglanti.Close();

            rb_kitapadi.Checked = true;

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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Kitaplar", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "kitapkayıt");
            dataGridView_ktpkyt.DataSource = ds.Tables["kitapkayıt"];
        }

        private void btn_ktpkytkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Kitaplar( kitapadi, yazarnumara, sayfasayisi, turu, yayinevi, kitapdili, kutuphaneid, salonnumara, rafnumara,resim) values (@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";
                komut = new SqlCommand(kaydet, baglanti);

                komut.Parameters.Add("@2", SqlDbType.VarChar, 50).Value = tb_kitapadı.Text;
                komut.Parameters.Add("@3", SqlDbType.Int).Value = comboBox_yazarnumara.SelectedValue.ToString();
                komut.Parameters.Add("@4", SqlDbType.Int).Value = tb_sayfasayisi.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 50).Value = tb_turu.Text;
                komut.Parameters.Add("@6", SqlDbType.VarChar, 50).Value = tb_yayınevi.Text;
                komut.Parameters.Add("@7", SqlDbType.VarChar, 50).Value = tb_kitapdili.Text;
                komut.Parameters.Add("@8", SqlDbType.Int).Value = comboBox_kid.SelectedValue.ToString();
                komut.Parameters.Add("@9", SqlDbType.Int).Value = tb_salonnumara.Text;
                komut.Parameters.Add("@10", SqlDbType.Int).Value = tb_rafnumara.Text;
                komut.Parameters.Add("@11", SqlDbType.VarChar, 100).Value = tb_resim.Text;

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

        private void btn_ktpkytgüncellestir_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_ktpkyt.CurrentRow.Cells["barkodnumara"].Value.ToString();

                string guncelle = "UPDATE Kitaplar SET kitapadi = @2, yazarnumara= @3, sayfasayisi = @4 , turu = @5, yayinevi= @6 ,kitapdili=@7,kutuphaneid=@8,salonnumara=@9, rafnumara=@10, resim=@11 WHERE barkodnumara=" + guncellenecekSatir;
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_barkodnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar, 50).Value = tb_kitapadı.Text;
                komut.Parameters.Add("@3", SqlDbType.Int).Value = comboBox_yazarnumara.SelectedValue.ToString();
                komut.Parameters.Add("@4", SqlDbType.Int).Value = tb_sayfasayisi.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 50).Value = tb_turu.Text;
                komut.Parameters.Add("@6", SqlDbType.VarChar, 50).Value = tb_yayınevi.Text;
                komut.Parameters.Add("@7", SqlDbType.VarChar, 50).Value = tb_kitapdili.Text;
                komut.Parameters.Add("@8", SqlDbType.Int).Value = comboBox_kid.SelectedValue.ToString();
                komut.Parameters.Add("@9", SqlDbType.Int).Value = tb_salonnumara.Text;
                komut.Parameters.Add("@10", SqlDbType.Int).Value = tb_rafnumara.Text;
                komut.Parameters.Add("@11", SqlDbType.VarChar, 100).Value = tb_resim.Text;

                komut.ExecuteNonQuery();
                KayitlariGetir();

                MessageBox.Show("Seçili Kayıt Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }


        }
        private void btn_ktpkytanamenu_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_ktpkytcikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ktpkyttemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void temizle()
        {
            tb_barkodnumara.Clear();
            tb_kitapadı.Clear();
            tb_sayfasayisi.Clear();
            tb_turu.Clear();
            tb_yayınevi.Clear();
            tb_kitapdili.Clear();
            tb_rafnumara.Clear();
            tb_salonnumara.Clear();
            tb_resim.Clear();
        }

        private void btn_kitapkytsil_Click(object sender, EventArgs e)
        {
            if (dataGridView_ktpkyt.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_ktpkyt.CurrentRow.Cells["barkodnumara"].Value.ToString();

                string sil = "DELETE From Kitaplar WHERE barkodnumara=" + silinecekSatir;

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }


        private void tb_ktparama_TextChanged(object sender, EventArgs e)
        {
            if (tb_ktpkytarama.Text != "")
            {
                if (rb_kitapadi.Checked)
                    aramaYap(tb_ktpkytarama.Text, "kitapadi");
                else if (rb_turu.Checked)
                    aramaYap(tb_ktpkytarama.Text, "turu");
                else if (rb_yayınevi.Checked)
                    aramaYap(tb_yayınevi.Text, "yayinevi");
                else if (rb_salonnumara.Checked)
                aramaYap(tb_salonnumara.Text, "salonnumara");
            }
            else
            {
                KayitlariGetir();
            }
        }

        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Kitaplar ";

            if (tb_ktpkytarama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_ktpkytarama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
        }

        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Kitaplar");
            dataGridView_ktpkyt.DataSource = ds.Tables["Kitaplar"];

        }
        private void rb_kitapadi_CheckedChanged(object sender, EventArgs e)
        {
            tb_ktpkytarama.Text = null;
            tb_ktpkytarama.Focus();
        }

        private void rb_turu_CheckedChanged(object sender, EventArgs e)
        {
            tb_ktpkytarama.Text = null;
            tb_ktpkytarama.Focus();
        }

        private void rb_yayınevi_CheckedChanged(object sender, EventArgs e)
        {
            tb_ktpkytarama.Text = null;
            tb_ktpkytarama.Focus();
        }

        private void rb_salonnumara_CheckedChanged(object sender, EventArgs e)
        {
            tb_ktpkytarama.Text = null;
            tb_ktpkytarama.Focus();
        }
        private void btn_kitapkytlistele_Click(object sender, EventArgs e)
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

        private void dataGridView_ktpkyt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_ktpkyt.SelectedCells[0].RowIndex;

            tb_barkodnumara.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[0].Value.ToString();
            tb_kitapadı.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[1].Value.ToString();
            comboBox_yazarnumara.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[2].Value.ToString();
            tb_sayfasayisi.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[3].Value.ToString();
            tb_turu.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[4].Value.ToString();
            tb_yayınevi.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[5].Value.ToString();
            tb_kitapdili.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[6].Value.ToString();
            comboBox_kid.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[7].Value.ToString();
            tb_salonnumara.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[8].Value.ToString();
            tb_rafnumara.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[9].Value.ToString();
            tb_resim.Text = dataGridView_ktpkyt.Rows[veriAktar].Cells[10].Value.ToString();
            pictureBox1.Image = Image.FromFile(Application.StartupPath+"\\kitapresim\\"+tb_resim.Text);
        }
        private void dataGridView_ktpkyt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_ktpkyt.Rows.Count; i++)
            {
                dataGridView_ktpkyt.Rows[i].Height = 20;
            }

            dataGridView_ktpkyt.CurrentRow.Height = 50;
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

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tb_resim.Text = openFileDialog1.SafeFileName;
            pictureBox1.ImageLocation = openFileDialog1.FileName;

        }
        private void tb_kitapadı_Validating(object sender, CancelEventArgs e)
        {
            if (tb_kitapadı.Text.Trim() == "")
                errorProvider1.SetError(tb_kitapadı, "Bu Alan Boş Geçilemez");
            else
                errorProvider1.SetError(tb_kitapadı, "");
        }
        private void tb_sayfasayisi_Validating(object sender, CancelEventArgs e)
        {
            if (tb_sayfasayisi.Text.Trim() == "")
                errorProvider1.SetError(tb_sayfasayisi, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_sayfasayisi, "");
        }

        private void tb_turu_Validating(object sender, CancelEventArgs e)
        {
            if (tb_turu.Text.Trim() == "")
                errorProvider1.SetError(tb_turu, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_turu, "");
        }

        private void tb_yayınevi_Validating(object sender, CancelEventArgs e)
        {
            if (tb_yayınevi.Text.Trim() == "")
                errorProvider1.SetError(tb_yayınevi, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_yayınevi, "");
        }

        private void tb_kitapdili_Validating(object sender, CancelEventArgs e)
        {
            if (tb_kitapdili.Text.Trim() == "")
                errorProvider1.SetError(tb_kitapdili, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_kitapdili, "");
        }
        private void tb_salonnumara_Validating(object sender, CancelEventArgs e)
        {
            if (tb_salonnumara.Text.Trim() == "")
                errorProvider1.SetError(tb_salonnumara, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_salonnumara, "");
        }

        private void tb_rafnumara_Validating(object sender, CancelEventArgs e)
        {
            if (tb_rafnumara.Text.Trim() == "")
                errorProvider1.SetError(tb_rafnumara, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_rafnumara, "");
        }

        private void tb_resim_Validating(object sender, CancelEventArgs e)
        {
            if (tb_resim.Text.Trim() == "")
                errorProvider1.SetError(tb_resim, "Bu Alan Boş Geçilemez");

            else
                errorProvider1.SetError(tb_resim, "");
        }
    }

}