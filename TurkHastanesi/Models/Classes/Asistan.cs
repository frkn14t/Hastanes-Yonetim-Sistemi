namespace HastaneBolu.Models.Classes
{
    public class Asistan
    {
        public int AsistanId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int KullaniciId { get; set; } // Kullanıcı ilişkisi
        public Kullanici Kullanici { get; set; }
        public int DepartmentId { get; set; } // Bölüm ilişkisi
        public Department Department { get; set; }
        public ICollection<Nobet> Nobetler { get; set; } // Nöbet ilişkisi One-to-Many
        public ICollection<Appointment> Appointments { get; set; } // Randevu ilişkisi
    }

}
