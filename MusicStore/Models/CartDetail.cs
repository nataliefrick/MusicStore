using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    [Table("CartDetail")]   
    public class CartDetail
    {
        public int CartDetailId { get; set; }
  
        public int CartId { get; set; }

        public int AlbumId { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
        public Album? Album { get; set; }
        public Cart? Cart { get; set; }
    }
}
