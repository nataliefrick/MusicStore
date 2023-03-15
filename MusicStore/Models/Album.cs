using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MusicStore.Models
{
    public class Album
    {
        [DisplayName("Album")]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string Title{ get; set; }
        [Range(1, 100, ErrorMessage = "Error: The price must be between 1 and 100")]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [DisplayName("Image")]
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}
