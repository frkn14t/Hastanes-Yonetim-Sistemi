namespace HastaneBolu.Models.Classes
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int KullaniciId { get; set; } // Kullanıcı ilişkisi
        public Kullanici kullanici { get; set; }
        public ICollection<Department> Departments { get; set; } // Sorumlu olduğu bölümler
        public ICollection<Appointment> Appointments { get; set; } // Randevu ilişkisi
    }

}
