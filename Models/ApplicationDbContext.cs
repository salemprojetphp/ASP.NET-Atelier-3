using Microsoft.EntityFrameworkCore;
using MyFrstMVCApp.Models;

public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }	
    public DbSet<Client> Clients { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<MovieClient> MovieClients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId)
            .OnDelete(DeleteBehavior.Cascade);  

        modelBuilder.Entity<MovieClient>()
            .HasKey(mc => new { mc.MovieId, mc.ClientId });

        modelBuilder.Entity<MovieClient>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieClients)
            .HasForeignKey(mc => mc.MovieId);

        modelBuilder.Entity<MovieClient>()
            .HasOne(mc => mc.Client)
            .WithMany(c => c.MovieClients)
            .HasForeignKey(mc => mc.ClientId);
        
        base.OnModelCreating(modelBuilder);
        string GenresJSon=System.IO.File.ReadAllText("./Data/GenreFromJSon.json");
        List<Genre>? genres=System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenresJSon);
        foreach(Genre g in genres)
        {
            modelBuilder.Entity<Genre>().HasData(g);
        }
    }
    


    //Peut ne pas etre implementer car EF Core peut le faire automatiquement
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Movie>()
    //         .HasOne(m=>m.Genre)
    //         .WithMany(g=>g.Movies)
    //         .HasForeignKey(m=>m.GenreId);
    // }
}