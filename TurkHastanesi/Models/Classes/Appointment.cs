namespace HastaneBolu.Models.Classes
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string Not { get; set; } // Randevu notu
        public int AsistanId { get; set; } // Randevuyu alan asistan
        public Asistan Asistan { get; set; }
        public int DoktorId { get; set; } // Randevu verilen öğretim üyesi
        public Doktor doktor { get; set; }
    }

}
