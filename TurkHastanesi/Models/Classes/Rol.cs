using HastaneBolu.Models.Classes;

namespace HastaneBolu.Models.Classes
{
    public class Rol
    {
        public int RolId { get; set; }
        public string RolAd { get; set; } // Rol adı (Admin, Asistan, Öğretim Üyesi vb.)
        public string Aciklama { get; set; } // Rolün açıklaması
        public ICollection<Kullanici> Kullanicilar { get; set; } // Kullanıcılarla ilişki
    }

}
