namespace kutuphane047
{
    partial class GirisEkrani
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
            this.kAdiTxtBox = new System.Windows.Forms.TextBox();
            this.sifreTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.girisBTN = new System.Windows.Forms.Button();
            this.cikisBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kAdiTxtBox
            // 
            this.kAdiTxtBox.Location = new System.Drawing.Point(74, 101);
            this.kAdiTxtBox.Name = "kAdiTxtBox";
            this.kAdiTxtBox.Size = new System.Drawing.Size(144, 20);
            this.kAdiTxtBox.TabIndex = 0;
            // 
            // sifreTxtBox
            // 
            this.sifreTxtBox.Location = new System.Drawing.Point(74, 137);
            this.sifreTxtBox.Name = "sifreTxtBox";
            this.sifreTxtBox.Size = new System.Drawing.Size(144, 20);
            this.sifreTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre: ";
            // 
            // girisBTN
            // 
            this.girisBTN.Location = new System.Drawing.Point(74, 177);
            this.girisBTN.Name = "girisBTN";
            this.girisBTN.Size = new System.Drawing.Size(144, 23);
            this.girisBTN.TabIndex = 4;
            this.girisBTN.Text = "Giriş Yap";
            this.girisBTN.UseVisualStyleBackColor = true;
            this.girisBTN.Click += new System.EventHandler(this.girisBTN_Click);
            // 
            // cikisBTN
            // 
            this.cikisBTN.Location = new System.Drawing.Point(7, 177);
            this.cikisBTN.Name = "cikisBTN";
            this.cikisBTN.Size = new System.Drawing.Size(52, 23);
            this.cikisBTN.TabIndex = 16;
            this.cikisBTN.Text = "Çıkış";
            this.cikisBTN.UseVisualStyleBackColor = true;
            this.cikisBTN.Click += new System.EventHandler(this.cikisBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Giriş Yapınız";
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(210)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(230, 300);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cikisBTN);
            this.Controls.Add(this.girisBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreTxtBox);
            this.Controls.Add(this.kAdiTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GirisEkrani";
            this.Text = "Kütüphane Otomasyon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kAdiTxtBox;
        private System.Windows.Forms.TextBox sifreTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button girisBTN;
        private System.Windows.Forms.Button cikisBTN;
        private System.Windows.Forms.Label label3;
    }
}

