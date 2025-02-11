namespace HastaneBolu.Models.Classes
{
    public class Nobet
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AsistanId { get; set; } // Nöbet tutan asistan
        public Asistan Asistan { get; set; }
        public int DepartmentId { get; set; } // Nöbetin yapıldığı bölüm
        public Department Department { get; set; }
    }

}
