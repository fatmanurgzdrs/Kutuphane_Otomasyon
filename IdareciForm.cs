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
    public partial class IdareciForm : Form
    {
        Idareci idareci = new Idareci();
        Kitap kitap = new Kitap();

        public static string Rolu { get; set; }

        public IdareciForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            rolComboBox.Text = "Personel";
            rolComboBox.Enabled = false;
            Rolu = GirisEkrani.KimRol.ToString();
        }


        // Kitap Ekle Tab

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ekleBTN_Click(object sender, EventArgs e)
        {
            kitap.Ad=kitapAdiTxtBox.Text;
            kitap.Yazar=yazarTxtBox.Text;
            kitap.YayinEvi=yayineviTxtBox.Text;
            kitap.Yil=yayinYiliTxtBox.Text;
            kitap.Tur=turTxtBox.Text;
            kitap.Dil=dilTxtBox.Text;
            kitap.Stok= stokTxtBox.Text;
            kitap.Ekle();

            dataGridView1.DataSource= kitap.Listele();

        }

        private void silBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kitapId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                kitap.Sil(kitapId);          
            }
            dataGridView1.DataSource = kitap.Listele();
        }

        private void guncelleBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kitapId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                
                kitap.Ad = kitapAdiTxtBox.Text;
                kitap.Yazar = yazarTxtBox.Text;
                kitap.YayinEvi = yayineviTxtBox.Text;
                kitap.Yil = yayinYiliTxtBox.Text;
                kitap.Tur = turTxtBox.Text;
                kitap.Dil = dilTxtBox.Text;
                kitap.Stok = stokTxtBox.Text;
                kitap.Guncelle(kitapId);

                dataGridView1.DataSource = kitap.Listele();
            }
        }

        private void listeleBTN_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kitap.Listele();
        }

        private void araBTN_Click(object sender, EventArgs e)
        {
            kitap.Ad = kitapAdiTxtBox.Text;
            kitap.Yazar = yazarTxtBox.Text;
            kitap.YayinEvi = yayineviTxtBox.Text;
            kitap.Yil = yayinYiliTxtBox.Text;
            kitap.Tur = turTxtBox.Text;
            kitap.Dil = dilTxtBox.Text;
            kitap.Stok = stokTxtBox.Text;
            dataGridView1.DataSource = kitap.Ara();
        }

        private void temizleBTN_Click(object sender, EventArgs e)
        {
            kitapAdiTxtBox.Text = "";
            yazarTxtBox.Text = "";
            yayineviTxtBox.Text = "";
            yayinYiliTxtBox.Text = "";
            turTxtBox.Text = "";
            dilTxtBox.Text = "";
            stokTxtBox.Text = "";
        }

        private void raporAlBTN_Click(object sender, EventArgs e)
        {
            idareci.RaporAl();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                try
                {
                    kitapAdiTxtBox.Text = row.Cells["Ad"].Value.ToString();
                    yazarTxtBox.Text = row.Cells["Yazar"].Value.ToString();
                    yayineviTxtBox.Text = row.Cells["YayinEvi"].Value.ToString();
                    yayinYiliTxtBox.Text = row.Cells["Yil"].Value.ToString();
                    turTxtBox.Text = row.Cells["Tur"].Value.ToString();
                    dilTxtBox.Text = row.Cells["Dil"].Value.ToString();
                    stokTxtBox.Text = row.Cells["StokDurumu"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hücre verileri alınırken hata oluştu: " + ex.Message);
                }
            }
        }

        private void stokBitenBTN_Click(object sender, EventArgs e)
        {
            kitap.Ad = kitapAdiTxtBox.Text;
            kitap.Yazar = yazarTxtBox.Text;
            kitap.YayinEvi = yayineviTxtBox.Text;
            kitap.Yil = yayinYiliTxtBox.Text;
            kitap.Tur = turTxtBox.Text;
            kitap.Dil = dilTxtBox.Text;
            kitap.Stok = stokTxtBox.Text;
            dataGridView1.DataSource = kitap.StokBiten();
        }

        private void stokAzBTN_Click(object sender, EventArgs e)
        {
            kitap.Ad = kitapAdiTxtBox.Text;
            kitap.Yazar = yazarTxtBox.Text;
            kitap.YayinEvi = yayineviTxtBox.Text;
            kitap.Yil = yayinYiliTxtBox.Text;
            kitap.Tur = turTxtBox.Text;
            kitap.Dil = dilTxtBox.Text;
            kitap.Stok = stokTxtBox.Text;
            dataGridView1.DataSource = kitap.StokAz();
        }

        // Personel Ekle Tab

        private void pEkleBTN_Click(object sender, EventArgs e)
        {
            idareci.Ad = adTxtBox.Text;
            idareci.Soyad = soyadTxtBox.Text;
            idareci.Sifre = sifreTxtBox.Text;
            idareci.Rol = rolComboBox.SelectedItem.ToString();

            idareci.Ekle();

            dataGridView2.DataSource=idareci.Listele();
        }

        private void pSilBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int personelId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                idareci.Sil(personelId);
                dataGridView2.DataSource = idareci.Listele();
            }
        }

        private void pGuncelleBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int personelId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);

                idareci.KullaniciAdi = kAdTxtBox.Text;
                idareci.Ad = adTxtBox.Text;
                idareci.Soyad = soyadTxtBox.Text;
                idareci.Sifre = sifreTxtBox.Text;
                idareci.Rol = rolComboBox.SelectedItem.ToString();
                idareci.Guncelle(personelId);
                dataGridView2.DataSource = idareci.Listele();
            }
        }

        private void pListeleBTN_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = idareci.Listele();
        }

        private void pAraBTN_Click(object sender, EventArgs e)
        {
            idareci.KullaniciAdi = kAdTxtBox.Text;
            idareci.Ad = adTxtBox.Text;
            idareci.Soyad = soyadTxtBox.Text;
            idareci.Sifre = sifreTxtBox.Text;
            dataGridView2.DataSource = idareci.Ara();
        }

        private void pTemizleBTN_Click(object sender, EventArgs e)
        {
            kAdTxtBox.Text = "";
            adTxtBox.Text = "";
            soyadTxtBox.Text = "";
            sifreTxtBox.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                try
                {
                    kAdTxtBox.Text = row.Cells["KullaniciAdi"].Value?.ToString() ?? "";
                    adTxtBox.Text = row.Cells["Ad"].Value?.ToString() ?? "";
                    soyadTxtBox.Text = row.Cells["Soyad"].Value?.ToString() ?? "";
                    sifreTxtBox.Text = row.Cells["Sifre"].Value?.ToString() ?? "";
                    rolComboBox.Text = row.Cells["Rol"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hücre verileri alınırken hata oluştu: " + ex.Message);
                }
            }
        }

        private void pCikisBTN_Click(object sender, EventArgs e)
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
            else if (Rolu == "Idareci")
            {
                this.Close();
                IdareciSecimForm idareciSecimForm = new IdareciSecimForm();
                idareciSecimForm.Show();
            }

        }
    }

}
