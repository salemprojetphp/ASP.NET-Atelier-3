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

        // Genre
        string GenresJSon=System.IO.File.ReadAllText("./wwwroot/json/GenreFromJSon.json");
        List<Genre>? genres=System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenresJSon);
        foreach(Genre g in genres)
        {
            modelBuilder.Entity<Genre>().HasData(g);
        }

        // MembershipTypes 
        string MembershipTypeJSON=System.IO.File.ReadAllText("./wwwroot/json/MembershipTypesFromJSON.json");
        List<MembershipType>? MembershipTypes=System.Text.Json.JsonSerializer.Deserialize<List<MembershipType>>(MembershipTypeJSON);
        foreach(MembershipType m in MembershipTypes)
        {
            modelBuilder.Entity<MembershipType>().HasData(m);
        }

        // MovieClients
        string MovieClientsJSON=System.IO.File.ReadAllText("./wwwroot/json/MovieClientsFromJSON.json");
        List<MovieClient>? MovieClients=System.Text.Json.JsonSerializer.Deserialize<List<MovieClient>>(MovieClientsJSON);
        foreach(MovieClient mc in MovieClients)
        {
            modelBuilder.Entity<MovieClient>().HasData(mc);
        }
        
        //Clients 
        string ClientJSON=System.IO.File.ReadAllText("./wwwroot/json/ClientsFromJSON.json");
        List<Client>? clients=System.Text.Json.JsonSerializer.Deserialize<List<Client>>(ClientJSON);
        foreach(Client c in clients)
        {
            modelBuilder.Entity<Client>().HasData(c);
        }

        // Movies 
        string MoviesJSON=System.IO.File.ReadAllText("./wwwroot/json/MoviesFromJSON.json");
        List<Movie>? Movies=System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(MoviesJSON);
        foreach(Movie m in Movies)
        {
            modelBuilder.Entity<Movie>().HasData(m);
        }

        base.OnModelCreating(modelBuilder);
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