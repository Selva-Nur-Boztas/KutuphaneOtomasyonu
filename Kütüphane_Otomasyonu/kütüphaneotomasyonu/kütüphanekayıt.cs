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
    public partial class kütüphanekayıt : Form
    {
        public kütüphanekayıt()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        
        SqlCommand komut;
        object id, kutuphaneid, adresİ, postakodu;
        private void kütüphanekayıt_Load(object sender, EventArgs e)
        {
            rb_kutuphaneadi.Checked = true;

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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Kutuphane", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "kütüphanekayıt");
            dataGridView_kutuphane.DataSource = ds.Tables["kütüphanekayıt"];
        }

        private void btn_kutuphanekaydet_Click(object sender, EventArgs e)
        {

            try
            {
                string kaydet = "INSERT INTO Kutuphane(kutuphaneadi,adresi,postakodu) values (@2,@3,@4)";
                komut = new SqlCommand(kaydet, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_Id.Text;
                komut.Parameters.Add("@2", SqlDbType.Char, 11).Value = tb_Kutuphaneadı.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Kutuphaneadres.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar, 50).Value = tb_kutuphanearama.Text;
                komut.Parameters.Add("@5", SqlDbType.VarChar, 50).Value = tb_Kutuphanepostakodu.Text;
               

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

        private void btn_kutuphaneguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_kutuphane.CurrentRow.Cells["id"].Value.ToString();

                string guncelle = "UPDATE Kutuphane SET kutuphaneadi = @2, adresİ= @3, postakodu = @4  WHERE id=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_Id.Text;
                komut.Parameters.Add("@2", SqlDbType.VarChar,50).Value = tb_Kutuphaneadı.Text;
                komut.Parameters.Add("@3", SqlDbType.VarChar, 50).Value = tb_Kutuphaneadres.Text;
                komut.Parameters.Add("@4", SqlDbType.Int).Value = tb_Kutuphanepostakodu.Text;

                komut.ExecuteNonQuery();
                KayitlariGetir();
                MessageBox.Show("Seçili Kayıt Güncellendi");
            }
            
            catch (Exception ex)
            {
                 MessageBox.Show("Güncellemede Hata" + ex.Message);
            }
        }
     
        private void btn_kutuphanecıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kutuphanetemizle_Click(object sender, EventArgs e)
        {
           temizle();
        }

        private void temizle()
        {
            tb_Id.Clear();
            tb_Kutuphaneadı.Clear();
            tb_Kutuphaneadres.Clear();
            tb_Kutuphanepostakodu.Clear();
        }
        private void btn_kutuphaneanamenu_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_kutuphanesil_Click(object sender, EventArgs e)
        {
            if (dataGridView_kutuphane.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_kutuphane.CurrentRow.Cells["id"].Value.ToString();

                string sil = "DELETE From Kutuphane WHERE id=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }
        private void tb_kutuphanearama_TextChanged(object sender, EventArgs e)
        {
            if (tb_kutuphanearama.Text != "")
            {
                if (rb_kutuphaneadi.Checked)
                    aramaYap(tb_kutuphanearama.Text, "Kutuphaneadi");
                else if (rb_adres.Checked)
                    aramaYap(tb_Kutuphaneadres.Text, "adresi");
               
            }
            else
            {
                KayitlariGetir();
            }
        }
        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Kutuphane ";

            if (tb_kutuphanearama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_kutuphanearama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
        }

        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds,"Kutuphane");
            dataGridView_kutuphane.DataSource = ds.Tables["Kutuphane"];

        }

        private void rb_kutuphaneadi_CheckedChanged(object sender, EventArgs e)
        {
            tb_kutuphanearama.Text = null;
            tb_kutuphanearama.Focus();
        }

        private void rb_adres_CheckedChanged_1(object sender, EventArgs e)
        {
            tb_kutuphanearama.Text = null;
            tb_kutuphanearama.Focus();
        }

        private void btn_kutuphanelistele_Click(object sender, EventArgs e)
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

        private void dataGridView_kutuphane_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_kutuphane.SelectedCells[0].RowIndex;

            tb_Id.Text = dataGridView_kutuphane.Rows[veriAktar].Cells[0].Value.ToString();
            tb_Kutuphaneadı.Text = dataGridView_kutuphane.Rows[veriAktar].Cells[1].Value.ToString();
            tb_Kutuphaneadres.Text = dataGridView_kutuphane.Rows[veriAktar].Cells[2].Value.ToString();
            tb_Kutuphanepostakodu.Text = dataGridView_kutuphane.Rows[veriAktar].Cells[3].Value.ToString();
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

        private void dataGridView_kutuphane_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_kutuphane.Rows.Count; i++)
            {
                dataGridView_kutuphane.Rows[i].Height = 20;
            }

            dataGridView_kutuphane.CurrentRow.Height = 50;
        }

        private void tb_Kutuphanepostakodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       
    }
 }
