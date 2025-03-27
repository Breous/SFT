using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFT.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public required string ItemName { get; set; }

        public required string Material { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        // Foreign Key to User
        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public required User? User { get; set; }
    }
}
