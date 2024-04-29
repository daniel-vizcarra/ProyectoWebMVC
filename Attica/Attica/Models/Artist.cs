using System.ComponentModel.DataAnnotations;

namespace Attica.Models
{
    public class Artist

    {
        [Key]
        public int ArtistId { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public ICollection<ArtPieceDV>? ArtPieces { get; set; }
    }
}
