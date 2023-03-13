using System.ComponentModel;

namespace MusicStore.Models
{
    public class Artist
    {
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        public string? Name { get; set; }
    }
}
