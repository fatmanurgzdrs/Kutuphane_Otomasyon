using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane047
{
    public interface IIslemler
    {
        void Ekle();
        object Listele();
        object Ara();
        void Guncelle(int id);
        void Sil(int sil);
    }

    public interface IKitapIslemleri
    {
        void Kontrol(int kitapId);
    }

    public interface IIdareIslemleri 
    {
        void RaporAl();
    }

    public interface IKullaniciIslemleri : IIslemler
    {
        new void Ekle();
        new object Listele();
        new object Ara();
        new void Guncelle(int id);
        new void Sil(int sil);
    }
}
