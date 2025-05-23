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

namespace kutuphane047
{
    public partial class PersonelForm : Form
    {
        public  static string Rolu { get; set; }
        Personel personel = new Personel();
        public PersonelForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            oListele();            
            RunStoredProcedure();
            Rolu = GirisEkrani.KimRol.ToString();

            // Kitap Idleri Tab

            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitap", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }

        private void RunStoredProcedure()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateUyeCeza", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void oListele()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Odunc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            RunStoredProcedure();
        }

        // Odunc Ver Tab

        private void oduncVerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand kontrolCmd = new SqlCommand(@"
                         SELECT COUNT(*) FROM Odunc 
                         WHERE UyeTC = @tc AND KitapID = @kitapId AND VerisTarihi IS NULL", conn);

                    kontrolCmd.Parameters.AddWithValue("@tc", TCTxtBox.Text);
                    kontrolCmd.Parameters.AddWithValue("@kitapId", kitapIdTxtBox.Text);

                    int mevcutKayitSayisi = (int)kontrolCmd.ExecuteScalar();

                    if (mevcutKayitSayisi > 0)
                    {
                        MessageBox.Show("Bu üye bu kitabı zaten ödünç almış ve henüz iade etmemiş!");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Odunc (UyeTC, KitapID, AlisTarihi, VerisTarihi, Ceza, SonTeslim,Odeme)
                    VALUES (@tc, @kitapId, @alis, @veris,@ceza,@son,@odeme)", conn);

                    cmd.Parameters.AddWithValue("@tc", TCTxtBox.Text);
                    cmd.Parameters.AddWithValue("@kitapId", kitapIdTxtBox.Text);
                    cmd.Parameters.AddWithValue("@alis", alisDT.Value);

                    DateTime alisTarihi = DateTime.Parse(alisDT.Value.ToString());
                    DateTime? verisTarihi = string.IsNullOrEmpty(verisDT.Value.ToString()) ? (DateTime?)null : DateTime.Parse(verisDT.Value.ToString());

                    decimal ceza = 0;

                    if (!iadeEdilmediCheckBox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@veris", verisDT.Value);
                        int gunSayisi = (verisTarihi.Value - alisTarihi).Days;
                        if (gunSayisi > 15)
                        {
                            ceza = 30 + (gunSayisi - 15);
                            cmd.Parameters.AddWithValue("@ceza", ceza);
                        }
                        if (odemeCB.Checked)
                        {
                            cmd.Parameters.AddWithValue("@odeme", "Ödeme Alındı");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@odeme", "Ödeme Alınmadı");
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@odeme", DBNull.Value);
                        cmd.Parameters.AddWithValue("@veris", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ceza", 0.0);
                    }




                    DateTime sonTeslimTarihi = alisTarihi.AddDays(14);

                    cmd.Parameters.AddWithValue("@son", sonTeslimTarihi);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            oListele();
        }

        private void iadeAlBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int islemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Odunc SET VerisTarihi=@veris, Ceza=@ceza WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", islemId);

                    DateTime alisTarihi = DateTime.Parse(alisDT.Value.ToString());
                    DateTime? verisTarihi = string.IsNullOrEmpty(verisDT.Value.ToString()) ? (DateTime?)null : DateTime.Parse(verisDT.Value.ToString());

                    decimal ceza = 0;

                    if (!iadeEdilmediCheckBox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@veris", verisDT.Value);
                        int gunSayisi = (verisTarihi.Value - alisTarihi).Days;
                        ceza = gunSayisi > 15 ? 30 + (gunSayisi - 15) : 0;
                        cmd.Parameters.AddWithValue("@ceza", ceza);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@veris", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ceza", 0);
                    }

                    cmd.ExecuteNonQuery();
                }

                oListele();
            }

        }

        private void uyeGecmisBTN_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Odunc WHERE UyeTC = @TC", conn);
                cmd.Parameters.AddWithValue("@TC", TCTxtBox.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void iadeYokListeleBTN_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Odunc WHERE VerisTarihi IS NULL", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void tumunuListeleBTN_Click(object sender, EventArgs e)
        {
            oListele();
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void temizleBTN_Click(object sender, EventArgs e)
        {
            TCTxtBox.Text = "";
            kitapIdTxtBox.Text = "";
            alisDT.Value = DateTime.Now;
            verisDT.Value = DateTime.Now;
            sonTeslimDT.Value = DateTime.Now;
            oCezaTxtBox.Text = "";
        }

        private void silBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int islemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Odunc WHERE ID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", islemId);
                    cmd.ExecuteNonQuery();
                }

                oListele();
            }
        }

        private void guncelleBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kitapId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Odunc SET UyeTC=@tc, KitapID=@kitapID, AlisTarihi=@alis, VerisTarihi=@veris, Ceza=@ceza, Odeme=@odeme WHERE ID=@id", conn);
                    cmd.Parameters.AddWithValue("@tc", TCTxtBox.Text);
                    cmd.Parameters.AddWithValue("@kitapId", kitapIdTxtBox.Text);
                    cmd.Parameters.AddWithValue("@alis", alisDT.Value);
                    cmd.Parameters.AddWithValue("@id", kitapId);


                    DateTime alisTarihi = DateTime.Parse(alisDT.Value.ToString());
                    DateTime? verisTarihi = string.IsNullOrEmpty(verisDT.Value.ToString()) ? (DateTime?)null : DateTime.Parse(verisDT.Value.ToString());

                    decimal ceza = 0;

                    if (!iadeEdilmediCheckBox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@veris", verisDT.Value);
                        int gunSayisi = (verisTarihi.Value - alisTarihi).Days;
                        if (gunSayisi >= 15)
                        {
                            ceza = 30 + (gunSayisi - 15);
                            cmd.Parameters.AddWithValue("@ceza", ceza);
                            if (odemeCB.Checked)
                            {
                                cmd.Parameters.AddWithValue("@odeme", "Ödeme Alındı");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@odeme", "Ödeme Alınmadı");
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ceza", ceza);
                            cmd.Parameters.AddWithValue("@odeme", DBNull.Value);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@odeme", DBNull.Value);
                        cmd.Parameters.AddWithValue("@veris", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ceza", 0.0);
                    }

                    cmd.ExecuteNonQuery();
                }

                oListele();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                TCTxtBox.Text = row.Cells["UyeTC"].Value.ToString();
                kitapIdTxtBox.Text = row.Cells["KitapID"].Value.ToString();
                alisDT.Text = row.Cells["AlisTarihi"].Value.ToString();
                verisDT.Text = row.Cells["VerisTarihi"].Value.ToString();
                sonTeslimDT.Text = row.Cells["SonTeslim"].Value.ToString();
                oCezaTxtBox.Text = row.Cells["Ceza"].Value.ToString();
                if (row.Cells["Odeme"].Value.ToString() == "Ödeme Alındı")
                {
                    odemeCB.Checked = true;
                }
                else if (row.Cells["Odeme"].Value.ToString() == "Ödeme Alınmadı")
                {
                    odemeCB.Checked = false;
                }
                else
                {
                    odemeCB.Checked = false;
                }
            }
        }

        private void oAraBTN_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Odunc WHERE " +
                        "(@tc = '' OR UyeTC LIKE '%' + @tc + '%') AND " +
                        "(@kitap = '' OR KitapID LIKE '%' + @kitap + '%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", TCTxtBox.Text);
                cmd.Parameters.AddWithValue("@kitap", kitapIdTxtBox.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }


        // Uye Ekle Tab

        private void ekleBTN_Click(object sender, EventArgs e)
        {
            personel.TcNo = uTcTxtBox.Text;
            personel.Ad=adTxtBox.Text;
            personel.Soyad=soyadTxtBox.Text;
            personel.Eposta=epostaTxtBox.Text;
            personel.Ceza=cezaTxtBox.Text;
            personel.Ekle();
            dataGridView2.DataSource = personel.Listele();
        }

        private void uyeSilBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int uyeId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                personel.Sil(uyeId);
                dataGridView2.DataSource = personel.Listele();
                RunStoredProcedure();
            }
        }

        private void uyeGuncelleBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int uyeId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                    personel.TcNo = uTcTxtBox.Text;
                    personel.Ad = adTxtBox.Text;
                    personel.Soyad = soyadTxtBox.Text;
                    personel.Eposta = epostaTxtBox.Text;
                    personel.Ceza = cezaTxtBox.Text;
                    personel.Guncelle(uyeId);
                    dataGridView2.DataSource = personel.Listele();
                    RunStoredProcedure();
                }
            }
            catch (Exception ex)
            {
                string kimk = GirisEkrani.KimAldi.ToString();
                MessageBox.Show("Lütfen Admin ile iletişime geçiniz", "Hata");
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Hata (HatayiAlan, HataMesaji, CozulduMu) VALUES (@kim, @mesaj, @cozuldumu)", conn);
                    cmd.Parameters.AddWithValue("@kim", kimk);
                    cmd.Parameters.AddWithValue("@mesaj", ex.Message);
                    cmd.Parameters.AddWithValue("cozuldumu", 0);
                    cmd.ExecuteNonQuery();
                }
            }
            dataGridView2.DataSource=personel.Listele();
            RunStoredProcedure();
        }

        private void listeleBTN_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource=personel.Listele();
            RunStoredProcedure();
        }

        private void araBTN_Click(object sender, EventArgs e)
        {
            personel.TcNo = uTcTxtBox.Text;
            personel.Ad = adTxtBox.Text;
            personel.Soyad = soyadTxtBox.Text;
            personel.Eposta = epostaTxtBox.Text;
            personel.Ceza = cezaTxtBox.Text;
            dataGridView2.DataSource=personel.Ara();
            RunStoredProcedure();
        }

        private void uyeTemizleBTN_Click(object sender, EventArgs e)
        {
            uTcTxtBox.Text = "";
            adTxtBox.Text = "";
            soyadTxtBox.Text = "";
            epostaTxtBox.Text = "";
            cezaTxtBox.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                uTcTxtBox.Text = row.Cells["TC"].Value.ToString();
                adTxtBox.Text = row.Cells["Ad"].Value.ToString();
                soyadTxtBox.Text = row.Cells["Soyad"].Value.ToString();
                epostaTxtBox.Text = row.Cells["Eposta"].Value.ToString();
                cezaTxtBox.Text = row.Cells["Ceza"].Value.ToString();
            }
        }

        private void uCikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriDonBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Rolu == "Admin")
            {
                this.Close();
                AdminSecimForm adminSecimForm = new AdminSecimForm();
                adminSecimForm.Show();
            }
            else if (Rolu == "Personel")
            {
                this.Close();
                GirisEkrani form1 = new GirisEkrani();
                form1.Show();
            }
            
        }

        
    }
}
