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
    public partial class ödunc : Form
    {
        public ödunc()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELVANUR\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");

        SqlCommand komut;
        object oduncnumara, aldigitarih, sonodemetarihi, teslimtarih, günfarki, cezaTL, cezaKRS, uyenumara, barkodnumara, personelnumara;
        private void ödunc_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Uyeler order by ad", baglanti);
            baglanti.Open();
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            comboBox_uyeno.DisplayMember = "ad";
            comboBox_uyeno.ValueMember = "uyenumara";
            comboBox_uyeno.DataSource = tbl;
            baglanti.Close();

            SqlCommand cmdd = new SqlCommand("select * from Kitaplar order by kitapadi", baglanti);
            baglanti.Open();
            DataTable tbll = new DataTable();
            tbll.Load(cmdd.ExecuteReader());
            comboBox_barkodno.DisplayMember = "kitapadi";
            comboBox_barkodno.ValueMember = "barkodnumara";
            comboBox_barkodno.DataSource = tbll;
            baglanti.Close();

            SqlCommand cmddd = new SqlCommand("select * from Personel order by ad", baglanti);
            baglanti.Open();
            DataTable tblll = new DataTable();
            tblll.Load(cmddd.ExecuteReader());
            comboBox_personelno.DisplayMember = "ad";
            comboBox_personelno.ValueMember = "personelnumara";
            comboBox_personelno.DataSource = tblll;
            baglanti.Close();

            rb_uyeno.Checked = true;

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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Odunc", baglanti);
            DataSet ds = new DataSet();
            sda.Fill(ds, "ödünc");
            dataGridView_odunc.DataSource = ds.Tables["ödünc"];
        }


        private void btn_ödunckaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string kaydet = "INSERT INTO Odunc(aldigitarih,sonodemetarihi,teslimtarih,gunfarki,cezaTL, cezaKRS,uyenumara,barkodnumara,personelnumara) values (@2,@3,@4,@5,@6,@7,@8,@9,@10)";
                komut = new SqlCommand(kaydet, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_oduncnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.Date).Value = dtp_aldığıtarih.Text;
                komut.Parameters.Add("@3", SqlDbType.Date).Value = dtp_sonodemetrh.Text;
                komut.Parameters.Add("@4", SqlDbType.Date).Value = dtp_teslimtarih.Text;
                komut.Parameters.Add("@5", SqlDbType.Int).Value = tb_gunfarkı.Text;
                komut.Parameters.Add("@6", SqlDbType.Int).Value = tb_odunccezaTL.Text;
                komut.Parameters.Add("@7", SqlDbType.Int).Value = tb_odunccezaKRS.Text;
                komut.Parameters.Add("@8", SqlDbType.Int).Value = comboBox_uyeno.SelectedValue.ToString();
                komut.Parameters.Add("@9", SqlDbType.Int).Value = comboBox_barkodno.SelectedValue.ToString();
                komut.Parameters.Add("@10", SqlDbType.Int).Value = comboBox_personelno.SelectedValue.ToString();

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


        private void btn_oduncgüncellestir_Click(object sender, EventArgs e)
        {
            try
            {
                String guncellenecekSatir = dataGridView_odunc.CurrentRow.Cells["oduncnumara"].Value.ToString();

                string guncelle = "UPDATE Odunc SET aldigitarih = @2,sonodemetarihi=@3, teslimtarih= @4,gunfarki=@5,cezaTL = @6 ,cezaKRS=@7, uyenumara = @8, barkodnumara= @9 ,personelnumara=@10 WHERE oduncnumara=" + guncellenecekSatir + "";
                komut = new SqlCommand(guncelle, baglanti);

                //komut.Parameters.Add("@1", SqlDbType.Int).Value = tb_oduncnumara.Text;
                komut.Parameters.Add("@2", SqlDbType.Date).Value = dtp_aldığıtarih.Text;
                komut.Parameters.Add("@3", SqlDbType.Date).Value = dtp_sonodemetrh.Text;
                komut.Parameters.Add("@4", SqlDbType.Date).Value = dtp_teslimtarih.Text;
                komut.Parameters.Add("@5", SqlDbType.Int).Value = tb_gunfarkı.Text;
                komut.Parameters.Add("@6", SqlDbType.Int).Value = tb_odunccezaTL.Text;
                komut.Parameters.Add("@7", SqlDbType.Int).Value = tb_odunccezaKRS.Text;
                komut.Parameters.Add("@8", SqlDbType.Int).Value = comboBox_uyeno.SelectedValue.ToString();
                komut.Parameters.Add("@9", SqlDbType.Int).Value = comboBox_barkodno.SelectedValue.ToString();
                komut.Parameters.Add("@10", SqlDbType.Int).Value = comboBox_personelno.SelectedValue.ToString();


                komut.ExecuteNonQuery();
                KayitlariGetir();
                MessageBox.Show("Seçili Kayıt Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellemede Hata" + ex.Message);
            }

        }

        private void btn_oduncsil_Click(object sender, EventArgs e)
        {
            if (dataGridView_odunc.CurrentRow == null)
                MessageBox.Show("Silinecek Kayıt Yok");
            else
            {
                String silinecekSatir = dataGridView_odunc.CurrentRow.Cells["oduncnumara"].Value.ToString();

                string sil = "DELETE From Odunc WHERE oduncnumara=" + silinecekSatir + "";

                komut = new SqlCommand(sil, baglanti);

                komut.ExecuteNonQuery();

                KayitlariGetir();
                temizle();
                MessageBox.Show("Seçili Kayıt Silindi");
            }
        }
        private void btn_odunccikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_oduncanamenu_Click(object sender, EventArgs e)
        {
            anamenü frm = new anamenü();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_odunctemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {
            tb_oduncnumara.Clear();
            tb_gunfarkı.Clear();
            tb_odunccezaTL.Clear();
        }

        private void tb_oduncarama_TextChanged(object sender, EventArgs e)
        {
            if (tb_oduncarama.Text != "")
            {
                if (rb_uyeno.Checked)
                    aramaYap(tb_oduncarama.Text, "Uyenumara");
                else if (rb_barkodno.Checked)
                    aramaYap(tb_oduncarama.Text, "barkodnumara");
                else if (rb_personelno.Checked)
                    aramaYap(tb_oduncarama.Text, "personelnumara");
            }
            else
            {
                KayitlariGetir();
            }
        }
        private void aramaYap(string kriter, string alan)
        {
            string sorgu = "SELECT * FROM Odunc ";

            if (tb_oduncarama.Text != "")
            {
                sorgu += "WHERE " + alan + " like '%" + tb_oduncarama.Text + "%'";
                KayıtGuncelle(sorgu);
            }
        }

        void KayıtGuncelle(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Odunc");
            dataGridView_odunc.DataSource = ds.Tables["Odunc"];

        }
        private void rb_uyeno_CheckedChanged(object sender, EventArgs e)
        {
            tb_oduncarama.Text = null;
            tb_oduncarama.Focus();
        }

        private void rb_barkodno_CheckedChanged(object sender, EventArgs e)
        {
            tb_oduncarama.Text = null;
            tb_oduncarama.Focus();
        }

        private void rb_personelno_CheckedChanged(object sender, EventArgs e)
        {
            tb_oduncarama.Text = null;
            tb_oduncarama.Focus();
        }

        private void btn_odunclistele_Click(object sender, EventArgs e)
        {
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
        }

        private void dataGridView_odunc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veriAktar = dataGridView_odunc.SelectedCells[0].RowIndex;

            tb_oduncnumara.Text = dataGridView_odunc.Rows[veriAktar].Cells[0].Value.ToString();
            dtp_aldığıtarih.Text = dataGridView_odunc.Rows[veriAktar].Cells[1].Value.ToString();
            dtp_sonodemetrh.Text = dataGridView_odunc.Rows[veriAktar].Cells[2].Value.ToString();
            dtp_teslimtarih.Text = dataGridView_odunc.Rows[veriAktar].Cells[3].Value.ToString();
            tb_gunfarkı.Text = dataGridView_odunc.Rows[veriAktar].Cells[4].Value.ToString();
            tb_odunccezaTL.Text = dataGridView_odunc.Rows[veriAktar].Cells[5].Value.ToString();
            tb_odunccezaKRS.Text = dataGridView_odunc.Rows[veriAktar].Cells[6].Value.ToString();
            comboBox_uyeno.Text = dataGridView_odunc.Rows[veriAktar].Cells[7].Value.ToString();
            comboBox_barkodno.Text = dataGridView_odunc.Rows[veriAktar].Cells[8].Value.ToString();
            comboBox_personelno.Text = dataGridView_odunc.Rows[veriAktar].Cells[9].Value.ToString();

        }

        private void dataGridView_odunc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_odunc.Rows.Count; i++)
            {
                dataGridView_odunc.Rows[i].Height = 20;
            }

            dataGridView_odunc.CurrentRow.Height = 50;
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
        private void dtp_aldığıtarih_ValueChanged(object sender, EventArgs e)
        {
            string deger = null;

            DateTime dt = dtp_aldığıtarih.Value;

            deger = "15 gün ekli = " + DateTime.Now.AddDays(15).ToString() + "\n";
            dtp_sonodemetrh.Text = (dtp_aldığıtarih.Value.AddDays(15).ToString());
        }
        private void dtp_teslimtarih_ValueChanged(object sender, EventArgs e)
        {
            DateTime SOT = new DateTime();
            DateTime TSLMT = new DateTime();
            SOT = dtp_sonodemetrh.Value;
            TSLMT = dtp_teslimtarih.Value;

            tb_gunfarkı.Text = GunFarkiBul(SOT, TSLMT).ToString();

            int sonuc = DateTime.Compare(SOT, TSLMT);
            int fark = GunFarkiBul(SOT, TSLMT);
            int ceza;
            if (sonuc == 0)
            {
                MessageBox.Show("Son Ödeme Günü");
            }
            else if (fark > 0)
            {
                MessageBox.Show("Ceza yediniz");
                ceza = fark * 10;

                tb_odunccezaTL.Text = (ceza / 100).ToString();
                tb_odunccezaKRS.Text = (ceza % 100).ToString();
            }
        }
        public int GunFarkiBul(DateTime SOT, DateTime TSLMT)
        {
            TimeSpan zaman = new TimeSpan();
            zaman = SOT - TSLMT;
            return Math.Abs(zaman.Days);
        }

    }
}