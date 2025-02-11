using Microsoft.EntityFrameworkCore;
using HastaneBolu.Models.Classes;

public class HastaneBoluDBContext : DbContext
{
    public HastaneBoluDBContext(DbContextOptions<HastaneBoluDBContext> options)
        : base(options)
    {
    }

    // DbSet'ler (Tablolar)
    public DbSet<Rol> Roller { get; set; }
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Asistan> Asistanlar { get; set; }
    public DbSet<Doktor> Doktorlar { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Nobet> Nobetler { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AcilDurum> AcilDurumlar { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Role ↔ User (1:N)
        modelBuilder.Entity<Kullanici>()
            .HasOne(u => u.Rol)
            .WithMany(r => r.Kullanicilar)
            .HasForeignKey(u => u.RolId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict

        // User ↔ Assistant (1:1)
        modelBuilder.Entity<Asistan>()
            .HasOne(a => a.Kullanici)
        .WithOne()
            .HasForeignKey<Asistan>(a => a.KullaniciId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict

        // User ↔ Instructor (1:1)
        modelBuilder.Entity<Doktor>()
            .HasOne(i => i.kullanici)
            .WithOne()
            .HasForeignKey<Doktor>(i => i.KullaniciId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict

        // Department ↔ Instructor (1:N)
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Doktor)
            .WithMany(i => i.Departments)
            .HasForeignKey(d => d.DoktorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department ↔ Assistant (1:N)
        modelBuilder.Entity<Asistan>()
            .HasOne(a => a.Department)
            .WithMany(d => d.Asistanlar)
            .HasForeignKey(a => a.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Shift ↔ Assistant (1:N)
        modelBuilder.Entity<Nobet>()
            .HasOne(s => s.Asistan)
            .WithMany(a => a.Nobetler)
            .HasForeignKey(s => s.AsistanId)
            .OnDelete(DeleteBehavior.Restrict);

        // Shift ↔ Department (1:N)
        modelBuilder.Entity<Nobet>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Nobetler)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Appointment ↔ Assistant (N:N)
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Asistan)
            .WithMany(a => a.Appointments)
            .HasForeignKey(a => a.AsistanId)
            .OnDelete(DeleteBehavior.Restrict);

        // Appointment ↔ Instructor (N:N)
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.doktor)
            .WithMany(i => i.Appointments)
            .HasForeignKey(a => a.DoktorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
