using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    [Table("OrdStat")]
    public class OrdStat
    {
        public int OrdStatId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
