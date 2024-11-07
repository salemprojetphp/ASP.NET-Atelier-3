using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyFrstMVCApp.Models;

public class Movie{
    public int Id { get; set; }
    public string Title { get; set; }="";
    [ForeignKey("Genre")] public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public ICollection<MovieClient>? MovieClients { get; set; }
    
    
}
