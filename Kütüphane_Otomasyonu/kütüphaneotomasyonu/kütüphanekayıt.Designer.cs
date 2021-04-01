namespace kütüphaneotomasyonu
{
    partial class kütüphanekayıt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kütüphanekayıt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.tb_Kutuphaneadı = new System.Windows.Forms.TextBox();
            this.tb_Kutuphaneadres = new System.Windows.Forms.TextBox();
            this.tb_Kutuphanepostakodu = new System.Windows.Forms.TextBox();
            this.tb_kutuphanearama = new System.Windows.Forms.TextBox();
            this.ımageList6 = new System.Windows.Forms.ImageList(this.components);
            this.rb_adres = new System.Windows.Forms.RadioButton();
            this.rb_kutuphaneadi = new System.Windows.Forms.RadioButton();
            this.btn_kutuphaneanamenu = new System.Windows.Forms.Button();
            this.ımageList5 = new System.Windows.Forms.ImageList(this.components);
            this.btn_kutuphanetemizle = new System.Windows.Forms.Button();
            this.ımageList4 = new System.Windows.Forms.ImageList(this.components);
            this.btn_kutuphaneguncelle = new System.Windows.Forms.Button();
            this.ımageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btn_kutuphanecıkıs = new System.Windows.Forms.Button();
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_kutuphanekaydet = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView_kutuphane = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_kutuphanesil = new System.Windows.Forms.Button();
            this.ımageList8 = new System.Windows.Forms.ImageList(this.components);
            this.btn_kutuphanelistele = new System.Windows.Forms.Button();
            this.ımageList7 = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENÜToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anamenüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kutuphane)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kütüphane Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adres";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Posta Kodu";
            // 
            // tb_Id
            // 
            this.tb_Id.Location = new System.Drawing.Point(130, 21);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.Size = new System.Drawing.Size(100, 23);
            this.tb_Id.TabIndex = 1;
            this.tb_Id.Visible = false;
            // 
            // tb_Kutuphaneadı
            // 
            this.tb_Kutuphaneadı.Location = new System.Drawing.Point(130, 51);
            this.tb_Kutuphaneadı.Name = "tb_Kutuphaneadı";
            this.tb_Kutuphaneadı.Size = new System.Drawing.Size(100, 23);
            this.tb_Kutuphaneadı.TabIndex = 2;
            // 
            // tb_Kutuphaneadres
            // 
            this.tb_Kutuphaneadres.Location = new System.Drawing.Point(130, 81);
            this.tb_Kutuphaneadres.Name = "tb_Kutuphaneadres";
            this.tb_Kutuphaneadres.Size = new System.Drawing.Size(100, 23);
            this.tb_Kutuphaneadres.TabIndex = 3;
            // 
            // tb_Kutuphanepostakodu
            // 
            this.tb_Kutuphanepostakodu.Location = new System.Drawing.Point(130, 113);
            this.tb_Kutuphanepostakodu.Name = "tb_Kutuphanepostakodu";
            this.tb_Kutuphanepostakodu.Size = new System.Drawing.Size(100, 23);
            this.tb_Kutuphanepostakodu.TabIndex = 4;
            this.tb_Kutuphanepostakodu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Kutuphanepostakodu_KeyPress);
            // 
            // tb_kutuphanearama
            // 
            this.tb_kutuphanearama.Location = new System.Drawing.Point(639, 148);
            this.tb_kutuphanearama.Name = "tb_kutuphanearama";
            this.tb_kutuphanearama.Size = new System.Drawing.Size(100, 20);
            this.tb_kutuphanearama.TabIndex = 34;
            this.tb_kutuphanearama.TextChanged += new System.EventHandler(this.tb_kutuphanearama_TextChanged);
            // 
            // ımageList6
            // 
            this.ımageList6.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList6.ImageStream")));
            this.ımageList6.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList6.Images.SetKeyName(0, "images (7).jpg");
            // 
            // rb_adres
            // 
            this.rb_adres.AutoSize = true;
            this.rb_adres.Location = new System.Drawing.Point(7, 43);
            this.rb_adres.Name = "rb_adres";
            this.rb_adres.Size = new System.Drawing.Size(68, 21);
            this.rb_adres.TabIndex = 32;
            this.rb_adres.TabStop = true;
            this.rb_adres.Text = "Adres";
            this.rb_adres.UseVisualStyleBackColor = true;
            this.rb_adres.CheckedChanged += new System.EventHandler(this.rb_adres_CheckedChanged_1);
            // 
            // rb_kutuphaneadi
            // 
            this.rb_kutuphaneadi.AutoSize = true;
            this.rb_kutuphaneadi.Location = new System.Drawing.Point(7, 20);
            this.rb_kutuphaneadi.Name = "rb_kutuphaneadi";
            this.rb_kutuphaneadi.Size = new System.Drawing.Size(129, 21);
            this.rb_kutuphaneadi.TabIndex = 31;
            this.rb_kutuphaneadi.TabStop = true;
            this.rb_kutuphaneadi.Text = "kutuphane adı";
            this.rb_kutuphaneadi.UseVisualStyleBackColor = true;
            this.rb_kutuphaneadi.CheckedChanged += new System.EventHandler(this.rb_kutuphaneadi_CheckedChanged);
            // 
            // btn_kutuphaneanamenu
            // 
            this.btn_kutuphaneanamenu.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphaneanamenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphaneanamenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphaneanamenu.ImageKey = "images (1).jpg";
            this.btn_kutuphaneanamenu.ImageList = this.ımageList5;
            this.btn_kutuphaneanamenu.Location = new System.Drawing.Point(444, 133);
            this.btn_kutuphaneanamenu.Name = "btn_kutuphaneanamenu";
            this.btn_kutuphaneanamenu.Size = new System.Drawing.Size(131, 40);
            this.btn_kutuphaneanamenu.TabIndex = 30;
            this.btn_kutuphaneanamenu.Text = "anamenü";
            this.btn_kutuphaneanamenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphaneanamenu.UseVisualStyleBackColor = false;
            this.btn_kutuphaneanamenu.Click += new System.EventHandler(this.btn_kutuphaneanamenu_Click);
            // 
            // ımageList5
            // 
            this.ımageList5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList5.ImageStream")));
            this.ımageList5.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList5.Images.SetKeyName(0, "images (1).jpg");
            // 
            // btn_kutuphanetemizle
            // 
            this.btn_kutuphanetemizle.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphanetemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphanetemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphanetemizle.ImageKey = "images (8).jpg";
            this.btn_kutuphanetemizle.ImageList = this.ımageList4;
            this.btn_kutuphanetemizle.Location = new System.Drawing.Point(444, 89);
            this.btn_kutuphanetemizle.Name = "btn_kutuphanetemizle";
            this.btn_kutuphanetemizle.Size = new System.Drawing.Size(131, 36);
            this.btn_kutuphanetemizle.TabIndex = 29;
            this.btn_kutuphanetemizle.Text = "temizle";
            this.btn_kutuphanetemizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphanetemizle.UseVisualStyleBackColor = false;
            this.btn_kutuphanetemizle.Click += new System.EventHandler(this.btn_kutuphanetemizle_Click);
            // 
            // ımageList4
            // 
            this.ımageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList4.ImageStream")));
            this.ımageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList4.Images.SetKeyName(0, "images (8).jpg");
            // 
            // btn_kutuphaneguncelle
            // 
            this.btn_kutuphaneguncelle.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphaneguncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphaneguncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphaneguncelle.ImageKey = "güncelle.jpg";
            this.btn_kutuphaneguncelle.ImageList = this.ımageList3;
            this.btn_kutuphaneguncelle.Location = new System.Drawing.Point(289, 89);
            this.btn_kutuphaneguncelle.Name = "btn_kutuphaneguncelle";
            this.btn_kutuphaneguncelle.Size = new System.Drawing.Size(131, 36);
            this.btn_kutuphaneguncelle.TabIndex = 28;
            this.btn_kutuphaneguncelle.Text = "güncelleştir";
            this.btn_kutuphaneguncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphaneguncelle.UseVisualStyleBackColor = false;
            this.btn_kutuphaneguncelle.Click += new System.EventHandler(this.btn_kutuphaneguncelle_Click);
            // 
            // ımageList3
            // 
            this.ımageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList3.ImageStream")));
            this.ımageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList3.Images.SetKeyName(0, "güncelle.jpg");
            // 
            // btn_kutuphanecıkıs
            // 
            this.btn_kutuphanecıkıs.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphanecıkıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphanecıkıs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphanecıkıs.ImageKey = "indir.jpg";
            this.btn_kutuphanecıkıs.ImageList = this.ımageList2;
            this.btn_kutuphanecıkıs.Location = new System.Drawing.Point(444, 42);
            this.btn_kutuphanecıkıs.Name = "btn_kutuphanecıkıs";
            this.btn_kutuphanecıkıs.Size = new System.Drawing.Size(131, 39);
            this.btn_kutuphanecıkıs.TabIndex = 27;
            this.btn_kutuphanecıkıs.Text = "çıkış";
            this.btn_kutuphanecıkıs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphanecıkıs.UseVisualStyleBackColor = false;
            this.btn_kutuphanecıkıs.Click += new System.EventHandler(this.btn_kutuphanecıkıs_Click);
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "indir.jpg");
            // 
            // btn_kutuphanekaydet
            // 
            this.btn_kutuphanekaydet.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphanekaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphanekaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphanekaydet.ImageKey = "floppy_disk_save-128.png";
            this.btn_kutuphanekaydet.ImageList = this.ımageList1;
            this.btn_kutuphanekaydet.Location = new System.Drawing.Point(289, 42);
            this.btn_kutuphanekaydet.Name = "btn_kutuphanekaydet";
            this.btn_kutuphanekaydet.Size = new System.Drawing.Size(131, 39);
            this.btn_kutuphanekaydet.TabIndex = 26;
            this.btn_kutuphanekaydet.Text = "kaydet";
            this.btn_kutuphanekaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphanekaydet.UseVisualStyleBackColor = false;
            this.btn_kutuphanekaydet.Click += new System.EventHandler(this.btn_kutuphanekaydet_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "floppy_disk_save-128.png");
            // 
            // dataGridView_kutuphane
            // 
            this.dataGridView_kutuphane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_kutuphane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_kutuphane.Location = new System.Drawing.Point(12, 236);
            this.dataGridView_kutuphane.Name = "dataGridView_kutuphane";
            this.dataGridView_kutuphane.Size = new System.Drawing.Size(434, 166);
            this.dataGridView_kutuphane.TabIndex = 35;
            this.dataGridView_kutuphane.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_kutuphane_CellClick);
            this.dataGridView_kutuphane.Click += new System.EventHandler(this.dataGridView_kutuphane_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_Id);
            this.groupBox1.Controls.Add(this.tb_Kutuphaneadı);
            this.groupBox1.Controls.Add(this.tb_Kutuphaneadres);
            this.groupBox1.Controls.Add(this.tb_Kutuphanepostakodu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 167);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YENİ KAYIT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_kutuphaneadi);
            this.groupBox2.Controls.Add(this.rb_adres);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(611, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 88);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARAMA";
            // 
            // btn_kutuphanesil
            // 
            this.btn_kutuphanesil.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphanesil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphanesil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphanesil.ImageKey = "images.jpg";
            this.btn_kutuphanesil.ImageList = this.ımageList8;
            this.btn_kutuphanesil.Location = new System.Drawing.Point(289, 182);
            this.btn_kutuphanesil.Name = "btn_kutuphanesil";
            this.btn_kutuphanesil.Size = new System.Drawing.Size(131, 38);
            this.btn_kutuphanesil.TabIndex = 39;
            this.btn_kutuphanesil.Text = "Sil";
            this.btn_kutuphanesil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphanesil.UseVisualStyleBackColor = false;
            this.btn_kutuphanesil.Click += new System.EventHandler(this.btn_kutuphanesil_Click);
            // 
            // ımageList8
            // 
            this.ımageList8.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList8.ImageStream")));
            this.ımageList8.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList8.Images.SetKeyName(0, "images.jpg");
            // 
            // btn_kutuphanelistele
            // 
            this.btn_kutuphanelistele.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_kutuphanelistele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kutuphanelistele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kutuphanelistele.ImageKey = "listeleme.jpg";
            this.btn_kutuphanelistele.ImageList = this.ımageList7;
            this.btn_kutuphanelistele.Location = new System.Drawing.Point(289, 133);
            this.btn_kutuphanelistele.Name = "btn_kutuphanelistele";
            this.btn_kutuphanelistele.Size = new System.Drawing.Size(131, 40);
            this.btn_kutuphanelistele.TabIndex = 38;
            this.btn_kutuphanelistele.Text = "listele";
            this.btn_kutuphanelistele.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kutuphanelistele.UseVisualStyleBackColor = false;
            this.btn_kutuphanelistele.Click += new System.EventHandler(this.btn_kutuphanelistele_Click);
            // 
            // ımageList7
            // 
            this.ımageList7.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList7.ImageStream")));
            this.ımageList7.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList7.Images.SetKeyName(0, "listeleme.jpg");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(647, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Arama Kriteri:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkCyan;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENÜToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENÜToolStripMenuItem
            // 
            this.mENÜToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anamenüToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.mENÜToolStripMenuItem.Image = global::kütüphaneotomasyonu.Properties.Resources.menü;
            this.mENÜToolStripMenuItem.Name = "mENÜToolStripMenuItem";
            this.mENÜToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.mENÜToolStripMenuItem.Text = "MENÜ";
            // 
            // anamenüToolStripMenuItem
            // 
            this.anamenüToolStripMenuItem.Image = global::kütüphaneotomasyonu.Properties.Resources.anamenü;
            this.anamenüToolStripMenuItem.Name = "anamenüToolStripMenuItem";
            this.anamenüToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.anamenüToolStripMenuItem.Text = "Anamenü";
            this.anamenüToolStripMenuItem.Click += new System.EventHandler(this.anamenüToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = global::kütüphaneotomasyonu.Properties.Resources.çıkış;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // kütüphanekayıt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(830, 410);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_kutuphanesil);
            this.Controls.Add(this.btn_kutuphanelistele);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_kutuphane);
            this.Controls.Add(this.tb_kutuphanearama);
            this.Controls.Add(this.btn_kutuphaneanamenu);
            this.Controls.Add(this.btn_kutuphanetemizle);
            this.Controls.Add(this.btn_kutuphaneguncelle);
            this.Controls.Add(this.btn_kutuphanecıkıs);
            this.Controls.Add(this.btn_kutuphanekaydet);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "kütüphanekayıt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KÜTÜPHANE KAYIT";
            this.Load += new System.EventHandler(this.kütüphanekayıt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kutuphane)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Id;
        private System.Windows.Forms.TextBox tb_Kutuphaneadı;
        private System.Windows.Forms.TextBox tb_Kutuphaneadres;
        private System.Windows.Forms.TextBox tb_Kutuphanepostakodu;
        private System.Windows.Forms.TextBox tb_kutuphanearama;
        private System.Windows.Forms.RadioButton rb_adres;
        private System.Windows.Forms.RadioButton rb_kutuphaneadi;
        private System.Windows.Forms.Button btn_kutuphaneanamenu;
        private System.Windows.Forms.Button btn_kutuphanetemizle;
        private System.Windows.Forms.Button btn_kutuphaneguncelle;
        private System.Windows.Forms.Button btn_kutuphanecıkıs;
        private System.Windows.Forms.Button btn_kutuphanekaydet;
        private System.Windows.Forms.DataGridView dataGridView_kutuphane;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.ImageList ımageList3;
        private System.Windows.Forms.ImageList ımageList4;
        private System.Windows.Forms.ImageList ımageList5;
        private System.Windows.Forms.ImageList ımageList6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_kutuphanesil;
        private System.Windows.Forms.ImageList ımageList8;
        private System.Windows.Forms.Button btn_kutuphanelistele;
        private System.Windows.Forms.ImageList ımageList7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENÜToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anamenüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}