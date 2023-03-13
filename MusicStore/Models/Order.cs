using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string? UserId { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int OrdStatId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public OrdStat? OrdStat { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
