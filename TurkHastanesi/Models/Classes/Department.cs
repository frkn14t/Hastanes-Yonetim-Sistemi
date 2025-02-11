namespace HastaneBolu.Models.Classes
{
    public class Department
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int BedCount { get; set; } // Yataklı servis için yatak sayısı
        public int HastaSayisi { get; set; } // Hasta sayısı
        public string Aciklama { get; set; }
        public int DoktorId { get; set; } // Sorumlu öğretim üyesi
        public Doktor Doktor { get; set; }
        public ICollection<Asistan> Asistanlar { get; set; } // Asistanlar
        public ICollection<Nobet> Nobetler{ get; set; } // Nöbetler
    }

}
