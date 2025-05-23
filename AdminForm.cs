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
    public partial class AdminForm: Form
    {
        Admin admin = new Admin();
        public AdminForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }


        private void ekleBTN_Click(object sender, EventArgs e)
        {
            admin.Ad = adTxtBox.Text;
            admin.Soyad = soyadTxtBox.Text;
            admin.Sifre = sifreTxtBox.Text;
            admin.Rol = rolComboBox.SelectedItem.ToString() ?? "";

            admin.Ekle();
            dataGridView1.DataSource=admin.Listele();
        }

        private void silBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                admin.Sil(id);
                dataGridView1.DataSource = admin.Listele();
            }
        }

        private void guncelleBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                admin.KullaniciAdi = kAdTxtBox.Text;
                admin.Ad = adTxtBox.Text;
                admin.Soyad = soyadTxtBox.Text;
                admin.Sifre = sifreTxtBox.Text;
                admin.Rol = rolComboBox.SelectedItem.ToString() ?? "";

                admin.Guncelle(id);
                dataGridView1.DataSource = admin.Listele();
            }
        }

        private void listeleBTN_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = admin.Listele();
        }

        private void araBTN_Click(object sender, EventArgs e)
        {
            try
            {
                admin.KullaniciAdi = kAdTxtBox.Text;
                admin.Ad = adTxtBox.Text;
                admin.Soyad = soyadTxtBox.Text;
                admin.Sifre = sifreTxtBox.Text;
                admin.Rol = rolComboBox.SelectedItem.ToString() ?? "";
                dataGridView1.DataSource = admin.Ara();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                kAdTxtBox.Text = row.Cells["KullaniciAdi"].Value.ToString();
                adTxtBox.Text = row.Cells["Ad"].Value.ToString();
                soyadTxtBox.Text = row.Cells["Soyad"].Value.ToString();
                sifreTxtBox.Text = row.Cells["Sifre"].Value.ToString();
                rolComboBox.Text = row.Cells["Rol"].Value.ToString();
            }
        }

        private void temizleBTN_Click(object sender, EventArgs e)
        {
            kAdTxtBox.Text = "";
            adTxtBox.Text = "";
            soyadTxtBox.Text = "";
            sifreTxtBox.Text = "";
            rolComboBox.Text = "";
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriDonBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSecimForm adminSecimForm = new AdminSecimForm();
            adminSecimForm.Show();
        }
    }
}
