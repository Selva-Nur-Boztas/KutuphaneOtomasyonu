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
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
        SqlCommand komut;
        object stoknumara, barkodnumara, toplamkitapsayisi, oduncverilenler;
        private void stok_Load(object sender, EventArgs e)
        {
            rb_stoknumara.Checked = true;

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
                MessageBox.Show("Kayıtları Lİstelemede Hata:" + ex.Message);
            }
        }
        private void KayitlariGetir()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT*FROM Stok", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "stok");
            dataGridView_stok.DataSource = ds.Tables["stok"];
        }

        private void btn_stokkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Stok(barkodnumara,toplamkitapsayisi,oduncverilenler) values (@1,@3,@4)";
                komut = new SqlCommand(kaydet, baglanti);

                komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_barkodnumara.Text;
                //komut.Parameters.Add("@2", SqlDbType.Int).Value = tb_stoknumara.Text;
                komut.Parameters.Add("@3", SqlDbType.Int).Value = tb_toplamks.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar,50).Value = tb_oduncverilenler.Text;
                

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
        private void btn_stokgüncellestir_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_stok.CurrentRow.Cells["stoknumara"].Value.ToString();

                string guncelle = "UPDATE Stok SET barkodnumara=@1 , toplamkitapsayisi=@3 , oduncverilenler=@4 WHERE stoknumara=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_barkodnumara.Text;
                //komut.Parameters.Add("@2", SqlDbType.Int).Value = tb_stoknumara.Text;
                komut.Parameters.Add("@3", SqlDbType.Int).Value = tb_toplamks.Text;
                komut.Parameters.Add("@4", SqlDbType.VarChar,50).Value = tb_oduncverilenler.Text;


                komut.ExecuteNonQuery();

                KayitlariGetir();

                MessageBox.Show("Seçili Kayıt Güncellendi");



            }
            catch (Exception ex)
            {

                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }
        }
        private void btn_stoklistele_Click(object sender, EventArgs e)
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
        private void btn_stoksil_Click(object sender, EventArgs e)
        {
            if (dataGridView_stok.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_stok.CurrentRow.Cells["stoknumara"].Value.ToString();

                string sil = "DELETE From Stok WHERE stoknumara=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }
        private void tb_stokarama_TextChanged_1(object sender, EventArgs e)
        {
            if (tb_stokarama.Text != "")
            {
                if (rb_barkodnumara.Checked)
                    aramaYap(tb_stokarama.Text, "barkodnumara");
                else if (rb_stoknumara.Checked)
                    aramaYap(tb_stokarama.Text, "stoknumara");

            }
            else
            {
                KayitlariGetir();
            }
        }
         private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Stok ";

            if (tb_stokarama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_stokarama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
            
        }
        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Stok");
            dataGridView_stok.DataSource = ds.Tables["Stok"];
        }
        private void btn_stokcikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_stoktemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {
            tb_barkodnumara.Clear();
            tb_stoknumara.Clear();
            tb_oduncverilenler.Clear();
            tb_toplamks.Clear();
        }

        private void btn_stokanamenu_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void dataGridView_stok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_stok.SelectedCells[0].RowIndex;

            tb_barkodnumara.Text = dataGridView_stok.Rows[veriAktar].Cells[0].Value.ToString();
            tb_stoknumara.Text = dataGridView_stok.Rows[veriAktar].Cells[1].Value.ToString();
            tb_toplamks.Text = dataGridView_stok.Rows[veriAktar].Cells[2].Value.ToString();
            tb_oduncverilenler.Text = dataGridView_stok.Rows[veriAktar].Cells[3].Value.ToString();
        }

        private void dataGridView_stok_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_stok.Rows.Count; i++)
            {
                dataGridView_stok.Rows[i].Height = 20;
            }

            dataGridView_stok.CurrentRow.Height = 50;
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
