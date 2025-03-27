using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFT.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? ItemName { get; set; }

        public string? Material { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        // ✅ Remove [Required] from here
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
