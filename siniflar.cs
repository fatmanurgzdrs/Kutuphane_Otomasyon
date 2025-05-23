using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane047
{
    public class Kitap : IKitapIslemleri
    {
        private int id;
        private string ad, yazar, yayinEvi, tur, dil, yil, stok;

        public int Id { get => id; set => id = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Yazar { get => yazar; set => yazar = value; }
        public string YayinEvi { get => yayinEvi; set => yayinEvi = value; }
        public string Yil { get => yil; set => yil = value; }
        public string Tur { get => tur; set => tur = value; }
        public string Dil { get => dil; set => dil = value; }
        public string Stok { get => stok; set => stok = value; }

        public Kitap()
        {
            this.ad = "Nutuk";
            this.yazar = "Mustafa Kemal Atatürk";
            this.yayinEvi = "Cumhuriyet";
            this.yil = "1927";
        }

        public Kitap(string ad, string yazar)
        {
            this.ad = ad;
            this.yazar = yazar;
        }

        public virtual void Ekle()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand kontrolCmd = new SqlCommand("SELECT COUNT(*) FROM Kitap WHERE " +
                    "Ad = @ad AND Yazar = @yazar AND YayinEvi = @yayinevi AND Yil = @yil AND Tur = @tur AND Dil = @dil", conn);
                kontrolCmd.Parameters.AddWithValue("@ad", Ad);
                kontrolCmd.Parameters.AddWithValue("@yazar", Yazar);
                kontrolCmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                kontrolCmd.Parameters.AddWithValue("@yil", Yil);
                kontrolCmd.Parameters.AddWithValue("@tur", Tur);
                kontrolCmd.Parameters.AddWithValue("@dil", Dil);

                int mevcutKayit = (int)kontrolCmd.ExecuteScalar();

                if (mevcutKayit > 0)
                {
                    MessageBox.Show("Bu kitap zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Kitap (Ad, Yazar, YayinEvi, Yil, Tur, Dil, StokDurumu) " +
                        "VALUES (@ad, @yazar, @yayinevi, @yil, @tur, @dil, @stokdurumu)", conn);
                    cmd.Parameters.AddWithValue("@ad", Ad);
                    cmd.Parameters.AddWithValue("@yazar", Yazar);
                    cmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                    cmd.Parameters.AddWithValue("@yil", Yil);
                    cmd.Parameters.AddWithValue("@tur", Tur);
                    cmd.Parameters.AddWithValue("@dil", Dil);
                    cmd.Parameters.AddWithValue("@stokdurumu", Stok);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public object Listele()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitap", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        public object Ara()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Kitap WHERE " +
                        "(@ad = '' OR Ad LIKE '%' + @ad + '%') AND " +
                        "(@yazar = '' OR Yazar LIKE '%' + @yazar + '%') AND " +
                        "(@yayinevi = '' OR YayinEvi LIKE '%' + @yayinevi + '%') AND " +
                        "(@yil = '' OR Yil LIKE '%' + @yil + '%') AND " +
                        "(@tur = '' OR Tur LIKE '%' + @tur + '%') AND " +
                        "(@dil = '' OR Dil LIKE '%' + @dil + '%') AND " +
                        "(@stokdurumu = '' OR StokDurumu LIKE '%' + @stokdurumu + '%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@yazar", Yazar);
                cmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                cmd.Parameters.AddWithValue("@yil", Yil);
                cmd.Parameters.AddWithValue("@tur", Tur);
                cmd.Parameters.AddWithValue("@dil", Dil);
                cmd.Parameters.AddWithValue("@stokdurumu", Stok);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public void Guncelle(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Kitap SET Ad=@ad, Yazar=@yazar, YayinEvi=@yayinevi, " +
                    "Yil=@yil, Tur=@tur, Dil=@dil, StokDurumu=@stokdurumu WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@yazar", Yazar);
                cmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                cmd.Parameters.AddWithValue("@yil", Yil);
                cmd.Parameters.AddWithValue("@tur", Tur);
                cmd.Parameters.AddWithValue("@dil", Dil);
                cmd.Parameters.AddWithValue("@stokdurumu", Stok);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

        }
        public void Sil(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Kitap WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public void Kontrol(int kitapId)
        {
            MessageBox.Show($"Kitap ID {kitapId} için stok kontrol edildi.");
        }

        public object StokBiten()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Kitap WHERE StokDurumu=0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@yazar", Yazar);
                cmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                cmd.Parameters.AddWithValue("@yil", Yil);
                cmd.Parameters.AddWithValue("@tur", Tur);
                cmd.Parameters.AddWithValue("@dil", Dil);
                cmd.Parameters.AddWithValue("@stokdurumu", Stok);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public object StokAz()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Kitap WHERE StokDurumu BETWEEN 1 AND 10";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@yazar", Yazar);
                cmd.Parameters.AddWithValue("@yayinevi", YayinEvi);
                cmd.Parameters.AddWithValue("@yil", Yil);
                cmd.Parameters.AddWithValue("@tur", Tur);
                cmd.Parameters.AddWithValue("@dil", Dil);
                cmd.Parameters.AddWithValue("@stokdurumu", Stok);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }

    public abstract class Kullanici
    {
        private string kullaniciAdi, ad, soyad, sifre, rol, eposta;
        private string tcNo, ceza;
        public static int kullaniciSayisi = 0;

        public string KullaniciAdi { get => kullaniciAdi; set => kullaniciAdi = value; }
        public string TcNo { get => tcNo; set => tcNo = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Eposta { get => eposta; set => eposta = value; }
        public string Ceza { get => ceza; set => ceza = value; }

        public static string ingilizlestir(string input)
        {
            StringBuilder sb = new StringBuilder(input);
            sb.Replace('ç', 'c');
            sb.Replace('ğ', 'g');
            sb.Replace('ı', 'i');
            sb.Replace('ö', 'o');
            sb.Replace('ş', 's');
            sb.Replace('ü', 'u');
            return sb.ToString();
        }
        public static string birlestirmeİslemi(string s1, string s2)
        {
            string birlesik = s1.ToLower() + s2.ToLower();
            return ingilizlestir(birlesik);
        }

        public Kullanici()
        {
            kullaniciSayisi++;
        }

        public static void kSayisiGoster()
        {
            MessageBox.Show("Toplam Mevcut Kullanıcı Sayısı: " + kullaniciSayisi);
        }
        public abstract void Yetki();
    }

    public class Admin : Kullanici, IKullaniciIslemleri
    {
        public override void Yetki()
        {
            MessageBox.Show("Admin Yetkisi");
        }
        public void Ekle()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Kullanici (Ad, Soyad, Sifre, Rol) " +
                    "VALUES (@ad, @soyad, @sifre, @rol); SELECT SCOPE_IDENTITY();", conn);

                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@sifre", Sifre);
                cmd.Parameters.AddWithValue("@rol", Rol);

                var yeniId = cmd.ExecuteScalar();

                string kullaniciAdi;

                if (yeniId.ToString().Length == 1)
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + "00" + yeniId.ToString();
                }
                else if (yeniId.ToString().Length == 2)
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + "0" + yeniId.ToString();
                }
                else
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + yeniId.ToString();
                }

                SqlCommand updateCmd = new SqlCommand("UPDATE Kullanici SET KullaniciAdi = @kullaniciAdi WHERE Id = @id", conn);
                updateCmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                updateCmd.Parameters.AddWithValue("@id", yeniId);

                updateCmd.ExecuteNonQuery();
            }

        }

        public object Listele()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kullanici", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public object Ara()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Kullanici WHERE " +
                        "(@kadi = '' OR KullaniciAdi LIKE '%' + @kadi + '%') AND " +
                        "(@ad = '' OR Ad LIKE '%' + @ad + '%') AND " +
                        "(@soyad = '' OR Soyad LIKE '%' + @soyad + '%') AND " +
                        "(@sifre = '' OR Sifre LIKE '%' + @sifre + '%') AND " +
                        "(@rol = '' OR Rol LIKE '%' + @rol + '%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kadi", KullaniciAdi);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@sifre", Sifre);
                cmd.Parameters.AddWithValue("@rol", Rol);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public void Guncelle(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Kullanici SET Ad=@ad, Soyad=@soyad, Sifre=@sifre, Rol=@rol WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@kullaniciAdi", (Ad + Soyad));
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@sifre", Sifre);
                cmd.Parameters.AddWithValue("@rol", Rol);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Kullanici WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class Idareci : Kullanici, IIdareIslemleri
    {
        public override void Yetki()
        {
            MessageBox.Show("İdareci Yetkisi");
        }
        public void Ekle()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Kullanici (Ad, Soyad, Sifre, Rol) " +
                    "VALUES (@ad, @soyad, @sifre, @rol); SELECT SCOPE_IDENTITY();", conn);

                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@sifre", Sifre);
                cmd.Parameters.AddWithValue("@rol", Rol);

                var yeniId = cmd.ExecuteScalar();

                string kullaniciAdi;

                if (yeniId.ToString().Length == 1)
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + "00" + yeniId.ToString();
                }
                else if (yeniId.ToString().Length == 2)
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + "0" + yeniId.ToString();
                }
                else
                {
                    kullaniciAdi = birlestirmeİslemi(Ad, Soyad) + yeniId.ToString();
                }

                SqlCommand updateCmd = new SqlCommand("UPDATE Kullanici SET KullaniciAdi = @kullaniciAdi WHERE Id = @id", conn);
                updateCmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                updateCmd.Parameters.AddWithValue("@id", yeniId);

                updateCmd.ExecuteNonQuery();
            }

        }

        public object Listele()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kullanici WHERE Rol='Personel'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public object Ara()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Kullanici WHERE " +
                        "Rol='Personel' AND" +
                        "(@kadi = '' OR KullaniciAdi LIKE '%' + @kadi + '%') AND " +
                        "(@ad = '' OR Ad LIKE '%' + @ad + '%') AND " +
                        "(@soyad = '' OR Soyad LIKE '%' + @soyad + '%') AND " +
                        "(@sifre = '' OR Sifre LIKE '%' + @sifre + '%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kadi", KullaniciAdi);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@sifre", Sifre);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }

        }

        public void Guncelle(int id)
        {
            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Kullanici SET KullaniciAdi=@kullaniciAdi, Ad=@ad, Soyad=@soyad, Sifre=@sifre, Rol=@rol WHERE ID=@id ", conn);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", KullaniciAdi);
                    cmd.Parameters.AddWithValue("@ad", Ad);
                    cmd.Parameters.AddWithValue("@soyad", Soyad);
                    cmd.Parameters.AddWithValue("@sifre", Sifre);
                    cmd.Parameters.AddWithValue("@rol", Rol);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
        }

        public void Sil(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Kullanici WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public void RaporAl()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Kitap", conn);
                int toplam = (int)cmd.ExecuteScalar();
                MessageBox.Show("Toplam Kitap Sayısı: " + toplam);
            }
        }
    }

    public class Personel : Kullanici
    {
        public override void Yetki()
        {
            MessageBox.Show("Personel Yetkisi");
        }

        public void Ekle()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Uye (TC, Ad, Soyad, Eposta, Ceza) " +
                    "VALUES (@tc, @ad, @soyad, @eposta, @ceza)", conn);

                cmd.Parameters.AddWithValue("@tc", TcNo);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@eposta", Eposta);
                cmd.Parameters.AddWithValue("@ceza", Ceza);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Uye", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public object Ara()
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                string query = "SELECT * FROM Uye WHERE " +
                               "(@tc = '' OR TC LIKE '%' + @tc + '%') AND " +
                               "(@ad = '' OR Ad LIKE '%' + @ad + '%') AND " +
                               "(@soyad = '' OR Soyad LIKE '%' + @soyad + '%') AND " +
                               "(@eposta = '' OR Eposta LIKE '%' + @eposta + '%') AND " +
                               "(@ceza = '' OR Ceza LIKE '%' + @ceza + '%')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@tc", TcNo);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@eposta", Eposta);
                cmd.Parameters.AddWithValue("@ceza", Ceza);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public void Guncelle(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Uye SET TC=@tc, Ad=@ad, Soyad=@soyad, Eposta=@eposta, Ceza=@ceza WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@tc", TcNo);
                cmd.Parameters.AddWithValue("@ad", Ad);
                cmd.Parameters.AddWithValue("@soyad", Soyad);
                cmd.Parameters.AddWithValue("@eposta", Eposta);
                cmd.Parameters.AddWithValue("@ceza", Ceza);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int id)
        {
            using (SqlConnection conn = DbHelper.Baglanti())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Uye WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
