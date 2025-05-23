namespace kutuphane047
{
    partial class AdminSecimForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSecimForm));
            this.personelSecimBTN = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.idareciSecimBTN = new System.Windows.Forms.Button();
            this.adminSecimBTN = new System.Windows.Forms.Button();
            this.geriDonBTN = new System.Windows.Forms.Button();
            this.cikisBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personelSecimBTN
            // 
            this.personelSecimBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(149)))), ((int)(((byte)(158)))));
            this.personelSecimBTN.ImageKey = "personel-ikon.png";
            this.personelSecimBTN.ImageList = this.ımageList1;
            this.personelSecimBTN.Location = new System.Drawing.Point(539, 13);
            this.personelSecimBTN.Name = "personelSecimBTN";
            this.personelSecimBTN.Size = new System.Drawing.Size(249, 425);
            this.personelSecimBTN.TabIndex = 2;
            this.personelSecimBTN.UseVisualStyleBackColor = false;
            this.personelSecimBTN.Click += new System.EventHandler(this.personelSecimBTN_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "admin-ikon.png");
            this.ımageList1.Images.SetKeyName(1, "idareci-ikon.png");
            this.ımageList1.Images.SetKeyName(2, "personel-ikon.png");
            // 
            // idareciSecimBTN
            // 
            this.idareciSecimBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(139)))), ((int)(((byte)(130)))));
            this.idareciSecimBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idareciSecimBTN.ImageKey = "idareci-ikon.png";
            this.idareciSecimBTN.ImageList = this.ımageList1;
            this.idareciSecimBTN.Location = new System.Drawing.Point(276, 13);
            this.idareciSecimBTN.Name = "idareciSecimBTN";
            this.idareciSecimBTN.Size = new System.Drawing.Size(249, 425);
            this.idareciSecimBTN.TabIndex = 1;
            this.idareciSecimBTN.UseVisualStyleBackColor = false;
            this.idareciSecimBTN.Click += new System.EventHandler(this.idareciSecimBTN_Click);
            // 
            // adminSecimBTN
            // 
            this.adminSecimBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(179)))), ((int)(((byte)(166)))));
            this.adminSecimBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.adminSecimBTN.ImageKey = "admin-ikon.png";
            this.adminSecimBTN.ImageList = this.ımageList1;
            this.adminSecimBTN.Location = new System.Drawing.Point(12, 13);
            this.adminSecimBTN.Name = "adminSecimBTN";
            this.adminSecimBTN.Size = new System.Drawing.Size(249, 425);
            this.adminSecimBTN.TabIndex = 0;
            this.adminSecimBTN.UseVisualStyleBackColor = false;
            this.adminSecimBTN.Click += new System.EventHandler(this.adminSecimBTN_Click);
            // 
            // geriDonBTN
            // 
            this.geriDonBTN.Location = new System.Drawing.Point(723, 3);
            this.geriDonBTN.Name = "geriDonBTN";
            this.geriDonBTN.Size = new System.Drawing.Size(65, 23);
            this.geriDonBTN.TabIndex = 21;
            this.geriDonBTN.Text = "Geri Dön";
            this.geriDonBTN.UseVisualStyleBackColor = true;
            this.geriDonBTN.Click += new System.EventHandler(this.geriDonBTN_Click);
            // 
            // cikisBTN
            // 
            this.cikisBTN.Location = new System.Drawing.Point(12, 3);
            this.cikisBTN.Name = "cikisBTN";
            this.cikisBTN.Size = new System.Drawing.Size(71, 23);
            this.cikisBTN.TabIndex = 22;
            this.cikisBTN.Text = "Çıkış";
            this.cikisBTN.UseVisualStyleBackColor = true;
            this.cikisBTN.Click += new System.EventHandler(this.cikisBTN_Click);
            // 
            // AdminSecimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(210)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cikisBTN);
            this.Controls.Add(this.geriDonBTN);
            this.Controls.Add(this.personelSecimBTN);
            this.Controls.Add(this.idareciSecimBTN);
            this.Controls.Add(this.adminSecimBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminSecimForm";
            this.Text = "AdminSecimForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminSecimBTN;
        private System.Windows.Forms.Button idareciSecimBTN;
        private System.Windows.Forms.Button personelSecimBTN;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button geriDonBTN;
        private System.Windows.Forms.Button cikisBTN;
    }
}