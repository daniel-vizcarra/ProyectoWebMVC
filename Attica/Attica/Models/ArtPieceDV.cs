using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attica.Models
{
    public class ArtPieceDV
    {
        [Key]
        public int ArtPieceId { get; set; }
        public string? Title { get; set; }
        public int ArtistId { get; set; } // Foreign key property for the Artist table
        public Artist? Artist { get; set; } // Navigation property for the Artist table
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }



    }


}
