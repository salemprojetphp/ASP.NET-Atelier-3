
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyFrstMVCApp.Models
{
    public class MovieClient
    {
        public int MovieId { get; set; }
        public int ClientId { get; set; }

        public Movie? Movie { get; set; }

        public Client? Client { get; set; }
    }
}