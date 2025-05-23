namespace kutuphane047
{
    partial class AdminForm
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
            this.kAdTxtBox = new System.Windows.Forms.TextBox();
            this.adTxtBox = new System.Windows.Forms.TextBox();
            this.soyadTxtBox = new System.Windows.Forms.TextBox();
            this.sifreTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ekleBTN = new System.Windows.Forms.Button();
            this.guncelleBTN = new System.Windows.Forms.Button();
            this.araBTN = new System.Windows.Forms.Button();
            this.silBTN = new System.Windows.Forms.Button();
            this.listeleBTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rolComboBox = new System.Windows.Forms.ComboBox();
            this.temizleBTN = new System.Windows.Forms.Button();
            this.cikisBTN = new System.Windows.Forms.Button();
            this.geriDonBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kAdTxtBox
            // 
            this.kAdTxtBox.Enabled = false;
            this.kAdTxtBox.Location = new System.Drawing.Point(86, 27);
            this.kAdTxtBox.Name = "kAdTxtBox";
            this.kAdTxtBox.Size = new System.Drawing.Size(134, 20);
            this.kAdTxtBox.TabIndex = 0;
            // 
            // adTxtBox
            // 
            this.adTxtBox.Location = new System.Drawing.Point(86, 63);
            this.adTxtBox.Name = "adTxtBox";
            this.adTxtBox.Size = new System.Drawing.Size(134, 20);
            this.adTxtBox.TabIndex = 1;
            // 
            // soyadTxtBox
            // 
            this.soyadTxtBox.Location = new System.Drawing.Point(86, 101);
            this.soyadTxtBox.Name = "soyadTxtBox";
            this.soyadTxtBox.Size = new System.Drawing.Size(134, 20);
            this.soyadTxtBox.TabIndex = 2;
            // 
            // sifreTxtBox
            // 
            this.sifreTxtBox.Location = new System.Drawing.Point(86, 140);
            this.sifreTxtBox.Name = "sifreTxtBox";
            this.sifreTxtBox.Size = new System.Drawing.Size(134, 20);
            this.sifreTxtBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Soyad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Şifre:";
            // 
            // ekleBTN
            // 
            this.ekleBTN.Location = new System.Drawing.Point(245, 25);
            this.ekleBTN.Name = "ekleBTN";
            this.ekleBTN.Size = new System.Drawing.Size(261, 23);
            this.ekleBTN.TabIndex = 10;
            this.ekleBTN.Text = "Ekle";
            this.ekleBTN.UseVisualStyleBackColor = true;
            this.ekleBTN.Click += new System.EventHandler(this.ekleBTN_Click);
            // 
            // guncelleBTN
            // 
            this.guncelleBTN.Location = new System.Drawing.Point(245, 99);
            this.guncelleBTN.Name = "guncelleBTN";
            this.guncelleBTN.Size = new System.Drawing.Size(261, 23);
            this.guncelleBTN.TabIndex = 11;
            this.guncelleBTN.Text = "Güncelle";
            this.guncelleBTN.UseVisualStyleBackColor = true;
            this.guncelleBTN.Click += new System.EventHandler(this.guncelleBTN_Click);
            // 
            // araBTN
            // 
            this.araBTN.Location = new System.Drawing.Point(245, 177);
            this.araBTN.Name = "araBTN";
            this.araBTN.Size = new System.Drawing.Size(261, 23);
            this.araBTN.TabIndex = 12;
            this.araBTN.Text = "Ara";
            this.araBTN.UseVisualStyleBackColor = true;
            this.araBTN.Click += new System.EventHandler(this.araBTN_Click);
            // 
            // silBTN
            // 
            this.silBTN.Location = new System.Drawing.Point(245, 61);
            this.silBTN.Name = "silBTN";
            this.silBTN.Size = new System.Drawing.Size(261, 23);
            this.silBTN.TabIndex = 13;
            this.silBTN.Text = "Sil";
            this.silBTN.UseVisualStyleBackColor = true;
            this.silBTN.Click += new System.EventHandler(this.silBTN_Click);
            // 
            // listeleBTN
            // 
            this.listeleBTN.Location = new System.Drawing.Point(245, 138);
            this.listeleBTN.Name = "listeleBTN";
            this.listeleBTN.Size = new System.Drawing.Size(261, 23);
            this.listeleBTN.TabIndex = 14;
            this.listeleBTN.Text = "Listele";
            this.listeleBTN.UseVisualStyleBackColor = true;
            this.listeleBTN.Click += new System.EventHandler(this.listeleBTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(496, 186);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(245, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 231);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlemler";
            // 
            // rolComboBox
            // 
            this.rolComboBox.FormattingEnabled = true;
            this.rolComboBox.Items.AddRange(new object[] {
            "Lütfen Seçim Yapınız.",
            "Admin",
            "Idareci",
            "Personel"});
            this.rolComboBox.Location = new System.Drawing.Point(86, 183);
            this.rolComboBox.Name = "rolComboBox";
            this.rolComboBox.Size = new System.Drawing.Size(134, 21);
            this.rolComboBox.TabIndex = 17;
            // 
            // temizleBTN
            // 
            this.temizleBTN.Location = new System.Drawing.Point(245, 214);
            this.temizleBTN.Name = "temizleBTN";
            this.temizleBTN.Size = new System.Drawing.Size(261, 23);
            this.temizleBTN.TabIndex = 18;
            this.temizleBTN.Text = "Temizle";
            this.temizleBTN.UseVisualStyleBackColor = true;
            this.temizleBTN.Click += new System.EventHandler(this.temizleBTN_Click);
            // 
            // cikisBTN
            // 
            this.cikisBTN.Location = new System.Drawing.Point(86, 214);
            this.cikisBTN.Name = "cikisBTN";
            this.cikisBTN.Size = new System.Drawing.Size(134, 23);
            this.cikisBTN.TabIndex = 19;
            this.cikisBTN.Text = "Çıkış";
            this.cikisBTN.UseVisualStyleBackColor = true;
            this.cikisBTN.Click += new System.EventHandler(this.cikisBTN_Click);
            // 
            // geriDonBTN
            // 
            this.geriDonBTN.Location = new System.Drawing.Point(15, 213);
            this.geriDonBTN.Name = "geriDonBTN";
            this.geriDonBTN.Size = new System.Drawing.Size(65, 23);
            this.geriDonBTN.TabIndex = 20;
            this.geriDonBTN.Text = "Geri Dön";
            this.geriDonBTN.UseVisualStyleBackColor = true;
            this.geriDonBTN.Click += new System.EventHandler(this.geriDonBTN_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(179)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(523, 456);
            this.Controls.Add(this.geriDonBTN);
            this.Controls.Add(this.cikisBTN);
            this.Controls.Add(this.temizleBTN);
            this.Controls.Add(this.rolComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listeleBTN);
            this.Controls.Add(this.silBTN);
            this.Controls.Add(this.araBTN);
            this.Controls.Add(this.guncelleBTN);
            this.Controls.Add(this.ekleBTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreTxtBox);
            this.Controls.Add(this.soyadTxtBox);
            this.Controls.Add(this.adTxtBox);
            this.Controls.Add(this.kAdTxtBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kAdTxtBox;
        private System.Windows.Forms.TextBox adTxtBox;
        private System.Windows.Forms.TextBox soyadTxtBox;
        private System.Windows.Forms.TextBox sifreTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ekleBTN;
        private System.Windows.Forms.Button guncelleBTN;
        private System.Windows.Forms.Button araBTN;
        private System.Windows.Forms.Button silBTN;
        private System.Windows.Forms.Button listeleBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox rolComboBox;
        private System.Windows.Forms.Button temizleBTN;
        private System.Windows.Forms.Button cikisBTN;
        private System.Windows.Forms.Button geriDonBTN;
    }
}