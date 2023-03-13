using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string? UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public System.DateTime DateCreated { get; set; }
        public ICollection<CartDetail>? CartDetails { get; set; }
  
    }
}
