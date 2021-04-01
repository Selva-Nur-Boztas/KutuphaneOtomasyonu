using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace kütüphaneotomasyonu
{
    public partial class anamenü : Form
    {
        public anamenü()
        {
            InitializeComponent();
        }

        private void btn_uyegiris_Click(object sender, EventArgs e)
        {
            üyegirisi frm = new üyegirisi();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_personelgirisi_Click(object sender, EventArgs e)
        {
            personelgirisi frm = new personelgirisi();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_kitapkayıt_Click(object sender, EventArgs e)
        {
            kitapkayıt frm = new kitapkayıt();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void btn_yazarkayıt_Click(object sender, EventArgs e)
        {
            yazarkayıt frm = new yazarkayıt();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kütüphanekayıt frm = new kütüphanekayıt();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ödunc frm = new ödunc();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
        private void btn_stok_Click(object sender, EventArgs e)
        {
            stok frm = new stok();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();     
        }

        private void anamenü_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;  //ekranı tamamen kaplaması için
        }

       

       
    }
}
