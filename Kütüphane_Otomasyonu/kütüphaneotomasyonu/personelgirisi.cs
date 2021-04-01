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
    public partial class personelgirisi : Form
    {
        public personelgirisi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        
        SqlCommand komut;
        object personelnumara, ad, soyad, gorevi, adres, telefon, maas, eposta, isebaslamatarihi, istenayrilmatarihi;
        private void personelgirisi_Load(object sender, EventArgs e)
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Personel", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "personelgirisi");
            dataGridView_personel.DataSource = ds.Tables["personelgirisi"];
        }

        private void btn_persnlkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Personel(ad,soyad,gorevi,adres,telefon,maas,eposta,isebaslamatarihi,istenayrilmatarihi) values (@2,@3,@4,@5,@6,@7,@8,@9,@10)";
                komut = new SqlCommand(kaydet, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_personelnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar, 50).Value = tb_Personelad.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Personelsoyad.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar, 50).Value = tb_Personelgorevi.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 20).Value = tb_Personeladres.Text;
                komut.Parameters.Add("@6", SqlDbType.Char, 11).Value = tb_Personeltelefon.Text;
                komut.Parameters.Add("@7", SqlDbType.Money).Value = tb_Personelmaas.Text;
                komut.Parameters.Add("@8", SqlDbType.VarChar, 50).Value = tb_Personeleposta.Text;
                komut.Parameters.Add("@9", SqlDbType.Date).Value = dateTimePicker_baslama.Text;
                komut.Parameters.Add("@10",SqlDbType.Date).Value = dateTimePicker_ayrılma.Text;

               

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

        private void btn_persnlguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_personel.CurrentRow.Cells["personelnumara"].Value.ToString();

                string guncelle = "UPDATE Personel SET ad=@2,soyad=@3,gorevi=@4,adres=@5,telefon=@6,maas=@7,eposta=@8,isebaslamatarihi=@9,istenayrilmatarihi=@10 WHERE personelnumara=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_personelnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar,50).Value = tb_Personelad.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Personelsoyad.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar, 50).Value = tb_Personelgorevi.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 20).Value = tb_Personeladres.Text;
                komut.Parameters.Add("@6", SqlDbType.Char, 11).Value = tb_Personeltelefon.Text;
                komut.Parameters.Add("@7", SqlDbType.Money).Value = tb_Personelmaas.Text;
                komut.Parameters.Add("@8", SqlDbType.VarChar, 50).Value = tb_Personeleposta.Text;
                komut.Parameters.Add("@9", SqlDbType.Date).Value = dateTimePicker_baslama.Text;
                komut.Parameters.Add("@10", SqlDbType.Date).Value =dateTimePicker_ayrılma.Text;


                komut.ExecuteNonQuery();

                KayitlariGetir();

                MessageBox.Show("Seçili Kayıt Güncellendi");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }
        }

        private void btn_personellistele_Click(object sender, EventArgs e)
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

        private void btn_personelsil_Click(object sender, EventArgs e)
        {
            if (dataGridView_personel.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_personel.CurrentRow.Cells["personelnumara"].Value.ToString();

                string sil = "DELETE From Personel WHERE personelnumara=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }
        private void tb_personelarama_TextChanged(object sender, EventArgs e)
        {
            if (tb_personelarama.Text != "")
            {
                if (rb_ad.Checked)
                    aramaYap(tb_personelarama.Text, "ad");
                else if (rb_soyad.Checked)
                    aramaYap(tb_personelarama.Text, "soyad");
                else if (rb_gorevi.Checked)
                    aramaYap(tb_personelarama.Text, "gorevi");
                else if (rb_adres.Checked)
                    aramaYap(tb_personelarama.Text, "adres");
            }
            else
            {
                KayitlariGetir();
            }
        }
        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Personel ";

            if (tb_personelarama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_personelarama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
        }
        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds,"Personel");
            dataGridView_personel.DataSource = ds.Tables["Personel"];
        }
        private void rb_ad_CheckedChanged(object sender, EventArgs e)
        {
            tb_personelarama.Text = null;
            tb_personelarama.Focus();
        }
        private void rb_soyad_CheckedChanged(object sender, EventArgs e)
        {
            tb_personelarama.Text = null;
            tb_personelarama.Focus();
        }

        private void rb_gorevi_CheckedChanged(object sender, EventArgs e)
        {
            tb_personelarama.Text = null;
            tb_personelarama.Focus();
        }

        private void rb_adres_CheckedChanged(object sender, EventArgs e)
        {
            tb_personelarama.Text = null;
            tb_personelarama.Focus();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {

            tb_personelnumara.Clear();
            tb_Personelad.Clear();
            tb_Personelsoyad.Clear();
            tb_Personelgorevi.Clear();
            tb_Personeladres.Clear();
            tb_Personeltelefon.Clear();
            tb_Personelmaas.Clear();
            tb_Personeleposta.Clear();       
       }

        private void button5_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
        private void dataGridView_personel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_personel.SelectedCells[0].RowIndex;

            tb_personelnumara.Text = dataGridView_personel.Rows[veriAktar].Cells[0].Value.ToString();
            tb_Personelad.Text = dataGridView_personel.Rows[veriAktar].Cells[1].Value.ToString();
            tb_Personelsoyad.Text = dataGridView_personel.Rows[veriAktar].Cells[2].Value.ToString();
            tb_Personeladres.Text = dataGridView_personel.Rows[veriAktar].Cells[3].Value.ToString();
            tb_Personelgorevi.Text = dataGridView_personel.Rows[veriAktar].Cells[4].Value.ToString();
            tb_Personeltelefon.Text = dataGridView_personel.Rows[veriAktar].Cells[5].Value.ToString();
            tb_Personelmaas.Text = dataGridView_personel.Rows[veriAktar].Cells[6].Value.ToString();
            tb_Personeleposta.Text = dataGridView_personel.Rows[veriAktar].Cells[7].Value.ToString();
            dateTimePicker_baslama.Text = dataGridView_personel.Rows[veriAktar].Cells[8].Value.ToString();
            dateTimePicker_ayrılma.Text = dataGridView_personel.Rows[veriAktar].Cells[9].Value.ToString();

        }
        private void tb_Personeltelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_Personelmaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void dataGridView_personel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_personel.Rows.Count; i++)
            {
                dataGridView_personel.Rows[i].Height = 20;
            }

            dataGridView_personel.CurrentRow.Height = 50;
        }

        private void tb_Personelad_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_Personelad, "Lütfen Ad giriniz..");
        }

        private void tb_Personelsoyad_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tb_Personelsoyad, "Lütfen Soyad giriniz..");
        }



       

       

       
        

        

       

       
    }
}
