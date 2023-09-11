using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

EDbContext context = new EDbContext();

#region Default Convention
#endregion
//class Calisan
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    //public int DepartmanId { get; set; } eklemesek de ef core ekler 
//    public Departman Departman { get; set; }
//}
//class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }

//}

#region Data Annotation
//class Calisan
//{
//    public int Id { get; set; }
//    public string Name { get; set; }


//    [ForeignKey(nameof(Departman))]
//    public int DId { get; set; } 
//    public Departman Departman { get; set; }
//}
//class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }

//}
#endregion

#region Fluent api
class Calisan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Departman Departman { get; set; }
}
class Departman
{
    public int Id { get; set; }
    public string DepartmanAdi { get; set; }
    public ICollection<Calisan> Calisanlar { get; set; }

}

#endregion



class EDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Departman> Departmanlar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=DESKTOP-2IG9GVD\\SQLEXPRESS;Database=One2Many;Trusted_Connection=True");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.Departman)
            .WithMany(d => d.Calisanlar);
    }
}