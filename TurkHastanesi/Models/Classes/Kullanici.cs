using System.Data;

namespace HastaneBolu.Models.Classes
{
    public class Kullanici
    {
      
            public int KullaniciId { get; set; }
            public string Ad { get; set; }
            public string Sifre { get; set; }
            public int RolId { get; set; } // Rol ilişkisi
            
            public Rol Rol { get; set; }
        

    }
}
