namespace kütüphaneotomasyonu
{
    partial class kullaniciigiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kullaniciigiris));
            this.btn_kulanıcıgiris = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb_kullaniciadi = new System.Windows.Forms.TextBox();
            this.tb_sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_kulanıcıgiris
            // 
            this.btn_kulanıcıgiris.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kulanıcıgiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kulanıcıgiris.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kulanıcıgiris.ImageKey = "400_F_18715591_YF83M5lccpggfAMYRlUGjW6ARheGZkny.jpg";
            this.btn_kulanıcıgiris.ImageList = this.ımageList1;
            this.btn_kulanıcıgiris.Location = new System.Drawing.Point(102, 176);
            this.btn_kulanıcıgiris.Name = "btn_kulanıcıgiris";
            this.btn_kulanıcıgiris.Size = new System.Drawing.Size(150, 43);
            this.btn_kulanıcıgiris.TabIndex = 0;
            this.btn_kulanıcıgiris.Text = "Giriş";
            this.btn_kulanıcıgiris.UseVisualStyleBackColor = false;
            this.btn_kulanıcıgiris.Click += new System.EventHandler(this.btn_kullanıcıgiris_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "400_F_18715591_YF83M5lccpggfAMYRlUGjW6ARheGZkny.jpg");
            // 
            // tb_kullaniciadi
            // 
            this.tb_kullaniciadi.Location = new System.Drawing.Point(174, 70);
            this.tb_kullaniciadi.Name = "tb_kullaniciadi";
            this.tb_kullaniciadi.Size = new System.Drawing.Size(106, 20);
            this.tb_kullaniciadi.TabIndex = 1;
            this.tb_kullaniciadi.Text = "selva";
            // 
            // tb_sifre
            // 
            this.tb_sifre.Location = new System.Drawing.Point(173, 119);
            this.tb_sifre.Name = "tb_sifre";
            this.tb_sifre.Size = new System.Drawing.Size(107, 20);
            this.tb_sifre.TabIndex = 2;
            this.tb_sifre.Text = "123";
            this.tb_sifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(49, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(49, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre:";
            // 
            // kullaniciigiris
            // 
            this.AcceptButton = this.btn_kulanıcıgiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImage = global::kütüphaneotomasyonu.Properties.Resources.kitaplar_280x280;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_sifre);
            this.Controls.Add(this.tb_kullaniciadi);
            this.Controls.Add(this.btn_kulanıcıgiris);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.MinimizeBox = false;
            this.Name = "kullaniciigiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KULLANICI GİRİŞ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_kulanıcıgiris;
        private System.Windows.Forms.TextBox tb_kullaniciadi;
        private System.Windows.Forms.TextBox tb_sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList ımageList1;
    }
}

