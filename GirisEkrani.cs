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
    public partial class GirisEkrani : Form
    {
        public static string KimAldi { get; set; }
        public static string KimRol { get; set; }


        public GirisEkrani()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            sifreTxtBox.UseSystemPasswordChar = true;
        }

        private void girisBTN_Click(object sender, EventArgs e)
        {
            string kAdi = kAdiTxtBox.Text;
            string sifre = sifreTxtBox.Text;
            KimAldi = kAdi.ToString();

            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanici WHERE KullaniciAdi=@kAdi AND Sifre=@sifre", conn);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string rol = dr["Rol"].ToString();
                    KimRol = rol.ToString();

                    switch (rol)
                    {
                        case "Admin":
                            AdminSecimForm adminSecimForm = new AdminSecimForm();
                            adminSecimForm.Show();
                            this.Hide();
                            break;

                        case "Idareci":
                            IdareciSecimForm idareciSecimForm = new IdareciSecimForm();
                            idareciSecimForm.Show();
                            this.Hide();
                            break;

                        case "Personel":
                            PersonelForm personelForm = new PersonelForm();
                            personelForm.Show();
                            this.Hide();
                            break;

                        default:
                            MessageBox.Show("Yetkisiz rol.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                }
            }
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
